import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, GetServerSidePropsContext, NextApiRequest, NextApiResponse, NextPage} from 'next';
import React from 'react';
import HistoryApi, {HistoryArticleItem, HistoryPeriodModel} from 'lib/api/history';
import TokenApi from 'lib/api/token';
import Links from 'lib/utils/Links';
import {HistoryArticleGridItem, HistoryPeriodCard} from 'components/History';

const useStyles = makeStyles((theme) => ({
    periods: {
        display: 'grid',
        gridTemplateColumns: 'repeat(1, 1fr)',
        gridAutoFlow: 'dense',
        gap: theme.spacing(2) + 'px',

        [theme.breakpoints.only('xs')]: {
            marginBottom: theme.spacing(2)
        },

        [theme.breakpoints.up('sm')]: {
            margin: theme.spacing(2),
            gridTemplateColumns: 'repeat(6, 1fr)',
            '& > div': {
                gridColumn: 'span 2'
            },
            '& > div:nth-child(4)': {
                gridColumn: '2 / 4'
            }
        },

        [theme.breakpoints.up(theme.breakpoints.width('md') + 130)]: {
            gridTemplateColumns: 'repeat(5, 1fr)',
            '& > div': {
                gridColumn: 'span 1'
            },
            '& > div:nth-child(4)': {
                gridColumn: 'span 1'
            }
        }
    },
    articles: {
        display: 'flex',
        flexDirection: 'column',
        margin: '0 auto',

        [theme.breakpoints.up('sm')]: {
            display: 'grid',
            margin: theme.spacing(2),
            gap: theme.spacing(2) + 'px',
            gridTemplateColumns: 'repeat(auto-fit, minmax(200px, 1fr))',
            gridAutoFlow: 'dense',
        },
    },
    article: {
        height: '100%',

        [theme.breakpoints.only('xs')]: {
            marginBottom: theme.spacing(2),
        },

        [theme.breakpoints.up('md')]: {
            '&:nth-child(1)': {
                gridColumn: 'span 3',
                gridRow: 'span 2'
            },

            '&:nth-child(4)': {
                gridColumn: 'span 2',
                gridRow: 'span 2'
            },

            '&:nth-child(6)': {
                gridColumn: 'span 2',
                gridRow: 'span 2'
            },

            '&:nth-of-type(3n)': {
                gridColumn: 'span 2'
            },

            '&:nth-of-type(5n)': {
                gridColumn: 'span 2'
            },
        },
    },
}));

type Props = {
    periods: HistoryPeriodModel[],
    articles: HistoryArticleItem[]
}

const HistoryPage: NextPage<Props> = (props) => {
    const classes = useStyles();
    const {periods, articles} = props;

    return (
        <DefaultLayout title={'History page'}>
            <div className={classes.periods}>
                {periods.map(item =>
                    <HistoryPeriodCard
                        key={item.type}
                        title={item.title}
                        description={item.description}
                        image={item.image}
                        href={Links.HistoryPeriod(item.type)}/>
                )}
            </div>

            <div className={classes.articles}>
                {articles.map(item => {
                        const link = Links.HistoryArticle(item.articleId)

                        return (
                            <div className={classes.article} key={item.articleId}>
                                <HistoryArticleGridItem
                                    title={item.title}
                                    description={item.subtitle}
                                    image={item.image}
                                    href={link.href}
                                    as={link.as}/>
                            </div>)
                    }
                )}
            </div>
        </DefaultLayout>
    );
};

export const getServerSideProps: GetServerSideProps<Props> = async ({req, res}: GetServerSidePropsContext) => {
    const token = await TokenApi.get(req as NextApiRequest, res as NextApiResponse);
    const periods = await HistoryApi.getPeriods(token);
    const articles = await HistoryApi.getRandomArticle(token);

    return {
        props: {
            articles: articles.data,
            periods: periods.data
        }
    };
}

export default HistoryPage;
