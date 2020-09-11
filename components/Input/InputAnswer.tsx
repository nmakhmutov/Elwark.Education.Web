import React from 'react';
import {TextField} from '@material-ui/core';

type Props = {
    className?: string,
    setAnswer: (value: string) => void
}

const InputAnswer: React.FC<Props> = ({className, setAnswer}) => {
    return (
        <TextField
            className={className}
            variant={'standard'}
            autoFocus={true}
            onKeyUp={event => setAnswer((event.target as HTMLInputElement).value)}/>
    )
}

export default InputAnswer;
