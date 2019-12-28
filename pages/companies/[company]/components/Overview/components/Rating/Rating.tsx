import {Card, Grid, makeStyles, Typography} from '@material-ui/core';
import clsx from 'clsx';
import React from 'react';
import {RatingText, VotersText} from '../../../../../../../components';

const useStyles = makeStyles((theme) => ({
    root: {},
    content: {
        padding: 0,
    },
    item: {
        padding: theme.spacing(3),
        textAlign: 'center',
        [theme.breakpoints.up('md')]: {
            '&:not(:last-of-type)': {
                borderRight: `1px solid ${theme.palette.divider}`,
            },
        },
        [theme.breakpoints.down('sm')]: {
            '&:not(:last-of-type)': {
                borderBottom: `1px solid ${theme.palette.divider}`,
            },
        },
    },
    titleWrapper: {
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
    },
    label: {
        marginLeft: theme.spacing(1),
    },
    overline: {
        marginTop: theme.spacing(1),
    },
}));

export interface RatingProps {
    className?: string;
    rating: { value: number, voters: number };
}

const Rating: React.FC<RatingProps> = (props) => {
    const {className, rating, ...rest} = props;
    const classes = useStyles();

    return (
        <Card
            {...rest}
            className={clsx(classes.root, className)}
        >
            <Grid alignItems="center" container justify="space-between">
                <Grid className={classes.item} item={true} sm={6} xs={12}>
                    <Typography variant="h2">
                        <RatingText value={rating.value}/>
                    </Typography>
                    <Typography className={classes.overline} variant="overline">
                        Total rating
                    </Typography>
                </Grid>
                <Grid className={classes.item} item={true} sm={6} xs={12}>
                    <Typography variant="h2">
                        <VotersText value={rating.voters}/>
                    </Typography>
                    <Typography className={classes.overline} variant="overline">
                        Total voters
                    </Typography>
                </Grid>
            </Grid>
        </Card>
    );
};

export default Rating;
