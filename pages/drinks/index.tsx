import {makeStyles} from '@material-ui/core';
import clsx from 'clsx';
import DefaultLayout from 'components/layout/Default/Layout';
import {NextPage} from 'next';
import React from 'react';
import {DrinkDetails, DrinkList, DrinkPlaceholder} from './components';

const useStyles = makeStyles((theme) => ({
    root: {
        'height': '100%',
        'cursor': 'pointer',
        'display': 'flex',
        'overflow': 'hidden',
        '@media (max-width: 863px)': {
            '& $list, & $details': {
                flexBasis: '100%',
                width: '100%',
                maxWidth: 'none',
                flexShrink: 0,
                transform: 'translateX(0)',
            },
        },
    },
    open: {
        '@media (max-width: 863px)': {
            '& $list, & $details': {
                transform: 'translateX(-100%)',
            },
        },
    },
    list: {
        'overflow-y': 'scroll',
        'width': 300,
        'flexBasis': 300,
        'flexShrink': 0,
        '@media (min-width: 864px)': {
            borderRight: `1px solid ${theme.palette.divider}`,
        },
    },
    details: {
        flexGrow: 1,
    },
    placeholder: {
        flexGrow: 1,
    },
}));

export interface CoffeeProps {
    id?: number;
}

const Drinks: NextPage<CoffeeProps> = (props) => {
    const classes = useStyles();
    const {id} = props;

    return (
        <DefaultLayout title={'Coffee'}>
            <div className={clsx({
                [classes.root]: true,
                [classes.open]: id !== undefined,
            })}>
                <DrinkList list={[]} className={classes.list}/>
                {id ? (<DrinkDetails className={classes.details}/>)
                    : (<DrinkPlaceholder className={classes.placeholder}/>)}
            </div>
        </DefaultLayout>
    );
};

export default Drinks;
