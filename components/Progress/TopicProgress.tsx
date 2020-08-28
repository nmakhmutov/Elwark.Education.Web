import {Box, Typography} from '@material-ui/core';
import makeStyles from '@material-ui/core/styles/makeStyles';
import React from 'react';
import LinearProgress, {LinearProgressProps} from '@material-ui/core/LinearProgress';
import {blue, orange, yellow} from '@material-ui/core/colors';

const useStyles = makeStyles((theme) => ({
    blue: {
        backgroundColor: blue['400']
    },
    orange: {
        backgroundColor: orange['300']
    },
    yellow: {
        backgroundColor: yellow['500']
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
    const progress = props.passed * 100 / props.total;
    const getProgressColor = (value: number) => {
        if (value > 80)
            return classes.yellow;

        if (value > 60)
            return classes.orange;

        return classes.blue;
    }

    return (
        <Box display={'flex'} alignItems={'center'} className={className}>
            <Box width="100%" mr={1}>
                <LinearProgress
                    variant={'determinate'}
                    classes={{barColorPrimary: getProgressColor(progress)}}
                    value={progress} {...props} />
            </Box>
            <Box minWidth={45}>
                <Typography variant="body2" color="textSecondary">
                    {passed} / {total}
                </Typography>
            </Box>
        </Box>
    );
};

export default TopicProgress;
