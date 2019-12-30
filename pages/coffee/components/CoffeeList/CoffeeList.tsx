import {Divider, IconButton, Input, List, makeStyles, Toolbar, Tooltip} from '@material-ui/core';
import SearchIcon from '@material-ui/icons/Search';
import clsx from 'clsx';
import React from 'react';
import {ImageResolution, Storage} from '../../../../api';
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
}

const CoffeeList: React.FC<CoffeeListProps> = (props) => {
    const classes = useStyles();
    const {selected, className, ...rest} = props;

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
            <List disablePadding>
                <CoffeeListItem
                    id={1}
                    active={selected === 1}
                    avatar={Storage.Images.RandomByImageResolution(ImageResolution.VGA)}
                    name={'Ristretto'}/>

                <CoffeeListItem
                    id={2}
                    active={selected === 2}
                    avatar={Storage.Images.RandomByImageResolution(ImageResolution.VGA)}
                    name={'Espresso'}/>

                <CoffeeListItem
                    id={3}
                    active={selected === 3}
                    avatar={Storage.Images.RandomByImageResolution(ImageResolution.VGA)}
                    name={'Latte'}/>

                <CoffeeListItem
                    id={4}
                    active={selected === 4}
                    avatar={Storage.Images.RandomByImageResolution(ImageResolution.VGA)}
                    name={'Cappuccino'}/>
                {/*{conversations.map((conversation, i) => (*/}
                {/*    <ConversationListItem*/}
                {/*        active={conversation.id === selectedConversation}*/}
                {/*        conversation={conversation}*/}
                {/*        divider={i < conversations.length - 1}*/}
                {/*        key={conversation.id}*/}
                {/*    />*/}
                {/*))}*/}
            </List>
        </div>
    );
};

export default CoffeeList;
