import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, GetServerSidePropsContext, NextApiRequest, NextApiResponse, NextPage} from 'next';
import React from 'react';
import HistoryApi, {HistoryPeriod, HistoryPeriodModel, HistoryTopicItem} from 'lib/api/history';
import TokenApi from 'lib/api/token';
import {HistoryPeriodTabs, HistoryTopicGrid} from 'components/History';

const useStyles = makeStyles((theme) => ({
    root: {
        padding: theme.spacing(3),
        margin: '0 auto',
        maxWidth: 850
    }
}));

type Props = {
    periods: HistoryPeriodModel[],
    topics: HistoryTopicItem[]
}

const ModernPage: NextPage<Props> = ({periods, topics}) => {
    const classes = useStyles();
    const title = periods.filter(x => x.type === HistoryPeriod.modern)[0].title;

    return (
        <DefaultLayout title={title}>
            <HistoryPeriodTabs selected={HistoryPeriod.modern} periods={periods}/>
            <HistoryTopicGrid topics={topics} className={classes.root}/>
        </DefaultLayout>
    );
};

export const getServerSideProps: GetServerSideProps<Props> = async ({req, res}: GetServerSidePropsContext) => {
    const token = await TokenApi.get(req as NextApiRequest, res as NextApiResponse);
    const topics = await HistoryApi.getTopics(HistoryPeriod.modern, token);
    const periods = await HistoryApi.getPeriods(token);

    return {props: {topics: topics.data, periods: periods.data}};
}

export default ModernPage;
