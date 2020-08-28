import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, NextPage} from 'next';
import React from 'react';

const useStyles = makeStyles((theme) => ({
    root: {
        padding: theme.spacing(3)
    }
}));

type Props = {
    articleId: string
}

const ArticlePage: NextPage<Props> = (props) => {
    const classes = useStyles();
    const {articleId} = props;

    return (
        <DefaultLayout title={'Topic'}>
            <h1>{articleId}</h1>
        </DefaultLayout>
    );
};

export const getServerSideProps: GetServerSideProps<Props> = async ({req, res, params}) => {
    const {id} = params;
    // let accessToken = '';
    //
    // try {
    //     const tokenCache = await oidc.tokenCache(req as NextApiRequest, res as NextApiResponse);
    //     const result = await tokenCache.getAccessToken({refresh: true})
    //     accessToken = result.accessToken!;
    // } catch (e) {
    //     res.writeHead(302, {Location: '/api/login'});
    //     res.end();
    //     return;
    // }
//    const topic = await HistoryApi.getTopic(tid, accessToken);

    return {props: {articleId: id}};
}

export default ArticlePage;
