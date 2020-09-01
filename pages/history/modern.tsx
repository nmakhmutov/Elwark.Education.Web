import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, GetServerSidePropsContext, NextApiRequest, NextApiResponse, NextPage} from 'next';
import React from 'react';
import HistoryApi, {HistoryTopicItem} from 'lib/api/history';
import TokenApi from 'lib/api/token';
import HistoryTopicGrid from 'components/History/Grid/HistoryTopicGrid';

const useStyles = makeStyles((theme) => ({
    root: {
        padding: theme.spacing(3),
        margin: '0 auto',
        maxWidth: 850
    }
}));

type Props = {
    topics: HistoryTopicItem[]
}

const AncientPage: NextPage<Props> = (props) => {
    const classes = useStyles();
    const {topics} = props;

    return (
        <DefaultLayout title={'Modern history page'}>
            <HistoryTopicGrid topics={topics} className={classes.root}/>
        </DefaultLayout>
    );
};

export const getServerSideProps: GetServerSideProps<Props> = async ({req, res}: GetServerSidePropsContext) => {
    const token = await TokenApi.get(req as NextApiRequest, res as NextApiResponse);
    const {data} = await HistoryApi.getTopics('modern', token);

    return {props: {topics: data}};
}

export default AncientPage;
