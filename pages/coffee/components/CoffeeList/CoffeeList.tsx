import {Divider, IconButton, Input, List, makeStyles, Toolbar, Tooltip} from '@material-ui/core';
import SearchIcon from '@material-ui/icons/Search';
import clsx from 'clsx';
import React from 'react';
import {CoffeeCategoryModel} from 'api/bff/types';
import {CoffeeListItem} from './components';

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
    selected?: number;
    list: CoffeeCategoryModel[];
}

const CoffeeList: React.FC<CoffeeListProps> = (props) => {
    const classes = useStyles();
    const {list, selected, className, ...rest} = props;

    return (
        <div
            {...rest}
            className={clsx(classes.root, className)}
        >
            <Toolbar>
                <Input className={classes.searchInput} disableUnderline={true} placeholder="Search coffee"/>
                <Tooltip title="Search">
                    <IconButton edge="end">
                        <SearchIcon/>
                    </IconButton>
                </Tooltip>
            </Toolbar>
            <Divider/>
            <List disablePadding={true}>
                {list.map((value, index) => (
                    <CoffeeListItem key={index}
                        active={selected === value.id}
                        category={value}/>
                ))}
            </List>
        </div>
    );
};

export default CoffeeList;
