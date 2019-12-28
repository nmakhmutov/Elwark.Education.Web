import {colors} from '@material-ui/core';
import React from 'react';
import NumberFormat from 'react-number-format';

export interface RatingProps {
    className?: string;
    value: number;
}

const RatingText: React.FC<RatingProps> = (props) => {
    const {value, className, ...rest} = props;

    const color = (rating: number) => {
        if (rating > 90) {
            return colors.green.A400;
        }
        if (rating > 80) {
            return colors.green['700'];
        }
        if (rating > 70) {
            return colors.lightGreen['700'];
        }
        if (rating > 60) {
            return colors.yellow['700'];
        }
        if (rating > 50) {
            return colors.yellow['800'];
        }
        if (rating > 40) {
            return colors.orange['700'];
        }
        if (rating > 30) {
            return colors.deepOrange.A400;
        }
        if (rating > 20) {
            return colors.deepOrange['500'];
        }
        if (rating > 10) {
            return colors.deepOrange['700'];
        }

        return colors.deepOrange.A700;
    };

    return (
        <NumberFormat {...rest}
                      className={className}
                      style={{color: color(value)}}
                      value={value}
                      thousandSeparator={' '}
                      displayType={'text'}/>
    );
};

export default RatingText;
