import React from 'react';
import {TextField, Typography, withStyles} from '@material-ui/core';
import {green} from '@material-ui/core/colors';

type Props = {
    className?: string,
    userAnswer: string,
    correctAnswer: string,
}

const CorrectAnswer = withStyles({
    root: {
        color: green['700'],
        marginTop: 16
    }
})(Typography);

const InputAnswer: React.FC<Props> = ({className, userAnswer, correctAnswer}) => {
    return (
        <>
            <TextField
                className={className}
                variant={'standard'}
                value={userAnswer}
                error={userAnswer !== correctAnswer}
                disabled={true}/>
            <CorrectAnswer>{correctAnswer}</CorrectAnswer>
        </>
    );
};

export default InputAnswer;
