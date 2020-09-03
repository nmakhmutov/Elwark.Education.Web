import React from 'react';
import {makeStyles} from '@material-ui/styles';
import {Button, FormControlLabel, Radio, RadioGroup, Theme} from '@material-ui/core';
import clsx from 'clsx';

const useStyles = makeStyles((theme: Theme) => ({
    root: {
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
    },
    button: {
        textAlign: 'center',
        display: 'block',
        margin: theme.spacing(3, 0),
    },
}));

type Props = {
    className?: string,
    answers: string[],
    handleAnswer: (value: string) => void
}

const RadioAnswer: React.FC<Props> = (props) => {
    const classes = useStyles();
    const {className, answers, handleAnswer} = props;
    const [value, setValue] = React.useState('');
    const [disabled, setDisabled] = React.useState(true);

    const handleRadioChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setValue((event.target as HTMLInputElement).value);
        setDisabled(false)
    };

    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        if (value) {
            handleAnswer(value);
        }
    }

    return (
        <form className={clsx(classes.root, className)} onSubmit={handleSubmit}>
            <RadioGroup aria-label="quiz" name="quiz" value={value} onChange={handleRadioChange}>
                {answers.map((x, i) => <FormControlLabel key={i} value={x} control={<Radio/>} label={x}/>)}
            </RadioGroup>
            <Button type={'submit'} variant={'contained'} color={'primary'} className={classes.button}
                    disabled={disabled}>
                Answer
            </Button>
        </form>
    )
}

export default RadioAnswer;
