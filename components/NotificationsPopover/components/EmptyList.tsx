import {Typography} from '@material-ui/core';
import {makeStyles} from '@material-ui/styles';
import clsx from 'clsx';
import React from 'react';

const useStyles = makeStyles((theme) => ({
    root: {
        textAlign: 'center',
        padding: theme.spacing(3)
    },
    image: {
        height: 240,
        // backgroundImage: 'url("/images/undraw_empty_xct9.svg")',
        backgroundPositionX: 'right',
        backgroundPositionY: 'center',
        backgroundRepeat: 'no-repeat',
        backgroundSize: 'cover'
    }
}));

type Props = {
    className?: string;
}
const EmptyList: React.FC<Props> = (props) => {
    const {className} = props;

    const classes = useStyles();

    return (
        <div className={clsx(classes.root, className)}>
            <div className={classes.image}/>
            <Typography variant="h4">There's nothing here...</Typography>
        </div>
    );
};

export default EmptyList;
