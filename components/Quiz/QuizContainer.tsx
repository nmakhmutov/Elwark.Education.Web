import React, {useState} from 'react';
import {Theme, Typography} from '@material-ui/core';
import {makeStyles} from '@material-ui/styles';
import {QuestionType} from 'lib/api/history';
import clsx from 'clsx';
import LoadingButton from 'components/Buttons/LoadingButton';
import NoOptionQuestion from 'components/Quiz/components/NoOptionQuestion';
import SingleOptionQuestion from 'components/Quiz/components/SingleOptionQuestion';

const useStyles = makeStyles((theme: Theme) => ({
    root: {},
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
    className?: string,
    questions: Question[],
    onAnswer: (questionId: string, answer: string | string[]) => Promise<Answer>
}

export interface Answer
{
    isCorrect: boolean,
    canReAnswer: boolean,
    answers: string | string[]
}

export interface Question
{
    readonly id: string,
    readonly title: string,
    readonly isAnswered: boolean,
    readonly type: QuestionType,
    readonly options: string[]
}

const QuizContainer: React.FC<Props> = ({className, questions, onAnswer}) => {
    const classes = useStyles();
    const [activeStep, setActiveStep] = useState(questions.findIndex(value => !value.isAnswered));
    const [current, setCurrent] = useState(questions[activeStep]);
    const [loading, setLoading] = useState(false);

    const [answered, setAnswered] = useState(false);
    const [answer, setAnswer] = useState<string | string[] | null>(null);
    const [correct, setCorrect] = useState<Answer | null>(null);

    const onAnswerClick = async () => {
        if (!answer)
            return;

        setAnswered(true);
        setLoading(true);
        const result = await onAnswer(current.id, answer);
        setLoading(false);

        if (result.canReAnswer)
            questions.push(current);

        setCorrect(result);
    };

    const showNext = () => {
        setAnswered(false);
        setAnswer(null);
        setCorrect(null);

        // const step = activeStep + 1;
        // setActiveStep(step);
        // setCurrent(questions[step]);
    };

    return (
        <div className={clsx(classes.root, className)}>
            <Typography variant={'h6'} className={classes.progress}>
                Question {activeStep + 1} / {questions?.length}
            </Typography>
            <div className={classes.container}>
                <Typography variant={'h3'} className={classes.question}>
                    {current.title}
                </Typography>
                <div className={classes.form}>
                    {current.type === 'noOptions' &&
                    <NoOptionQuestion
                        setAnswer={setAnswer}
                        isCorrect={correct?.isCorrect}
                        correct={correct?.answers as string}
                    />}
                    {current.type === 'singleOption' &&
                    <SingleOptionQuestion
                        setAnswer={setAnswer}
                        options={current.options}
                        isCorrect={correct?.isCorrect}
                        correct={correct?.answers as string[]}/>
                    }

                    {/*{current.type === 'noOptions' && (userAnswers && correctAnswers*/}
                    {/*        ? <InputAnswer userAnswer={userAnswers[0]} correctAnswer={correctAnswers[0]}/>*/}
                    {/*        : <InputQuestion setAnswer={value => setUserAnswers(value ? {[0]: value} : {})}/>*/}
                    {/*)}*/}

                    {/*{current.type === 'singleOption' &&*/}
                    {/*(userAnswers && correctAnswers*/}
                    {/*        ? <RadioAnswer*/}
                    {/*            userAnswer={userAnswers[0]}*/}
                    {/*            correctAnswer={correctAnswers[0]}*/}
                    {/*            answers={current.options}/>*/}
                    {/*        : <RadioQuestion*/}
                    {/*            setAnswer={value => setUserAnswers({[0]: value})}*/}
                    {/*            answers={current.options}/>*/}
                    {/*)}*/}

                    {/*{current.type === 'manyOptions' && (userAnswers && correctAnswers*/}
                    {/*        ? <CheckboxAnswer*/}
                    {/*            userAnswer={Object.values(userAnswers)}*/}
                    {/*            correctAnswer={Object.values(correctAnswers)}*/}
                    {/*            answers={current.options}/>*/}
                    {/*        : <CheckboxQuestion setAnswers={value => {*/}
                    {/*            const tmp: { [key: number]: string } = {};*/}
                    {/*            value.forEach((x, i) => tmp[i] = x);*/}
                    {/*            setUserAnswers(tmp);*/}
                    {/*        }} answers={current.options}/>*/}
                    {/*)}*/}

                    {answered
                        ? <LoadingButton
                            className={classes.button}
                            onClick={showNext}
                            isLoading={loading}>
                            Next
                        </LoadingButton>
                        : <LoadingButton
                            className={classes.button}
                            onClick={onAnswerClick}
                            disabled={!answer}
                            isLoading={loading}>
                            Answer
                        </LoadingButton>
                    }
                </div>
            </div>
        </div>
    );
};

export default QuizContainer;
