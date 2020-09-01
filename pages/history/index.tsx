import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, GetServerSidePropsContext, NextApiRequest, NextApiResponse, NextPage} from 'next';
import React from 'react';
import HistoryApi, {HistoryCardModel} from 'lib/api/history';
import TokenApi from 'lib/api/token';
import Links from 'lib/utils/Links';
import {HistoryArticleGridItem, HistoryPeriodGridItem} from 'components/History';

const useStyles = makeStyles((theme) => ({
    root: {
        maxWidth: theme.breakpoints.width('xl'),
        minHeight: '100%',
        margin: '0 auto',
        display: 'flex',
        flexDirection: 'column',

        [theme.breakpoints.down('xs')]: {
            '& > div': {
                height: '250px'
            },
        },

        [theme.breakpoints.up('sm')]: {
            display: 'grid',
            gridAutoFlow: 'dense',
            gridTemplateColumns: 'repeat(5, minmax(auto, 1fr))',
            gridTemplateRows: 'repeat(6, minmax(180px, 1fr))',
            '& > div:nth-child(1)': {
                gridColumn: 1,
                gridRow: 1,
            },
            '& > div:nth-child(2)': {
                gridColumn: 1,
                gridRow: 2,
            },
            '& > div:nth-child(3)': {
                gridColumn: 1,
                gridRow: 3,
            },
            '& > div:nth-child(4)': {
                gridColumn: 1,
                gridRow: 4,
            },
            '& > div:nth-child(5)': {
                gridColumn: 1,
                gridRow: 5,
            },
            '& > div:nth-child(6)': {
                gridColumn: '2 / 6',
                gridRow: '1 / 3'
            },
            '& > div:nth-child(7)': {
                gridColumn: '2 / 4',
                gridRow: '3'
            },
            '& > div:nth-child(8)': {
                gridColumn: '4 / 6',
                gridRow: '3'
            },
            '& > div:nth-child(9)': {
                gridColumn: '2 / 6',
                gridRow: '4'
            },
            '& > div:nth-child(10)': {
                gridColumn: '2 / 4',
                gridRow: '5'
            },
            '& > div:nth-child(11)': {
                gridColumn: '4 / 6',
                gridRow: '5'
            },
            '& > div:nth-child(12)': {
                gridColumn: '1 / 3',
                gridRow: '6'
            },
            '& > div:nth-child(13)': {
                gridColumn: '3 / 6',
                gridRow: '6'
            },
        },

        [theme.breakpoints.up('md')]: {
            gridTemplateColumns: 'repeat(4, minmax(auto, 1fr))',
            gridTemplateRows: 'repeat(5, minmax(180px, 1fr))',
            '& > div:nth-child(1)': {
                gridColumn: 1,
                gridRow: 1,
            },
            '& > div:nth-child(2)': {
                gridColumn: 1,
                gridRow: 2,
            },
            '& > div:nth-child(3)': {
                gridColumn: 1,
                gridRow: 3,
            },
            '& > div:nth-child(4)': {
                gridColumn: 1,
                gridRow: 4,
            },
            '& > div:nth-child(5)': {
                gridColumn: 1,
                gridRow: 5,
            },
            '& > div:nth-child(6)': {
                gridColumn: '2 / 4',
                gridRow: '1 / 3'
            },
            '& > div:nth-child(7)': {
                gridColumn: '4',
                gridRow: '1 / 3'
            },
            '& > div:nth-child(8)': {
                gridColumn: '2',
                gridRow: '3'
            },
            '& > div:nth-child(9)': {
                gridColumn: '3 / 5',
                gridRow: '3'
            },
            '& > div:nth-child(10)': {
                gridColumn: '2',
                gridRow: '4 / 6'
            },
            '& > div:nth-child(11)': {
                gridColumn: '3 / 4',
                gridRow: '4'
            },
            '& > div:nth-child(12)': {
                gridColumn: '4 / 5',
                gridRow: '4'
            },
            '& > div:nth-child(13)': {
                gridColumn: '3 / 5',
                gridRow: '5'
            },
        }
    }
}));

type Props = {
    topics: HistoryCardModel[]
}

const HistoryPage: NextPage<Props> = (props) => {
    const classes = useStyles();
    const {topics} = props;

    return (
        <DefaultLayout title={'History page'}>
            <div className={classes.root}>
                {topics.map((item, index) => {
                        switch (item.type) {
                            case 'Period':
                                return (
                                    <HistoryPeriodGridItem
                                        key={item.id}
                                        title={item.title}
                                        description={item.description}
                                        image={item.image}
                                        href={Links.HistoryPeriod(item.id.toLowerCase())}/>
                                )

                            case 'Article':
                                const link = Links.HistoryArticle(item.id);

                                return (
                                    <HistoryArticleGridItem
                                        key={item.id}
                                        elementIndex={index}
                                        title={item.title}
                                        description={item.description}
                                        image={item.image}
                                        href={link.href}
                                        as={link.as}/>
                                );
                        }
                    }
                )}
            </div>
        </DefaultLayout>
    );
};

export const getServerSideProps: GetServerSideProps<Props> = async ({req, res}: GetServerSidePropsContext) => {
    const token = await TokenApi.get(req as NextApiRequest, res as NextApiResponse);
    const {data} = await HistoryApi.get(token);

    return {props: {topics: data}};
}

export default HistoryPage;
