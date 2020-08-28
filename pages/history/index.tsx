import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, NextApiRequest, NextApiResponse, NextPage} from 'next';
import React from 'react';
import oidc from 'lib/oidc';
import HistoryApi, {TopicItem} from 'lib/api/history';
import {Grid} from '@material-ui/core';
import HistoryTopicCard from 'components/Card/HistoryTopicCard';

const useStyles = makeStyles((theme) => ({
    root: {
        padding: theme.spacing(3),
        margin: '0 auto',
        maxWidth: 850
    }
}));

type Props = {
    topics: TopicItem[]
}

const HistoryPage: NextPage<Props> = (props) => {
    const classes = useStyles();
    const {topics} = props;

    let i = 0;
    const get = () => {
        if (i >= 8)
            i = 0;

        i++;

        if (i === 3 || i === 4 || i === 5)
            return 4;

        if (i === 8)
            return 12;

        return 5;
    }

    return (
        <DefaultLayout title={'History page'}>
            <div className={classes.root}>
                <Grid container={true} spacing={3} justify={'center'}>
                    {topics.map((topic) =>
                        <Grid key={topic.topicId} item={true} xs={12} sm={6} md={get()}>
                            <HistoryTopicCard topic={topic}/>
                        </Grid>
                    )}
                </Grid>
            </div>
        </DefaultLayout>
    );
};

export const getServerSideProps: GetServerSideProps<Props> = async ({req, res}) => {
    let accessToken = '';

    try {
        const tokenCache = await oidc.tokenCache(req as NextApiRequest, res as NextApiResponse);
        const result = await tokenCache.getAccessToken({refresh: true})
        accessToken = result.accessToken!;
    } catch (e) {
        res.writeHead(302, {Location: '/api/login'});
        res.end();
        return;
    }

    const topics = await HistoryApi.getAll(accessToken);

    return {props: {topics: topics.data}};
}

export default HistoryPage;
