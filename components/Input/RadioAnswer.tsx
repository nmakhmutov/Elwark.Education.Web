import React from 'react';
import {FormControlLabel, Radio, RadioGroup, Typography, withStyles} from '@material-ui/core';
import {green, red} from '@material-ui/core/colors';

type Props = {
    className?: string,
    userAnswer: string,
    correctAnswer: string,
    answers: { [key: number]: string }
}
const CorrectAnswerLabel = withStyles({
    root: {
        color: green['700']
    }
})(Typography);

const IncorrectAnswerLabel = withStyles({
    root: {
        color: red['700']
    }
})(Typography);

const RadioAnswer: React.FC<Props> = ({className, userAnswer, correctAnswer, answers}) => {

    return (
        <RadioGroup className={className} name="quiz">
            {Object.entries(answers)
            .map(([key, answer]) => {
                const label = () => {
                    if (answer === correctAnswer)
                        return <CorrectAnswerLabel>{answer}</CorrectAnswerLabel>;

                    if (answer !== correctAnswer && userAnswer === answer)
                        return <IncorrectAnswerLabel>{answer}</IncorrectAnswerLabel>;

                    return <Typography color={'textSecondary'}>{answer}</Typography>;
                };

                return <FormControlLabel
                    key={key}
                    value={answer}
                    control={<Radio checked={answer === userAnswer}/>}
                    label={label()}
                    disabled={true}/>;
            }
            )}
        </RadioGroup>
    );
};

export default RadioAnswer;
