import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, NextApiRequest, NextApiResponse, NextPage} from 'next';
import React from 'react';
import HistoryApi, {HistoryTopicModel} from 'lib/api/history';
import oidc from 'lib/oidc';
import {Grid, Typography} from '@material-ui/core';
import HistoryArticleCard from 'components/Card/HistoryArticleCard';

const useStyles = makeStyles((theme) => ({
    root: {
        padding: theme.spacing(3)
    },
    image: {
        backgroundPosition: 'center center',
        backgroundRepeat: 'no-repeat',
        backgroundSize: 'cover',
        position: 'relative',
        [theme.breakpoints.down('sm')]: {
            height: 200
        },
        [theme.breakpoints.up('sm')]: {
            height: '60vh'
        }
    },
    cover: {
        background: 'rgba(0,0,0,0.3)',
        width: '100%',
        height: '100%'
    },
    titleContainer: {
        position: 'absolute',
        bottom: 0,
        width: '100%',
        padding: theme.spacing(3),
        color: theme.palette.common.white,
        '& h1': {
            marginBottom: theme.spacing(3)
        }
    },
    description: {
        paddingBottom: theme.spacing(3),
        maxWidth: 980
    },
    card: {
        marginBottom: theme.spacing(3)
    }
}));

type Props = {
    topic: HistoryTopicModel
}

const TopicPage: NextPage<Props> = (props) => {
    const classes = useStyles();
    const {topic} = props;

    return (
        <DefaultLayout title={'Topic'}>
            <div className={classes.root}>
                <Grid container={true} spacing={3}>
                    <Grid item={true} xs={12} sm={5} md={4} xl={3}>
                        <div className={classes.image} style={{backgroundImage: `url(${topic.image})`}}>
                            <div className={classes.cover}>
                                <div className={classes.titleContainer}>
                                    <Typography component={'h1'} variant={'h1'} color={'inherit'}>
                                        {topic.title}
                                    </Typography>
                                    <Typography component={'h6'} variant={'h6'} color={'inherit'}>
                                        {topic.date}
                                    </Typography>
                                </div>
                            </div>
                        </div>
                    </Grid>

                    <Grid item={true} xs={12} sm={7} md={8} xl={9}>
                        <Typography variant={'body1'} className={classes.description}>
                            {topic.description}
                        </Typography>
                        {topic.articles.map(article =>
                            <HistoryArticleCard key={article.articleId} className={classes.card} article={article}/>
                        )}
                    </Grid>
                </Grid>
            </div>
        </DefaultLayout>
    );
};

export const getServerSideProps: GetServerSideProps<Props> = async ({req, res, params: {id}}) => {
    let accessToken = '';

    try {
        const tokenCache = await oidc.tokenCache(req as NextApiRequest, res as NextApiResponse);
        const result = await tokenCache.getAccessToken({refresh: true})
        accessToken = result.accessToken!;
    } catch (e) {
        res.writeHead(302, {Location: '/api/login'});
        res.end();
        return;
    }
    const topic = await HistoryApi.getTopic(id, accessToken);

    return {props: {topic: topic.data}};
}

export default TopicPage;
