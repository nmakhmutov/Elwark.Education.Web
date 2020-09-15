import React from 'react';
import {Checkbox, FormControlLabel, FormGroup, Typography, withStyles} from '@material-ui/core';
import {green, red} from '@material-ui/core/colors';

type Props = {
    className?: string,
    userAnswer: string[],
    correctAnswer: string[],
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

const CheckboxAnswer: React.FC<Props> = ({className, answers, userAnswer, correctAnswer}) => {
    const label = (answer: string, isCorrectAnswer: boolean, isUserAnswer: boolean) => {
        if (isCorrectAnswer)
            return <CorrectAnswerLabel>{answer}</CorrectAnswerLabel>;

        if (!isCorrectAnswer && isUserAnswer)
            return <IncorrectAnswerLabel>{answer}</IncorrectAnswerLabel>;

        return <Typography color={'textSecondary'}>{answer}</Typography>;
    };

    return (
        <FormGroup className={className}>
            {Object.entries(answers).map(([key, answer]) => {
                const isUserAnswer = userAnswer.includes(answer);
                const isCorrectAnswer = correctAnswer.includes(answer);

                return <FormControlLabel
                    key={key}
                    label={label(answer, isCorrectAnswer, isUserAnswer)}
                    control={<Checkbox checked={isUserAnswer} disabled={true}/>}
                />;
            })}
        </FormGroup>
    );
};

export default CheckboxAnswer;
