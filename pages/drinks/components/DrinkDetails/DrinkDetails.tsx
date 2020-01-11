import {Divider, makeStyles} from '@material-ui/core';
import clsx from 'clsx';
import React from 'react';
import {DrinkToolbar} from './components';

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

const DrinkDetails: React.FC<CoffeeDetailsProps> = (props) => {
    const {className, ...rest} = props;

    const classes = useStyles();

    return (
        <div
            {...rest}
            className={clsx(classes.root, className)}
        >
            <DrinkToolbar/>
            <Divider/>
        </div>
    );
};

export default DrinkDetails;
