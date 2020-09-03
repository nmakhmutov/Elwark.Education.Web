import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, GetServerSidePropsContext, NextPage} from 'next';
import React, {useState} from 'react';
import {Typography} from '@material-ui/core';
import RadioAnswer from 'components/Test/RadioAnswer';

const useStyles = makeStyles((theme) => ({
    root: {
        display: 'flex',
        flexDirection: 'column',
        // justifyContent: 'center',
        alignItems: 'center',
        height: '100%',
        width: '100%',
        padding: theme.spacing(5)
    },
    container: {
        marginTop: theme.spacing(3)
    },
    progress: {
        textAlign: 'center',
        marginBottom: theme.spacing(1),
        color: theme.palette.text.secondary
    },
    question: {
        textAlign: 'center',
        marginBottom: theme.spacing(3)
    }
}));

type Props = {
    articleId: string,
    questions: string[]
}

const TestPage: NextPage<Props> = (props) => {
    const classes = useStyles();
    const {questions} = props;
    const [current, setCurrent] = useState(1);

    const handleSubmit = (value: string) => {

    };

    return (
        <DefaultLayout title={'Questions'}>
            <div className={classes.root}>
                <Typography variant={'h6'} className={classes.progress}>
                    Question {current} / {questions?.length}
                </Typography>
                <Typography variant={'h3'} className={classes.question}>
                    As recently dramatised in a critically acclaimed miniseries, what year did the Chernobyl disaster
                    occur?
                </Typography>
                <div className={classes.container}>
                    <RadioAnswer handleAnswer={handleSubmit} answers={[
                        'Which pilot famously fought in the Battle of Britain with two artificial legs?',
                        '1986',
                        '1987',
                        '1976',
                        '1977'
                    ]}/>
                </div>
            </div>
        </DefaultLayout>
    );
};

type Params = {
    article: string
}

export const getServerSideProps: GetServerSideProps<Props, Params> = async ({req, res, params}: GetServerSidePropsContext<Params>) => {
    // const token = await TokenApi.get(req as NextApiRequest, res as NextApiResponse);
    // const {data} = await HistoryApi.getArticle(params!.article, token);

    return {props: {articleId: params!.article, questions: []}};
}

export default TestPage;
