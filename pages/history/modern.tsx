import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, GetServerSidePropsContext, NextApiRequest, NextApiResponse, NextPage} from 'next';
import React from 'react';
import HistoryApi, {HistoryPeriodModel, HistoryTopicItem} from 'lib/api/history';
import TokenApi from 'lib/api/token';
import HistoryPeriodTabs from 'components/History/HistoryPeriodTabs';
import HistoryTopicGrid from 'components/History/HistoryTopicGrid';

const useStyles = makeStyles((theme) => ({
    root: {
        padding: theme.spacing(3)
    }
}));

type Props = {
    periods: HistoryPeriodModel[],
    topics: HistoryTopicItem[]
}

const ModernPage: NextPage<Props> = ({periods, topics}) => {
    const classes = useStyles();
    const title = periods.filter(x => x.type === 'modern')[0].title;

    return (
        <DefaultLayout title={title}>
            <HistoryPeriodTabs selected={'modern'} periods={periods}/>
            <HistoryTopicGrid topics={topics} className={classes.root}/>
        </DefaultLayout>
    );
};

export const getServerSideProps: GetServerSideProps<Props> = async ({req, res}: GetServerSidePropsContext) => {
    const token = await TokenApi.get(req as NextApiRequest, res as NextApiResponse);
    const topics = await HistoryApi.getTopics('modern', token);
    const periods = await HistoryApi.getPeriods(token);

    return {props: {topics: topics.data, periods: periods.data}};
}

export default ModernPage;
