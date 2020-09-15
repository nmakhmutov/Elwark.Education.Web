import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, GetServerSidePropsContext, NextApiRequest, NextApiResponse, NextPage} from 'next';
import React, {useState} from 'react';
import HistoryApi, {HistoryArticleModel} from 'lib/api/history';
import ReactMarkdown from 'react-markdown';
import {Button, Grid, Paper, Typography} from '@material-ui/core';
import {purple} from '@material-ui/core/colors';
import WebLinks from 'lib/WebLinks';
import clsx from 'clsx';
import TokenApi from 'lib/api/token';
import Breadcrumbs from 'components/Breadcrumbs/Breadcrumbs';
import BorderColorIcon from '@material-ui/icons/BorderColor';
import {useRouter} from 'next/router';
import useApi from 'lib/useApi';
import NProgress from 'nprogress';

const useStyles = makeStyles((theme) => ({
    root: {
        maxWidth: 1920
    },
    content: {
        padding: theme.spacing(3),
        borderRadius: 0,
        boxShadow: theme.shadows[20]
    },
    title: {
        marginBottom: theme.spacing(3)
    },
    test: {
        marginBottom: theme.spacing(3)
    },
    subtitle: {
        marginBottom: theme.spacing(3)
    },
    breadcrumbs: {
        marginBottom: theme.spacing(3)
    },
    image: {
        width: '100%',
        backgroundPosition: 'center center',
        backgroundRepeat: 'no-repeat',
        backgroundSize: 'cover',
        [theme.breakpoints.down('sm')]: {
            height: 200
        },
        [theme.breakpoints.up('sm')]: {
            height: '25vh'
        }
    },
    height: {
        minHeight: '100%'
    },
    padding: {
        padding: theme.spacing(4)
    },
    link: {
        '&:hover': {
            textDecoration: 'none'
        }
    },
    markdown: {
        '& h1': theme.typography.h2,
        '& h2': theme.typography.h3,
        '& h3': theme.typography.h4,
        '& h4': theme.typography.h5,
        '& h5': theme.typography.h6,
        '& h6': theme.typography.h6,
        '& p': theme.typography.body1,
        '& img': {
            display: 'block',
            margin: theme.spacing(3, 'auto'),
            maxWidth: '100%'
        },
        '& > ul, & > ol': {
            marginLeft: theme.spacing(2)
        },
        '& > *': {
            marginBottom: theme.spacing(3)
        },
        '& > hr': {
            border: '0',
            height: '1px',
            backgroundImage: 'linear-gradient(to right, rgba(0, 0, 0, 0), rgba(0, 0, 0, 0.75), rgba(0, 0, 0, 0))'
        },
        '& a': {
            '&:hover': {
                textDecoration: 'underline'
            },
            '&:visited': {
                color: purple['700']
            }
        }
    }
}));

type Props = {
    article: HistoryArticleModel
}

const ArticlePage: NextPage<Props> = (props) => {
    const classes = useStyles();
    const {article} = props;
    const topicLink = WebLinks.HistoryTopic(article.topic.id);
    const router = useRouter();
    const [testLoading, setTestLoading] = useState(false);

    const createTest = async () => {
        setTestLoading(true);
        NProgress.start();

        try
        {
            const {data: {testId}} = await useApi<{ testId: string }>('POST', HistoryApi.endpoints.createArticleTest(article.id));
            const testLink = WebLinks.HistoryTest(testId);
            await router.push(testLink.href, testLink.as);
        }
        catch (error)
        {
            NProgress.done();
            setTestLoading(false);
        }
    };

    return (
        <DefaultLayout title={article.title}>
            <Grid container={true} className={clsx(classes.root, classes.height)}>
                <Grid item={true} xs={12} md={7} lg={8} xl={6} className={classes.height}>
                    <Paper className={clsx(classes.content, classes.height)}>
                        <Breadcrumbs className={classes.breadcrumbs} paths={[
                            {title: 'History', link: {href: WebLinks.History}},
                            {title: article.period.title, link: {href: WebLinks.HistoryPeriod(article.period.type)}},
                            {title: article.topic.title, link: {href: topicLink.href, as: topicLink.as}}
                        ]}/>
                        <Typography variant={'h1'} className={classes.title}>
                            {article.title}
                        </Typography>
                        {article.isTestAvailable &&
                        <div className={classes.test}>
                            <Button
                                variant={'contained'}
                                className={classes.link}
                                onClick={createTest}
                                color={'primary'}
                                disabled={testLoading}
                                startIcon={<BorderColorIcon/>}>
                                Pass a test
                            </Button>
                        </div>
                        }
                        {article.subtitle &&
                        <Typography variant={'h4'} color={'textSecondary'} className={classes.subtitle}>
                            {article.subtitle}
                        </Typography>
                        }
                        <ReactMarkdown source={article.text} className={classes.markdown}/>
                    </Paper>
                </Grid>
                <Grid item={true} xs={12} md={5} lg={4} xl={3} className={classes.height}>
                    {article.image &&
                    <div className={classes.image} style={{backgroundImage: `url(${article.image})`}}/>}
                    <ReactMarkdown source={article.footnotes} className={clsx(classes.markdown, classes.padding)}/>
                </Grid>
            </Grid>
        </DefaultLayout>
    );
};

type Params = {
    article: string
}

export const getServerSideProps: GetServerSideProps<Props, Params> = async ({req, res, params}: GetServerSidePropsContext<Params>) => {
    const token = await TokenApi.get(req as NextApiRequest, res as NextApiResponse);
    const {data} = await HistoryApi.getArticle(params!.article, token);

    return {props: {article: data}};
};

export default ArticlePage;
