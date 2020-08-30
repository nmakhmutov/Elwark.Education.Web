import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, GetServerSidePropsContext, NextApiRequest, NextApiResponse, NextPage} from 'next';
import React from 'react';
import HistoryApi, {HistoryArticleModel} from 'lib/api/history';
import ReactMarkdown from 'react-markdown';
import {Button, Grid, Paper, Typography} from '@material-ui/core';
import {purple} from '@material-ui/core/colors';
import Links from 'lib/utils/Links';
import ArrowBackIcon from '@material-ui/icons/ArrowBack';
import {Link} from 'components';
import clsx from 'clsx';
import TokenApi from 'lib/api/token';

const useStyles = makeStyles((theme) => ({
    root:{
        maxWidth: 1920
    },
    content: {
        padding: theme.spacing(8),
        borderRadius: 0,
        boxShadow: theme.shadows[20],
    },
    titleRow: {
        display: 'flex',
        flexDirection: 'row',
        alignItems: 'center',
        paddingBottom: theme.spacing(3),
    },
    titleBack: {
        display: 'flex',
        marginRight: theme.spacing(2),
        color: theme.palette.common.black
    },
    subtitle: {
        paddingBottom: theme.spacing(3)
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
            height: '25vh',
        }
    },
    height: {
        minHeight: '100%'
    },
    padding: {
        padding: theme.spacing(4),
    },
    markdown: {
        '& h1': theme.typography.h2,
        '& h2': theme.typography.h3,
        '& h3': theme.typography.h4,
        '& h4': theme.typography.h5,
        '& h5': theme.typography.h6,
        '& h6': theme.typography.h6,
        '& p': theme.typography.body1,
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
    const topicLink = Links.HistoryTopic(article.topicId);

    return (
        <DefaultLayout title={'Topic'}>
            <Grid container={true} className={clsx(classes.root,classes.height)}>
                <Grid item={true} xs={12} md={7} lg={8} xl={6} className={classes.height}>
                    <Paper className={clsx(classes.content, classes.height)}>
                        <div className={classes.titleRow}>
                            <Typography
                                variant={'h1'}
                                className={classes.titleBack}
                                component={Link}
                                href={topicLink.href}
                                as={topicLink.as}>
                                <ArrowBackIcon fontSize={'large'}/>
                            </Typography>
                            <Typography variant={'h1'}>
                                {article.title}
                            </Typography>
                        </div>
                        {article.subtitle &&
                        <Typography
                            variant={'h4'}
                            color={'textSecondary'}
                            className={classes.subtitle}>
                            {article.subtitle}
                        </Typography>
                        }
                        <div>
                            <Button variant={'contained'} color={'primary'}>
                                Test
                            </Button>
                        </div>
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
    id: string
}

export const getServerSideProps: GetServerSideProps<Props, Params> = async ({req, res, params}: GetServerSidePropsContext<Params>) => {
    const token = await TokenApi.get(req as NextApiRequest, res as NextApiResponse);
    const {data} = await HistoryApi.getArticle(params!.id, token);
    return {props: {article: data}};
}

export default ArticlePage;
