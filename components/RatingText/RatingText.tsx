import {TypographyProps} from '@material-ui/core';
import Typography from '@material-ui/core/Typography';
import React from 'react';
import NumberFormat from 'react-number-format';
import {ratingColor} from 'utils';

export interface RatingProps extends TypographyProps {
    rating: number;
}

const RatingText: React.FC<RatingProps> = (props) => {
    const {rating, className, ...rest} = props;

    const color = ratingColor(rating);

    return (
        <Typography className={className} {...rest}>
            <NumberFormat style={{color}} value={rating} thousandSeparator={' '} displayType={'text'}/>
        </Typography>
    );
};

export default RatingText;
