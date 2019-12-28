import React from 'react';
import NumberFormat from 'react-number-format';

export interface RatingProps {
    className?: string;
    value: number;
}

const VotersText: React.FC<RatingProps> = (props) => {
    const {value, className, ...rest} = props;

    return (
        <NumberFormat {...rest}
                      className={className}
                      value={value}
                      thousandSeparator={' '}
                      displayType={'text'}/>
    );
};

export default VotersText;
