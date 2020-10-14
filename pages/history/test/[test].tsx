import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {GetServerSideProps, GetServerSidePropsContext, NextApiRequest, NextApiResponse, NextPage} from 'next';
import React, {useState} from 'react';
import TokenApi from 'lib/api/token';
import HistoryApi, {AnswerResult, HistoryTestModel, TestCheckedAnswerModel} from 'lib/api/history';
import useApi from 'lib/useApi';
import Countdown from 'components/Сountdown/Сountdown';
import QuizContainer, {Answer} from 'components/Quiz/QuizContainer';

const useStyles = makeStyles((theme) => ({
    root: {
        display: 'flex',
        flexDirection: 'column',
        // justifyContent: 'center',
        alignItems: 'center',
        height: '100%',
        width: '100%',
        padding: theme.spacing(5)
    }
}));

type Props = {
    articleId: string,
    test: HistoryTestModel
}

type TestView = 'Test' | 'Result' | 'Timeout';

const TestPage: NextPage<Props> = ({test}) => {
    const classes = useStyles();

    const [result, setResult] = useState<AnswerResult | null>(null);

    const [currentView, setCurrentView] = useState<TestView>('Test');

    const onAnswer = async (questionId: string, answer: string | string[]): Promise<Answer> => {
        try
        {
            const request = Array.isArray(answer)
                ? {answers: answer}
                : {answer};

            const {data} = await useApi<TestCheckedAnswerModel>('POST', HistoryApi.endpoints.checkTestAnswer(test.id, questionId), request);

            return {
                isCorrect: data.isCorrect,
                canReAnswer: !data.isCorrect,
                answers: data.answer || data.answers || ''
            };
        }
        catch (e)
        {
            return Promise.reject();
        }
    };

    return (
        <DefaultLayout title={'Questions'}>
            <div className={classes.root}>
                {currentView === 'Test' && <QuizContainer questions={test.questions} onAnswer={onAnswer}/>}
                {currentView === 'Result' && <pre>{JSON.stringify(result, null, 4)}</pre>}
                {currentView === 'Timeout' && <div>Timeout</div>}
                <Countdown
                    expiredAt={test.expiredAt}
                    onExpired={() => {
                        if (currentView === 'Test')
                            setCurrentView('Timeout');
                    }}
                    variant={'subtitle2'}
                    align={'center'}/>
            </div>
        </DefaultLayout>
        // <DefaultLayout title={'Questions'}>
        //     <div className={classes.root}>
        //         <Typography variant={'h6'} className={classes.progress}>
        //             Question {activeStep + 1} / {test.questions?.length}
        //         </Typography>
        //         {currentView === 'Test' &&
        //         <div className={classes.container}>
        //             <Typography variant={'h3'} className={classes.question}>
        //                 {current.title}
        //             </Typography>
        //             <form className={classes.form} onSubmit={handleSubmit}>
        //                 {current.type === 'noOptions' &&
        //                 (userAnswers && correctAnswers
        //                         ? <InputAnswer userAnswer={userAnswers[0]} correctAnswer={correctAnswers[0]}/>
        //                         : <InputQuestion setAnswer={value => setUserAnswers(value ? {[0]: value} : {})}/>
        //                 )}
        //
        //                 {current.type === 'singleOption' &&
        //                 (userAnswers && correctAnswers
        //                         ? <RadioAnswer
        //                             userAnswer={userAnswers[0]}
        //                             correctAnswer={correctAnswers[0]}
        //                             answers={current.options}/>
        //                         : <RadioQuestion
        //                             setAnswer={value => setUserAnswers({[0]: value})}
        //                             answers={current.options}/>
        //                 )}
        //
        //                 {current.type === 'manyOptions' && (userAnswers && correctAnswers
        //                         ? <CheckboxAnswer
        //                             userAnswer={Object.values(userAnswers)}
        //                             correctAnswer={Object.values(correctAnswers)}
        //                             answers={current.options}/>
        //                         : <CheckboxQuestion setAnswers={value => {
        //                             const tmp: { [key: number]: string } = {};
        //                             value.forEach((x, i) => tmp[i] = x);
        //                             setUserAnswers(tmp);
        //                         }} answers={current.options}/>
        //                 )}
        //
        //                 {isLoading
        //                     ? <CircularProgress size={24}/>
        //                     : answered
        //                         ? <Button
        //                             type={'button'}
        //                             variant={'contained'}
        //                             color={'primary'}
        //                             onClick={showNext}
        //                             className={classes.button}>
        //                             Next
        //                         </Button>
        //                         : <Button
        //                             type={'submit'}
        //                             variant={'contained'}
        //                             color={'primary'}
        //                             className={classes.button}
        //                             disabled={userAnswers === null}>
        //                             Answer
        //                         </Button>
        //                 }
        //             </form>
        //             <Countdown
        //                 variant={'subtitle2'}
        //                 align={'center'}
        //                 expiredAt={test.expiredAt}
        //                 onExpired={() => {
        //                     if (currentView === 'Test')
        //                         setCurrentView('Timeout');
        //                 }}/>
        //         </div>
        //         }
        //         {currentView === 'Result' &&
        //         <div className={classes.container}>
        //             <pre>{JSON.stringify(result, null, 4)}</pre>
        //         </div>
        //         }
        //     </div>
        // </DefaultLayout>
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
