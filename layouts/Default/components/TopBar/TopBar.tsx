import {colors, Toolbar} from '@material-ui/core';
import AppBar from '@material-ui/core/AppBar';
import Button from '@material-ui/core/Button';
import ClickAwayListener from '@material-ui/core/ClickAwayListener';
import Hidden from '@material-ui/core/Hidden';
import IconButton from '@material-ui/core/IconButton';
import Input from '@material-ui/core/Input';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import Paper from '@material-ui/core/Paper';
import Popper from '@material-ui/core/Popper';
import makeStyles from '@material-ui/core/styles/makeStyles';
import InputIcon from '@material-ui/icons/Input';
import MenuIcon from '@material-ui/icons/Menu';
import SearchIcon from '@material-ui/icons/Search';
import {Storage} from 'api';
import clsx from 'clsx';
import {Link} from 'components';
import React, {MouseEventHandler, useRef, useState} from 'react';
import {Links} from 'utils';

const useStyles = makeStyles((theme) => ({
    root: {
        boxShadow: 'none',
    },
    flexGrow: {
        flexGrow: 1,
    },
    search: {
        backgroundColor: 'rgba(255,255,255, 0.1)',
        borderRadius: 4,
        flexBasis: 300,
        height: 36,
        padding: theme.spacing(0, 2),
        display: 'flex',
        alignItems: 'center',
    },
    searchIcon: {
        marginRight: theme.spacing(2),
        color: 'inherit',
    },
    searchInput: {
        'flexGrow': 1,
        'color': 'inherit',
        '& input::placeholder': {
            opacity: 1,
            color: 'inherit',
        },
    },
    searchPopper: {
        zIndex: theme.zIndex.appBar + 100,
    },
    searchPopperContent: {
        marginTop: theme.spacing(1),
    },
    trialButton: {
        'marginLeft': theme.spacing(2),
        'color': theme.palette.common.white,
        'backgroundColor': colors.green[600],
        '&:hover': {
            backgroundColor: colors.green[900],
        },
    },
    trialIcon: {
        marginRight: theme.spacing(1),
    },
    notificationsButton: {
        marginLeft: theme.spacing(1),
    },
    notificationsBadge: {
        backgroundColor: colors.orange[600],
    },
    logoutButton: {
        marginLeft: theme.spacing(1),
    },
    logoutIcon: {
        marginRight: theme.spacing(1),
    },
}));

interface TopBarProps {
    className?: string;
    onOpenNavBarMobile: MouseEventHandler;
}

const TopBar: React.FC<TopBarProps> = (props) => {
    const {onOpenNavBarMobile, className, ...rest} = props;

    const classes = useStyles();
    const searchRef = useRef(null);
    const [openSearchPopover, setOpenSearchPopover] = useState(false);
    const [searchValue, setSearchValue] = useState('');

    const handleSearchChange = (event: React.ChangeEvent<HTMLTextAreaElement | HTMLInputElement>) => {
        setSearchValue(event.target.value);

        if (event.target.value) {
            if (!openSearchPopover) {
                setOpenSearchPopover(true);
            }
        } else {
            setOpenSearchPopover(false);
        }
    };

    const handleSearchPopverClose = () => {
        setOpenSearchPopover(false);
    };

    const popularSearches = [
        'Cappuccino',
        'Latte',
        'Ristretto',
        'Flat white',
        'Lungo',
    ];

    return (
        <AppBar
            {...rest}
            className={clsx(classes.root, className)}
            color="primary"
        >
            <Toolbar>
                <Link href={Links.Home}>
                    <img
                        alt="Logo"
                        src={Storage.Static.Icons.Elwark.White.Size48x48}
                    />
                </Link>
                <div className={classes.flexGrow} />
                <Hidden smDown>
                    <div
                        className={classes.search}
                        ref={searchRef}
                    >
                        <SearchIcon className={classes.searchIcon} />
                        <Input
                            className={classes.searchInput}
                            disableUnderline
                            onChange={handleSearchChange}
                            placeholder="Search"
                            value={searchValue}
                        />
                    </div>
                    <Popper
                        anchorEl={searchRef.current}
                        className={classes.searchPopper}
                        open={openSearchPopover}
                        transition
                    >
                        <ClickAwayListener onClickAway={handleSearchPopverClose}>
                            <Paper
                                className={classes.searchPopperContent}
                                elevation={3}
                            >
                                <List>
                                    {popularSearches.map((search) => (
                                        <ListItem
                                            button
                                            key={search}
                                            onClick={handleSearchPopverClose}
                                        >
                                            <ListItemIcon>
                                                <SearchIcon />
                                            </ListItemIcon>
                                            <ListItemText primary={search} />
                                        </ListItem>
                                    ))}
                                </List>
                            </Paper>
                        </ClickAwayListener>
                    </Popper>
                </Hidden>
                <Hidden mdDown>
                    <Button
                        className={classes.logoutButton}
                        color="inherit"
                    >
                        <InputIcon className={classes.logoutIcon} />
                        Sign out
                    </Button>
                </Hidden>
                <Hidden lgUp>
                    <IconButton
                        color="inherit"
                        onClick={onOpenNavBarMobile}
                    >
                        <MenuIcon />
                    </IconButton>
                </Hidden>
            </Toolbar>
        </AppBar>
    );
};

export default TopBar;
