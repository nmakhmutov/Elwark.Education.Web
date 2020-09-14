import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, GetServerSidePropsContext, NextApiRequest, NextApiResponse, NextPage} from 'next';
import React, {useEffect, useState} from 'react';
import {Button, CircularProgress, Typography} from '@material-ui/core';
import TokenApi from 'lib/api/token';
import HistoryApi, {HistoryTestModel, TestCheckedAnswerModel} from 'lib/api/history';
import moment from 'moment';
import InputAnswer from 'components/Input/InputAnswer';
import RadioAnswer from 'components/Input/RadioAnswer';
import CheckboxAnswer from 'components/Input/CheckboxAnswer';
import useApi from 'lib/useApi';

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
    },
    form: {
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center'
    },
    button: {
        textAlign: 'center',
        display: 'block',
        margin: theme.spacing(3, 0)
    }
}));

type Props = {
    articleId: string,
    test: HistoryTestModel
}

const TestPage: NextPage<Props> = ({test}) => {
    const classes = useStyles();
    const [activeStep, setActiveStep] = useState(0);
    const [current, setCurrent] = useState(test.questions[activeStep]);
    const [answers, setAnswers] = useState<{ [key: number]: string }>({});
    const [answered, setAnswered] = useState(false);
    const [countdown, setCountdown] = useState<string>('');
    const [isLoading, setLoading] = useState(false);
    const toDate = moment.utc(test.expiredAt);

    useEffect(() => {
        const interval = setInterval(() => {
            const milliseconds = Math.max(0, toDate.diff(moment().utc()));
            const duration = moment.duration(milliseconds);
            setCountdown(moment.utc(duration.as('milliseconds')).format('HH:mm:ss'));
        }, 1000);
        return () => clearInterval(interval);
    }, []);

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        setLoading(true);
        const {data} = await useApi<TestCheckedAnswerModel>('POST', HistoryApi.endpoints.checkTestAnswer(test.id, current.id), answers);
        setLoading(false);

        if (!data.isCorrect)
            test.questions.push(current);

        setAnswered(true);
    };

    const nextQuestion = () => {
        setAnswered(false);
        const step = activeStep + 1;
        setActiveStep(step);
        setCurrent(test.questions[step]);
        setAnswers({});
    };

    return (
        <DefaultLayout title={'Questions'}>
            <div className={classes.root}>
                <Typography variant={'h6'} className={classes.progress}>
                    Question {activeStep + 1} / {test.questions?.length}
                </Typography>
                <Typography variant={'h3'} className={classes.question}>
                    {current.title}
                </Typography>
                <div className={classes.container}>
                    <form className={classes.form} onSubmit={handleSubmit}>
                        {current.type === 'noOptions' &&
                        <InputAnswer setAnswer={value => setAnswers(value ? {[0]: value} : {})}/>}
                        {current.type === 'singleOption' &&
                        <RadioAnswer setAnswer={value => setAnswers({[0]: value})} answers={current.options}/>}
                        {current.type === 'manyOptions' &&
                        <CheckboxAnswer setAnswers={value => {
                            const tmp: { [key: number]: string } = {};
                            value.forEach((x, i) => tmp[i] = x);
                            setAnswers(tmp);
                        }} answers={current.options}/>}
                        {answered
                            ? <Button
                                type={'button'}
                                variant={'contained'}
                                color={'primary'}
                                onClick={nextQuestion}
                                className={classes.button}>
                                Next
                            </Button>
                            : isLoading
                                ? <CircularProgress size={24}/>
                                :
                                <Button
                                    type={'submit'}
                                    variant={'contained'}
                                    color={'primary'}
                                    className={classes.button}
                                    disabled={Object.entries(answers).length === 0}>
                                    Answer
                                </Button>
                        }
                    </form>
                </div>
                <Typography variant={'subtitle2'}>
                    {countdown}
                </Typography>
            </div>
        </DefaultLayout>
    );
};

type Params = {
    test: string
}

export const getServerSideProps: GetServerSideProps<Props, Params> = async ({req, res, params}: GetServerSidePropsContext<Params>) => {
    const token = await TokenApi.get(req as NextApiRequest, res as NextApiResponse);
    const {data} = await HistoryApi.getTest(params!.test, token);

    return {props: {articleId: params!.test, test: data}};
};

export default TestPage;
