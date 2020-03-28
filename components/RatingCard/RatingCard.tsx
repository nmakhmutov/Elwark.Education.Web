import {Avatar, Card, makeStyles, Typography} from '@material-ui/core';
import ThumbsUpDownIcon from '@material-ui/icons/ThumbsUpDown';
import clsx from 'clsx';
import {RatingText} from 'components';
import React from 'react';
import {ratingColor} from 'utils';

const useStyles = makeStyles((theme) => ({
    root: {
        padding: theme.spacing(3),
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'space-between',
    },
    details: {
        display: 'flex',
        alignItems: 'center',
        flexWrap: 'wrap',
    },
    label: {
        marginLeft: theme.spacing(1),
    },
    avatar: {
        height: 48,
        width: 48,
    },
}));

export interface RatingCardProps {
    className?: string;
    title: string;
    rating: number;
}

const RatingCard: React.FC<RatingCardProps> = (props) => {
    const {className, rating, title, ...rest} = props;
    const classes = useStyles();
    const color = ratingColor(rating);

    return (
        <Card {...rest} className={clsx(classes.root, className)}>
            <div>
                <Typography component="h3" gutterBottom={true} variant={'overline'}>
                    {title}
                </Typography>
                <div className={classes.details}>
                    <Typography variant="h3">
                        <RatingText rating={rating} variant={'h4'}/>
                    </Typography>
                </div>
            </div>
            <Avatar className={classes.avatar} style={{backgroundColor: color}}>
                <ThumbsUpDownIcon/>
            </Avatar>
        </Card>
    );
};

export default RatingCard;
