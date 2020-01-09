import {
    IconButton,
    Input,
    ListItemIcon,
    ListItemText,
    makeStyles,
    Menu,
    MenuItem,
    Paper,
    Toolbar,
    Tooltip,
    Typography,
} from '@material-ui/core';
import ArchiveIcon from '@material-ui/icons/ArchiveOutlined';
import BlockIcon from '@material-ui/icons/Block';
import DeleteIcon from '@material-ui/icons/DeleteOutlined';
import KeyboardBackspaceIcon from '@material-ui/icons/KeyboardBackspace';
import MoreIcon from '@material-ui/icons/MoreVert';
import NotificationsOffIcon from '@material-ui/icons/NotificationsOffOutlined';
import SearchIcon from '@material-ui/icons/Search';
import clsx from 'clsx';
import {Link} from 'components';
import React, {useRef, useState} from 'react';
import {Links} from 'utils';

const useStyles = makeStyles((theme) => ({
    root: {
        backgroundColor: theme.palette.common.white,
    },
    backButton: {
        'marginRight': theme.spacing(2),
        '@media (min-width: 864px)': {
            display: 'none',
        },
    },
    user: {
        flexShrink: 0,
        flexGrow: 1,
    },
    activity: {
        display: 'flex',
        alignItems: 'center',
    },
    statusBullet: {
        marginRight: theme.spacing(1),
    },
    search: {
        height: 42,
        padding: theme.spacing(0, 2),
        display: 'flex',
        alignItems: 'center',
        flexBasis: 300,
        marginLeft: 'auto',
        [theme.breakpoints.down('sm')]: {
            flex: '1 1 auto',
        },
    },
    searchIcon: {
        marginRight: theme.spacing(2),
        color: theme.palette.icon,
    },
    searchInput: {
        flexGrow: 1,
    },
}));

export interface CoffeeToolbarProps {
    className?: string;
}

const CoffeeToolbar: React.FC<CoffeeToolbarProps> = (props) => {
    const {className, ...rest} = props;

    const classes = useStyles();
    const moreRef = useRef(null);
    const [openMenu, setOpenMenu] = useState(false);

    const handleMenuOpen = () => {
        setOpenMenu(true);
    };

    const handleMenuClose = () => {
        setOpenMenu(false);
    };

    return (
        <Toolbar
            {...rest}
            className={clsx(classes.root, className)}
        >
            <Tooltip title="Back">
                <IconButton
                    className={classes.backButton}
                    component={Link}
                    edge="start"
                    href={Links.Coffee}
                >
                    <KeyboardBackspaceIcon/>
                </IconButton>
            </Tooltip>
            <div className={classes.user}>
                <Typography variant="h6">NAME</Typography>
                <div className={classes.activity}>
                    ACTIVE
                </div>
            </div>
            <Paper
                className={classes.search}
                elevation={1}
            >
                <SearchIcon className={classes.searchIcon}/>
                <Input
                    className={classes.searchInput}
                    disableUnderline
                    placeholder="Search email"
                />
            </Paper>
            <Tooltip title="More options">
                <IconButton onClick={handleMenuOpen} ref={moreRef}>
                    <MoreIcon/>
                </IconButton>
            </Tooltip>
            <Menu
                anchorEl={moreRef.current}
                keepMounted
                onClose={handleMenuClose}
                open={openMenu}
            >
                <MenuItem>
                    <ListItemIcon>
                        <BlockIcon/>
                    </ListItemIcon>
                    <ListItemText primary="Block user"/>
                </MenuItem>
                <MenuItem>
                    <ListItemIcon>
                        <DeleteIcon/>
                    </ListItemIcon>
                    <ListItemText primary="Delete conversation"/>
                </MenuItem>
                <MenuItem>
                    <ListItemIcon>
                        <ArchiveIcon/>
                    </ListItemIcon>
                    <ListItemText primary="Archive conversation"/>
                </MenuItem>
                <MenuItem>
                    <ListItemIcon>
                        <NotificationsOffIcon/>
                    </ListItemIcon>
                    <ListItemText primary="Mute notifications"/>
                </MenuItem>
            </Menu>
        </Toolbar>
    );
};

export default CoffeeToolbar;
