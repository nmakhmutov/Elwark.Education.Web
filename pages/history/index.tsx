import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, GetServerSidePropsContext, NextApiRequest, NextApiResponse, NextPage} from 'next';
import React from 'react';
import HistoryApi, {HistoryCardModel} from 'lib/api/history';
import TokenApi from 'lib/api/token';
import Links from 'lib/utils/Links';
import {HistoryArticleGridItem, HistoryPeriodCard} from 'components/History';
import {Typography} from "@material-ui/core";

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
            gridTemplateColumns: 'repeat(auto-fit, minmax(250px, 1fr))',
            gridAutoFlow: 'dense',
        },

        [theme.breakpoints.up('md')]: {
            gridTemplateColumns: 'repeat(auto-fit, minmax(180px, 1fr))',
        }
    },
    article: {
        height: '100%',
        marginBottom: theme.spacing(2),

        [theme.breakpoints.up('sm')]: {
            '&:nth-child(1)': {
                gridColumn: 'span 2',
                gridRow: 'span 2'
            },
        },
        [theme.breakpoints.up('md')]: {
            gridColumn: 'span 2',

            '&:nth-child(1)': {
                gridColumn: 'span 4',
                gridRow: 'span 2'
            },
        },
    },
}));

type Props = {
    periods: HistoryCardModel[],
    articles: HistoryCardModel[]
}

const HistoryPage: NextPage<Props> = (props) => {
    const classes = useStyles();
    const {periods, articles} = props;

    return (
        <DefaultLayout title={'History page'}>
            <div className={classes.periods}>
                {periods.map(item =>
                    <HistoryPeriodCard
                        key={item.id}
                        title={item.title}
                        description={item.description}
                        image={item.image}
                        href={Links.HistoryPeriod(item.id)}/>
                )}
            </div>

            <div className={classes.articles}>
                {articles.map(item => {
                        const link = Links.HistoryArticle(item.id)

                        return (
                            <div className={classes.article} key={item.id}>
                                <HistoryArticleGridItem
                                    title={item.title}
                                    description={item.description}
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
    const {data} = await HistoryApi.get(token);

    return {
        props: {
            articles: data.filter(x => x.type === 'Article'),
            periods: data.filter(x => x.type === 'Period')
        }
    };
}

export default HistoryPage;
