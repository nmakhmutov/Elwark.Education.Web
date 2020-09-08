import React from 'react';
import {FormControlLabel, Radio, RadioGroup} from '@material-ui/core';

type Props = {
    className?: string,
    answers: string[],
    setAnswer: (value: string) => void
}

const RadioAnswer: React.FC<Props> = ({className, answers, setAnswer}) => {
    const [value, setValue] = React.useState('');

    const handleRadioChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const answer = (event.target as HTMLInputElement).value;
        setValue(answer);
        setAnswer(answer);
    };

    return (
        <RadioGroup className={className} name="quiz" value={value} onChange={handleRadioChange}>
            {answers.map((x, i) => <FormControlLabel key={i} value={x} control={<Radio/>} label={x}/>)}
        </RadioGroup>
    )
}

export default RadioAnswer;
