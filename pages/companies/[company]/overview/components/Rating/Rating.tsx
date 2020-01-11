import {Grid, makeStyles} from '@material-ui/core';
import clsx from 'clsx';
import {RatingCard, VotersCard} from 'components';
import React from 'react';

const useStyles = makeStyles((theme) => ({
    root: {},
}));

export interface RatingProps {
    className?: string;
    rating: { value: number, voters: number };
}

const Rating: React.FC<RatingProps> = (props) => {
    const {className, rating, ...rest} = props;
    const classes = useStyles();

    return (
        <Grid {...rest} className={clsx(classes.root, className)} container={true} spacing={3}>
            <Grid item={true} sm={6} xs={12}>
                <RatingCard title={'Total rating'} rating={rating.value}/>
            </Grid>
            <Grid item={true} sm={6} xs={12}>
                <VotersCard title={'Total voters'} voters={rating.voters}/>
            </Grid>
        </Grid>
    );
};

export default Rating;
