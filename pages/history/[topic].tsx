import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, GetServerSidePropsContext, NextApiRequest, NextApiResponse, NextPage} from 'next';
import React, {useState} from 'react';
import HistoryApi, {HistoryTopicModel} from 'lib/api/history';
import {Grid, Theme, Typography, withStyles} from '@material-ui/core';
import TokenApi from 'lib/api/token';
import {PricingModal} from 'components/PricingModal';
import Breadcrumbs from 'components/Breadcrumbs/Breadcrumbs';
import WebLinks from 'lib/WebLinks';
import ElwarkCard from 'components/Card/ElwarkCard';
import {amber} from '@material-ui/core/colors';
import moment from 'moment';
import {Link} from 'components';

const useStyles = makeStyles((theme: Theme) => ({
    root: {
        // padding: theme.spacing(3)
    },
    image: {
        backgroundPosition: 'center center',
        backgroundRepeat: 'no-repeat',
        backgroundSize: 'cover',
        position: 'relative',
        height: 200,

        [theme.breakpoints.up('sm')]: {
            height: 300
        },

        [theme.breakpoints.up('md')]: {
            height: '70vh'
        }
    },
    cover: {
        background: 'rgba(0,0,0,0.4)',
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
    breadcrumbs: {
        margin: theme.spacing(3)
    },
    description: {
        margin: theme.spacing(3),
        maxWidth: 980
    },
    card: {
        margin: theme.spacing(3)
    }
}));

type Props = {
    topic: HistoryTopicModel
}

const PremiumTypography = withStyles({root: {color: amber.A700}})(Typography);

const TopicPage: NextPage<Props> = (props) => {
    const classes = useStyles();
    const {topic} = props;

    const [pricingModalOpen, setPricingModalOpen] = useState(false);
    const handlePricingClose = () => {
        setPricingModalOpen(false);
    };

    const handlePricingOpen = (event: MouseEvent) => {
        event.preventDefault();
        setPricingModalOpen(true);
    };

    const [width, setWidth] = React.useState(0);

    React.useEffect(() => {
        const handleResize = () => setWidth(window.innerWidth);

        window.addEventListener('resize', handleResize);

        handleResize();

        return () => window.removeEventListener('resize', handleResize);
    }, []);

    return (
        <DefaultLayout title={topic.title}>
            <div className={classes.root}>
                <Grid container={true}>
                    <Grid item={true} xs={12} md={4} xl={3}>
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

                    <Grid item={true} xs={12} md={8} xl={9}>
                        <Breadcrumbs className={classes.breadcrumbs} paths={[
                            {title: 'History', link: {href: WebLinks.History}},
                            {title: topic.period.title, link: {href: WebLinks.HistoryPeriod(topic.period.type)}}
                        ]}/>
                        <Typography variant={'body1'} className={classes.description}>
                            {topic.description}
                        </Typography>
                        {topic.articles.map(article => {
                                const link = WebLinks.HistoryArticle(article.articleId);

                                return (
                                    <ElwarkCard
                                        key={article.articleId}
                                        className={classes.card}
                                        direction={width < 600 ? 'column' : 'row'}
                                        image={article.image}
                                        description={article.subtitle}
                                        title={
                                            article.type === 'premium'
                                                ? <Typography
                                                    component={Link}
                                                    variant={'h4'}
                                                    href={'#'}
                                                    onClick={handlePricingOpen}>
                                                    {article.title}
                                                </Typography>
                                                : <Typography
                                                    component={Link}
                                                    href={link.href}
                                                    as={link.as}
                                                    variant={'h4'}>
                                                    {article.title}
                                                </Typography>
                                        }
                                        subtitle={
                                            article.type === 'premium'
                                                ? <PremiumTypography>Premium</PremiumTypography>
                                                : undefined
                                        }
                                        actions={
                                            article.test.isAvailable
                                                ? (<Typography variant={'body2'}>
                                                    {article.test.passedAt
                                                        ? 'Test passed ' + moment(article.test.passedAt).fromNow()
                                                        : 'Test not passed'}
                                                </Typography>)
                                                : undefined
                                        }
                                    />
                                );
                            }
                        )}
                    </Grid>
                </Grid>
            </div>
            <PricingModal onClose={handlePricingClose} open={pricingModalOpen}/>
        </DefaultLayout>
    );
};

type Params = {
    topic: string
}

export const getServerSideProps: GetServerSideProps<Props, Params> = async ({req, res, params}: GetServerSidePropsContext<Params>) => {
    const token = await TokenApi.get(req as NextApiRequest, res as NextApiResponse);
    const {data} = await HistoryApi.getTopic(params!.topic, token);

    return {props: {topic: data}};
};

export default TopicPage;
