import {CircularProgress, Typography} from '@material-ui/core';
import makeStyles from '@material-ui/core/styles/makeStyles';
import React from 'react';
import {LinearProgressProps} from '@material-ui/core/LinearProgress';
import {green, orange, purple, yellow} from '@material-ui/core/colors';
import clsx from 'clsx';

const useStyles = makeStyles((theme) => ({
    root: {
        display: 'flex',
        alignItems: 'center'
    },
    progress: {
        display: 'inline-flex',
        position: 'relative',
    },
    wrapper: {
        top: 0,
        left: 0,
        bottom: 0,
        right: 0,
        position: 'absolute',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center'
    },
    caption: {
        paddingLeft: theme.spacing(1)
    },
    bold: {
        fontWeight: 'bold'
    },
    green: {
        color: green.A700
    },
    yellow: {
        color: yellow['700']
    },
    orange: {
        color: orange.A700
    },
    purple: {
        color: purple['700']
    },
    primary: {
        color: theme.palette.primary.main
    }
}));

type Props = {
    className?: string;
    passed: number,
    total: number
}

const TopicProgress: React.FC<LinearProgressProps & Props> = (props) => {
    const {className, passed, total} = props;

    const classes = useStyles();
    const progress = passed * 100 / total;
    const getProgressColor = (value: number) => {
        if (value > 80)
            return classes.primary;

        if (value > 60)
            return classes.purple;

        if (value > 40)
            return classes.orange;

        if (value > 20)
            return classes.yellow;

        return classes.green;
    }

    return (
        <div className={clsx(classes.root, className)}>
            <div className={classes.progress}>
                <CircularProgress variant={'static'} value={progress} className={getProgressColor(progress)}/>
                <div className={classes.wrapper}>
                    <Typography variant={'caption'} component={'div'} color={'textSecondary'}>
                        {`${Math.round(progress)}%`}
                    </Typography>
                </div>
            </div>
            <div className={classes.caption}>
                <Typography variant={'subtitle2'} color={'textSecondary'} className={classes.bold}>
                    Progress
                </Typography>
                <Typography variant={'body2'} color={'textSecondary'}>
                    {passed} / {total}
                </Typography>
            </div>
        </div>
    );
};

export default TopicProgress;
