import {FormControlLabel, Radio, RadioGroup, Typography, withStyles} from '@material-ui/core';
import React from 'react';
import {green} from '@material-ui/core/colors';

type Props = {
    className?: string,
    isCorrect?: boolean,
    correct?: string[],
    options: string[]
    setAnswer: (value: string) => void
}

const CorrectAnswer = withStyles({
    root: {
        color: green['700'],
        marginTop: 16
    }
})(Typography);

const SingleOptionQuestion: React.FC<Props> = (props) => {
    const {className, setAnswer, isCorrect, correct, options} = props;
    const [value, setValue] = React.useState('');

    const handleRadioChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const answer = (event.target as HTMLInputElement).value;
        setValue(answer);
        setAnswer(answer);
    };

    return (
        <div>
            <RadioGroup className={className} name="quiz" value={value} onChange={handleRadioChange}>
                {options.map((answer, index) =>
                    <FormControlLabel key={index} value={answer} control={<Radio/>} label={answer}/>)}
            </RadioGroup>
        </div>
    );
};

export default SingleOptionQuestion;
