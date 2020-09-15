import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, GetServerSidePropsContext, NextApiRequest, NextApiResponse, NextPage} from 'next';
import React, {useEffect, useState} from 'react';
import {Button, CircularProgress, Typography} from '@material-ui/core';
import TokenApi from 'lib/api/token';
import HistoryApi, {AnswerResult, HistoryTestModel, TestCheckedAnswerModel} from 'lib/api/history';
import moment from 'moment';
import InputQuestion from 'components/Input/InputQuestion';
import RadioQuestion from 'components/Input/RadioQuestion';
import CheckboxQuestion from 'components/Input/CheckboxQuestion';
import useApi from 'lib/useApi';
import RadioAnswer from 'components/Input/RadioAnswer';
import InputAnswer from 'components/Input/InputAnswer';
import CheckboxAnswer from 'components/Input/CheckboxAnswer';

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

type TestView = 'Test' | 'Result' | 'Timeout';

const TestPage: NextPage<Props> = ({test}) => {
    const classes = useStyles();
    const toDate = moment.utc(test.expiredAt);

    const [activeStep, setActiveStep] = useState(0);
    const [current, setCurrent] = useState(test.questions[activeStep]);

    const [answered, setAnswered] = useState(false);
    const [userAnswers, setUserAnswers] = useState<{ [key: number]: string } | null>(null);
    const [correctAnswers, setCorrectAnswers] = useState<{ [key: number]: string } | null>(null);
    const [isLoading, setLoading] = useState(false);
    const [result, setResult] = useState<AnswerResult | null>(null);

    const [countdown, setCountdown] = useState<string>('');
    const [currentView, setCurrentView] = useState<TestView>(toDate.diff(moment().utc()) > 0 ? 'Test' : 'Timeout');

    useEffect(() => {
        const interval = setInterval(() => {
            const milliseconds = Math.max(0, toDate.diff(moment().utc()));
            const duration = moment.duration(milliseconds);
            setCountdown(moment.utc(duration.as('milliseconds')).format('HH:mm:ss'));

            if (milliseconds === 0)
                setCurrentView('Timeout');

        }, 1000);
        return () => clearInterval(interval);
    }, []);

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        setLoading(true);
        const {data} = await useApi<TestCheckedAnswerModel>('POST', HistoryApi.endpoints.checkTestAnswer(test.id, current.id), userAnswers);
        setLoading(false);

        setCorrectAnswers(data.answers);

        if (!data.isCorrect)
            test.questions.push(current);

        if (data.result)
            setResult(data.result);

        setAnswered(true);
    };

    const showNext = () => {
        setAnswered(false);
        setUserAnswers(null);
        setCorrectAnswers(null);

        if (result)
        {
            setCurrentView('Result');
            return;
        }

        const step = activeStep + 1;
        setActiveStep(step);
        setCurrent(test.questions[step]);
    };

    return (
        <DefaultLayout title={'Questions'}>
            <div className={classes.root}>
                <Typography variant={'h6'} className={classes.progress}>
                    Question {activeStep + 1} / {test.questions?.length}
                </Typography>
                {currentView === 'Test' &&
                <div className={classes.container}>
                    <Typography variant={'h3'} className={classes.question}>
                        {current.title}
                    </Typography>
                    <form className={classes.form} onSubmit={handleSubmit}>
                        {current.type === 'noOptions' &&
                        (userAnswers && correctAnswers
                                ? <InputAnswer userAnswer={userAnswers[0]} correctAnswer={correctAnswers[0]}/>
                                : <InputQuestion setAnswer={value => setUserAnswers(value ? {[0]: value} : {})}/>
                        )}

                        {current.type === 'singleOption' &&
                        (userAnswers && correctAnswers
                                ? <RadioAnswer
                                    userAnswer={userAnswers[0]}
                                    correctAnswer={correctAnswers[0]}
                                    answers={current.options}/>
                                : <RadioQuestion
                                    setAnswer={value => setUserAnswers({[0]: value})}
                                    answers={current.options}/>
                        )}

                        {current.type === 'manyOptions' &&
                        (userAnswers && correctAnswers
                                ? <CheckboxAnswer
                                    userAnswer={Object.values(userAnswers)}
                                    correctAnswer={Object.values(correctAnswers)}
                                    answers={current.options}/>
                                : <CheckboxQuestion setAnswers={value => {
                                    const tmp: { [key: number]: string } = {};
                                    value.forEach((x, i) => tmp[i] = x);
                                    setUserAnswers(tmp);
                                }} answers={current.options}/>
                        )}

                        {answered
                            ? <Button
                                type={'button'}
                                variant={'contained'}
                                color={'primary'}
                                onClick={showNext}
                                className={classes.button}>
                                Next
                            </Button>
                            : isLoading
                                ? <CircularProgress size={24}/>
                                : <Button
                                    type={'submit'}
                                    variant={'contained'}
                                    color={'primary'}
                                    className={classes.button}
                                    disabled={userAnswers === null}>
                                    Answer
                                </Button>
                        }
                    </form>
                </div>}
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
