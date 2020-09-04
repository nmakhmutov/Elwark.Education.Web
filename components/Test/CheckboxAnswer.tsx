import React from 'react';
import {makeStyles} from '@material-ui/styles';
import {Button, Checkbox, FormControlLabel, FormGroup, Theme} from '@material-ui/core';
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
    handleAnswer: (values: string[]) => void
}

const CheckboxAnswer: React.FC<Props> = ({answers, className, handleAnswer}) => {
    const classes = useStyles();
    const [state, setState] = React.useState(answers.map((x, i) => ({id: i.toString(), value: x, checked: false})));
    const [disabled, setDisabled] = React.useState(true);

    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        event.persist()
        setState(prevState => prevState.map(item => {
            if (item.id === event.target?.value)
                item.checked = event.target.checked;
            return item;
        }));

        setDisabled(state.filter(x => x.checked).length === 0);
    };

    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        handleAnswer(state.filter(x => x.checked).map(x => x.value))
    }

    return (
        <form className={clsx(classes.root, className)} onSubmit={handleSubmit}>
            <FormGroup>
                {state.map((x) =>
                    <FormControlLabel key={x.id} label={x.value}
                                      control={<Checkbox checked={x.checked} onChange={handleChange} value={x.id}/>}
                    />)}
            </FormGroup>
            <Button type={'submit'} variant={'contained'} color={'primary'} className={classes.button}
                    disabled={disabled}>
                Answer
            </Button>
        </form>
    )
}

export default CheckboxAnswer;
