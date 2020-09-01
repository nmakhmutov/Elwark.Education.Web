import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, GetServerSidePropsContext, NextPage} from 'next';
import React from 'react';

const useStyles = makeStyles((theme) => ({}));

type Props = {
    articleId: string
}

const TestPage: NextPage<Props> = (props) => {
    const classes = useStyles();

    return (
        <DefaultLayout title={'Topic'}>
            Test
        </DefaultLayout>
    );
};

type Params = {
    article: string
}

export const getServerSideProps: GetServerSideProps<Props, Params> = async ({req, res, params}: GetServerSidePropsContext<Params>) => {
    // const token = await TokenApi.get(req as NextApiRequest, res as NextApiResponse);
    // const {data} = await HistoryApi.getArticle(params!.article, token);

    return {props: {articleId: params!.article}};
}

export default TestPage;
