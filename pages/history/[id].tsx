import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, NextApiRequest, NextApiResponse, NextPage} from 'next';
import React from 'react';
import HistoryApi, {TopicModel} from 'lib/api/history';
import oidc from 'lib/oidc';
import {Grid, Typography} from '@material-ui/core';
import HistoryArticleCard from 'components/Card/HistoryArticleCard';

const useStyles = makeStyles((theme) => ({
    root: {
        padding: theme.spacing(3)
    }
}));

type Props = {
    topic: TopicModel
}

const TopicPage: NextPage<Props> = (props) => {
    const classes = useStyles();
    const {topic} = props;

    return (
        <DefaultLayout title={'Topic'}>
            <div className={classes.root}>
                <Typography component={'h1'} variant={'h2'} align={'center'}>
                    {topic.title}
                </Typography>
                <Typography component={'h2'} variant={'h4'} color={'textSecondary'} align={'center'}>
                    {topic.date}
                </Typography>

                <Grid container={true}>
                    <Grid item={true} xs={12} sm={4} md={3}>
                        <img src={topic.image} alt={topic.title}/>
                        <p>{topic.description}</p>
                    </Grid>
                    <Grid item={true} xs={12} sm={8} md={9}>
                        {topic.articles.map(article =>
                            <HistoryArticleCard
                                key={article.articleId}
                                article={{
                                    topicId: article.topicId,
                                    articleId: article.articleId,
                                    title: article.title,
                                    image: article.image
                                }}/>
                        )}
                    </Grid>
                </Grid>
            </div>
        </DefaultLayout>
    );
};

export const getServerSideProps: GetServerSideProps<Props> = async ({req, res, params}) => {
    const {id} = params;
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
