import React from 'react';
import {FormControlLabel, Radio, RadioGroup} from '@material-ui/core';

type Props = {
    className?: string,
    answers: { [key: number]: string },
    setAnswer: (value: string) => void
}

const RadioQuestion: React.FC<Props> = ({className, answers, setAnswer}) => {
    const [value, setValue] = React.useState('');

    const handleRadioChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const answer = (event.target as HTMLInputElement).value;
        setValue(answer);
        setAnswer(answer);
    };

    return (
        <RadioGroup className={className} name="quiz" value={value} onChange={handleRadioChange}>
            {Object.entries(answers).map(([key, answer]) =>
                <FormControlLabel key={key} value={answer} control={<Radio/>} label={answer}/>)}
        </RadioGroup>
    );
};

export default RadioQuestion;
