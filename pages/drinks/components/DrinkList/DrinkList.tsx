import {Divider, IconButton, Input, List, makeStyles, Toolbar, Tooltip} from '@material-ui/core';
import SearchIcon from '@material-ui/icons/Search';
import {CoffeeCategoryModel} from 'api/bff/types';
import clsx from 'clsx';
import {NextRouter, useRouter} from 'next/router';
import React from 'react';
import {Links} from 'utils';
import {DrinkListItem} from './components';

const useStyles = makeStyles((theme) => ({
    root: {
        backgroundColor: theme.palette.common.white,
    },
    searchInput: {
        flexGrow: 1,
    },
}));

export interface CoffeeListProps {
    className?: string;
    list: CoffeeCategoryModel[];
}

const Drinks: React.FC<{ list: CoffeeCategoryModel[], depth: number, router: NextRouter }> = (props) => {
    const {list, depth, router} = props;

    return (
        <List disablePadding={true}>
            {list.reduce((items: any[], category: CoffeeCategoryModel) =>
                reduceChildRoutes({router, items, category, depth}), [])}
        </List>
    );
};

const reduceChildRoutes = (props: {
    router: NextRouter, items: any[], category: CoffeeCategoryModel, depth: number,
}) => {
    const {router, items, category, depth} = props;
    const open = +router.query.id === category.item.categoryId;

    if (category.children.length > 0) {
        items.push(
            <DrinkListItem
                open={open}
                depth={depth}
                image={category.item.image}
                key={category.item.categoryId}
                title={category.item.name}
            >
                <Drinks depth={depth + 1} list={category.children} router={router}/>
            </DrinkListItem>,
        );
    } else {
        items.push(
            <DrinkListItem
                open={false}
                depth={depth}
                href={Links.DrinkItem(category.item.categoryId)}
                image={category.item.image}
                key={category.item.categoryId}
                title={category.item.name}
            />,
        );
    }

    return items;
};

const DrinkList: React.FC<CoffeeListProps> = (props) => {
    const classes = useStyles();
    const router = useRouter();
    const {list, className} = props;

    return (
        <div className={clsx(classes.root, className)}>
            <Toolbar>
                <Input className={classes.searchInput} disableUnderline={true} placeholder={'Search coffee'}/>
                <Tooltip title={'Search'}>
                    <IconButton edge={'end'}>
                        <SearchIcon/>
                    </IconButton>
                </Tooltip>
            </Toolbar>
            <Divider/>
            <Drinks list={list} depth={0} router={router}/>
        </div>
    );
};

export default DrinkList;
