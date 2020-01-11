import React from 'react';
import NumberFormat from 'react-number-format';
import {ratingColor} from 'utils';

export interface RatingProps {
    className?: string;
    value: number;
}

const RatingText: React.FC<RatingProps> = (props) => {
    const {value, className, ...rest} = props;

    const color = ratingColor(value);

    return (
        <NumberFormat {...rest}
                      className={className}
                      style={{color}}
                      value={value}
                      thousandSeparator={' '}
                      displayType={'text'}/>
    );
};

export default RatingText;
