import {Divider, makeStyles} from '@material-ui/core';
import clsx from 'clsx';
import React from 'react';
import CoffeeToolbar from './components/CoffeeToolbar/CoffeeToolbar';

const useStyles = makeStyles((theme) => ({
    root: {
        display: 'flex',
        flexDirection: 'column',
        backgroundColor: theme.palette.common.white,
    },
}));

export interface CoffeeDetailsProps {
    className?: string;
}

const CoffeeDetails: React.FC<CoffeeDetailsProps> = (props) => {
    const {className, ...rest} = props;

    const classes = useStyles();

    return (
        <div
            {...rest}
            className={clsx(classes.root, className)}
        >
            <CoffeeToolbar/>
            <Divider />
        </div>
    );
};

export default CoffeeDetails;
