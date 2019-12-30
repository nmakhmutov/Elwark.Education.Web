import {makeStyles} from '@material-ui/core';
import clsx from 'clsx';
import {NextPage} from 'next';
import React from 'react';
import {ImageResolution, Storage} from '../../api';
import {CoffeeCategoryModel} from '../../api/bff/types';
import {DefaultLayout} from '../../layouts';
import {CoffeeDetails, CoffeeList, CoffeePlaceholder} from './components';

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
    list: CoffeeCategoryModel[];
}

const Coffee: NextPage<CoffeeProps> = (props) => {
    const classes = useStyles();
    const {id, list} = props;

    return (
        <DefaultLayout title={'Coffee'}>
            <div className={clsx({
                [classes.root]: true,
                [classes.open]: id !== undefined,
            })}>
                <CoffeeList selected={id} list={list} className={classes.list}/>
                {id ? (<CoffeeDetails className={classes.details}/>)
                    : (<CoffeePlaceholder className={classes.placeholder}/>)}
            </div>
        </DefaultLayout>
    );
};

Coffee.getInitialProps = async ({query}) => {
    const id = query.id ? Number(query.id) : undefined;

    return {
        id,
        list: [
            {id: 1, name: 'Ristretto', image: Storage.Images.RandomByImageResolution(ImageResolution.VGA)},
            {id: 2, name: 'Espresso', image: Storage.Images.RandomByImageResolution(ImageResolution.SVGA)},
            {id: 3, name: 'Latte', image: Storage.Images.RandomByImageResolution(ImageResolution.SVGA)},
            {id: 4, name: 'Cappuccino', image: Storage.Images.RandomByImageResolution(ImageResolution.XGA)},
            {id: 5, name: 'Flat white', description: 'fvee verbovwnret en ow4ntgiwotng [wtn  w tgwrtgrtgvrt'},
        ],
    } as CoffeeProps;
};

export default Coffee;
