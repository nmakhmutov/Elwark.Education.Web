import {TypographyProps} from '@material-ui/core';
import Typography from '@material-ui/core/Typography';
import React from 'react';
import NumberFormat from 'react-number-format';

export interface VotersProps extends TypographyProps {
    voters: number;
}

const VotersText: React.FC<VotersProps> = (props) => {
    const {voters, className, ...rest} = props;

    return (
        <Typography {...rest}>
            <NumberFormat value={voters} thousandSeparator={' '} displayType={'text'}/>
        </Typography>
    );
};

export default VotersText;
