import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, GetServerSidePropsContext, NextApiRequest, NextApiResponse, NextPage} from 'next';
import React from 'react';
import HistoryApi, {HistoryArticleItem, HistoryPeriodModel} from 'lib/api/history';
import TokenApi from 'lib/api/token';
import WebLinks from 'lib/WebLinks';
import ElwarkImageCard from 'components/Card/ElwarkImageCard';
import {Theme, Typography} from '@material-ui/core';
import {Link} from 'components';
import ElwarkCard from 'components/Card/ElwarkCard';
import clsx from 'clsx';

const useStyles = makeStyles((theme: Theme) => ({
    periods: {
        display: 'grid',
        gridTemplateColumns: 'repeat(1, 1fr)',
        gridAutoFlow: 'dense',
        gap: theme.spacing(2) + 'px',

        [theme.breakpoints.only('xs')]: {
            margin: theme.spacing(2, 0)
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
    period: {
        height: 170
    },
    content: {
        height: '100%',
        minHeight: 200,
        display: 'flex',
        flexDirection: 'column',
        padding: theme.spacing(2),
        color: theme.palette.common.white
    },
    center: {
        alignItems: 'center',
        justifyContent: 'center'
    },
    bottom: {
        alignItems: 'center',
        justifyContent: 'flex-end'
    },
    articles: {
        display: 'flex',
        flexDirection: 'column',
        flexWrap: 'wrap',
        gap: theme.spacing(2) + 'px',

        [theme.breakpoints.up('sm')]: {
            display: 'grid',
            margin: theme.spacing(2),
            gridTemplateColumns: 'repeat(2, 1fr)',
            gridAutoFlow: 'dense'
        },

        [theme.breakpoints.up('md')]: {
            gridTemplateColumns: 'repeat(4, 1fr)'
        },

        [theme.breakpoints.up('xl')]: {
            gridTemplateColumns: 'repeat(auto-fit, minmax(350px, 1fr))'
        }
    },
    big: {
        gridColumn: 'span 2',
        gridRow: 'span 2'
    },
    rectangle: {
        gridColumn: 'span 2'
    },
    title: {
        color: theme.palette.common.white
    }
}));

type Props = {
    periods: HistoryPeriodModel[],
    articles: HistoryArticleItem[]
}

const HistoryPage: NextPage<Props> = ({periods, articles}) => {
    const classes = useStyles();

    return (
        <DefaultLayout title={'History page'}>
            <div className={classes.periods}>
                {periods.map(item =>
                    <ElwarkImageCard key={item.type} className={classes.period} image={item.image}>
                        <div className={clsx(classes.content, classes.center)}>
                            <Typography variant={'h2'} className={classes.title} component={Link}
                                        href={WebLinks.HistoryPeriod(item.type)}>
                                {item.title}
                            </Typography>
                            <Typography variant={'subtitle1'} color={'inherit'} align={'center'}>
                                {item.description}
                            </Typography>
                        </div>
                    </ElwarkImageCard>
                )}
            </div>

            <div className={classes.articles}>
                {articles.map((item, i) => {
                        const link = WebLinks.HistoryArticle(item.articleId);

                        const className = (index: number) => {
                            if (index === 0)
                                return classes.big;

                            if (index >= 5 && index <= 8)
                                return classes.rectangle;
                        };

                        if (i === 0 && item.image)
                            return (
                                <ElwarkImageCard key={item.articleId} className={className(i)} image={item.image}>
                                    <div className={clsx(classes.content, classes.bottom)}>
                                        <Typography variant={'h2'} className={classes.title} component={Link}
                                                    href={link.href} as={link.as}>
                                            {item.title}
                                        </Typography>
                                        <Typography variant={'subtitle1'} color={'inherit'}>
                                            {item.subtitle}
                                        </Typography>
                                    </div>
                                </ElwarkImageCard>
                            );

                        if (item.image && item.subtitle)
                            return (
                                <ElwarkCard
                                    key={item.articleId}
                                    className={className(i)}
                                    image={item.image}
                                    title={
                                        <Typography
                                            component={Link}
                                            href={link.href}
                                            as={link.as}
                                            variant={'h4'}>
                                            {item.title}
                                        </Typography>
                                    }
                                    subtitle={item.subtitle}
                                    direction={'column'}/>
                            );

                        if (item.image && !item.subtitle)
                            return (
                                <ElwarkImageCard key={item.articleId} className={className(i)} image={item.image}>
                                    <div className={clsx(classes.content, classes.center)}>
                                        <Typography variant={'h2'} className={classes.title} component={Link}
                                                    href={link.href} as={link.as}>
                                            {item.title}
                                        </Typography>
                                    </div>
                                </ElwarkImageCard>
                            );

                        return (
                            <ElwarkCard
                                key={item.articleId}
                                className={className(i)}
                                title={
                                    <Typography
                                        component={Link}
                                        href={link.href}
                                        as={link.as}
                                        variant={'h4'}>
                                        {item.title}
                                    </Typography>
                                }
                                description={item.subtitle}
                                direction={'column'}/>
                        );
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
            periods: periods.data,
            articles: articles.data
            .sort((a, b) => {
                let right = 0;
                let left = 0;

                if (a.image)
                    right += 3;

                if (a.title)
                    right += 2;

                if (a.subtitle)
                    right++;

                if (b.image)
                    left += 3;

                if (b.title)
                    left += 2;

                if (b.subtitle)
                    left++;

                return left - right;
            })
        }
    };
};

export default HistoryPage;
