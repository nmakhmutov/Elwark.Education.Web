import React from 'react';
import {Checkbox, FormControlLabel, FormGroup} from '@material-ui/core';

type Props = {
    className?: string,
    answers: string[],
    setAnswers: (values: string[]) => void
}

const CheckboxAnswer: React.FC<Props> = ({answers, className, setAnswers}) => {
    const [state, setState] = React.useState(answers.map((x, i) => ({id: i.toString(), value: x, checked: false})));

    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        event.persist();

        setState(prevState => {
            const result = prevState.map(item => {
                if (item.id === event.target?.value)
                    item.checked = event.target.checked;

                return item;
            });

            setAnswers(result.filter(x => x.checked).map(x => x.value));
            return result;
        });
    };

    return (
        <FormGroup className={className}>
            {state.map(x =>
                <FormControlLabel
                    key={x.id}
                    label={x.value}
                    control={<Checkbox checked={x.checked} onChange={handleChange} value={x.id}/>
                    }
                />)}
        </FormGroup>
    )
}

export default CheckboxAnswer;
