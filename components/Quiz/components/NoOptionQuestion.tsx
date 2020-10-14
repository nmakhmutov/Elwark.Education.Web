import {TextField, Typography, withStyles} from '@material-ui/core';
import React from 'react';
import {green} from '@material-ui/core/colors';

type Props = {
    className?: string,
    isCorrect?: boolean,
    correct?: string,
    setAnswer: (value: string) => void
}

const CorrectAnswer = withStyles({
    root: {
        color: green['700'],
        marginTop: 16
    }
})(Typography);

const NoOptionQuestion: React.FC<Props> = (props) => {
    const {className, setAnswer, isCorrect, correct} = props;

    return (
        <div>
            <TextField
                className={className}
                variant={'standard'}
                autoFocus={true}
                error={isCorrect !== undefined && !isCorrect}
                onKeyUp={event => {
                    const val = (event.target as HTMLInputElement).value;
                    setAnswer(val);
                }}
            />
            {correct && <CorrectAnswer>{correct}</CorrectAnswer>}
        </div>
    );
};

export default NoOptionQuestion;
