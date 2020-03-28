import {Avatar, Card, makeStyles, Typography} from '@material-ui/core';
import PeopleIcon from '@material-ui/icons/People';
import clsx from 'clsx';
import {VotersText} from 'components';
import React from 'react';

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
        backgroundColor: theme.palette.primary.main,
        height: 48,
        width: 48,
    },
}));

export interface VotersCardProps {
    className?: string;
    title: string;
    voters: number;
}

const VotersCard: React.FC<VotersCardProps> = (props) => {
    const {className, voters, title, ...rest} = props;
    const classes = useStyles();

    return (
        <Card {...rest} className={clsx(classes.root, className)}>
            <div>
                <Typography component="h3" gutterBottom variant="overline">
                    {title}
                </Typography>
                <div className={classes.details}>
                    <Typography variant="h3">
                        <VotersText voters={voters} variant={'h4'}/>
                    </Typography>
                </div>
            </div>
            <Avatar className={classes.avatar}>
                <PeopleIcon/>
            </Avatar>
        </Card>
    );
};

export default VotersCard;
