import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, GetServerSidePropsContext, NextApiRequest, NextApiResponse, NextPage} from 'next';
import React, {useState} from 'react';
import HistoryApi, {HistoryTopicModel} from 'lib/api/history';
import {Grid, Typography} from '@material-ui/core';
import TokenApi from 'lib/api/token';
import {PricingModal} from 'components/PricingModal';
import Breadcrumbs from 'components/Breadcrumbs/Breadcrumbs';
import Links from 'lib/utils/Links';
import {HistoryArticleCard} from 'components/History';

const useStyles = makeStyles((theme) => ({
    root: {
        // padding: theme.spacing(3)
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
            height: '70vh'
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
        padding: theme.spacing(3),
        maxWidth: 980,
        [theme.breakpoints.up('sm')]: {
            padding: theme.spacing(3, 2, 3, 0),
        }
    },
    card: {
        marginBottom: theme.spacing(3)
    },
    breadcrumbs: {
        marginTop: theme.spacing(3)
    }
}));

type Props = {
    topic: HistoryTopicModel
}

const TopicPage: NextPage<Props> = (props) => {
    const classes = useStyles();
    const {topic} = props;

    const [pricingModalOpen, setPricingModalOpen] = useState(false);
    const handlePricingClose = () => {
        setPricingModalOpen(false);
    };
    const handlePricingOpen = () => {
        setPricingModalOpen(true);
    };

    return (
        <DefaultLayout title={'Topic'}>
            <div className={classes.root}>
                <Grid container={true} spacing={3}>
                    <Grid item={true} xs={12} sm={6} md={5} xl={3}>
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

                    <Grid item={true} xs={12} sm={6} md={7} xl={9}>
                        <Breadcrumbs className={classes.breadcrumbs} paths={[
                            {title: 'History', link: {href: Links.History}},
                            {title: topic.title}
                        ]}/>
                        <Typography variant={'body1'} className={classes.description}>
                            {topic.description}
                        </Typography>
                        {topic.articles.map(article =>
                            <HistoryArticleCard
                                key={article.articleId}
                                className={classes.card}
                                onPremiumPopup={handlePricingOpen}
                                article={article}/>
                        )}
                    </Grid>
                </Grid>
            </div>
            <PricingModal
                onClose={handlePricingClose}
                open={pricingModalOpen}
            />
        </DefaultLayout>
    );
};

type Params = {
    id: string
}

export const getServerSideProps: GetServerSideProps<Props, Params> = async ({req, res, params}: GetServerSidePropsContext<Params>) => {
    const token = await TokenApi.get(req as NextApiRequest, res as NextApiResponse);
    const {data} = await HistoryApi.getTopic(params!.id, token);

    return {props: {topic: data}};
}

export default TopicPage;
