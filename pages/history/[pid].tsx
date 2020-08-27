import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, NextApiRequest, NextApiResponse, NextPage} from 'next';
import React from 'react';
import HistoryApi from 'lib/api/history';
import oidc from 'lib/oidc';

const useStyles = makeStyles((theme) => ({}));

type Props = {
    topic: any
}

const TopicPage: NextPage<Props> = (props) => {
    const classes = useStyles();
    const {topic} = props;

    return (
        <DefaultLayout title={'Topic'}>
            <div>{JSON.stringify(topic, null, 4)}</div>
        </DefaultLayout>
    );
};

// export const getStaticPaths: GetStaticPaths<Props> = () => {
//     return {paths: [], fallback: true};
// }
//
// export const getStaticProps: GetStaticProps<Props> = ({params}) => {
//     const {pid} = params;
//     const tokenCache = await oidc.tokenCache(req as NextApiRequest, res as NextApiResponse);
//     const {accessToken} = await tokenCache.getAccessToken({refresh: true})
//     HistoryApi.getTopic(pid)
//     return {props: {topicId: pid}};
// }

export const getServerSideProps: GetServerSideProps<Props> = async ({req, res, params}) => {
    const {pid} = params;
    const tokenCache = await oidc.tokenCache(req as NextApiRequest, res as NextApiResponse);
    const {accessToken} = await tokenCache.getAccessToken({refresh: true})
    const topic = await HistoryApi.getTopic(pid, accessToken!);

    return {props: {topic: topic.data}};
}

export default TopicPage;
