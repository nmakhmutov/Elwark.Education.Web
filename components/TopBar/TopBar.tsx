import {colors, Toolbar} from '@material-ui/core';
import AppBar from '@material-ui/core/AppBar';
import Avatar from '@material-ui/core/Avatar';
import Badge from '@material-ui/core/Badge';
import Button from '@material-ui/core/Button';
import Hidden from '@material-ui/core/Hidden';
import IconButton from '@material-ui/core/IconButton';
import Menu from '@material-ui/core/Menu';
import MenuItem from '@material-ui/core/MenuItem';
import makeStyles from '@material-ui/core/styles/makeStyles';
import Typography from '@material-ui/core/Typography';
import FavoriteIcon from '@material-ui/icons/Favorite';
import MenuIcon from '@material-ui/icons/Menu';
import NotificationsIcon from '@material-ui/icons/NotificationsOutlined';
import clsx from 'clsx';
import {Link} from 'components';
import {Notification} from 'components/NotificationsPopover/components/NotificationList';
import NotificationsPopover from 'components/NotificationsPopover/NotificationsPopover';
import {StorageApi} from 'lib/clients/storage';
import {Links} from 'lib/utils';
import {useFetchUser} from 'lib/utils/user';
import React, {MouseEventHandler, useEffect, useRef, useState} from 'react';

const useStyles = makeStyles((theme) => ({
    root: {
        boxShadow: 'none'
    },
    flexGrow: {
        flexGrow: 1
    },
    lifeButton: {
        marginLeft: theme.spacing(1)
    },
    lifeBadge: {
        backgroundColor: colors.red[600]
    },
    notificationsButton: {
        marginLeft: theme.spacing(1)
    },
    notificationsBadge: {
        backgroundColor: colors.orange[600]
    },
    logo: {
        '&:hover': {
            textDecoration: 'none'
        }
    },
    logoText: {
        textTransform: 'none',
        color: theme.palette.common.white,
    },
    userAvatar: {
        width: theme.spacing(4),
        height: theme.spacing(4),
        marginRight: theme.spacing(1)
    },
    userName: {
        textTransform: 'none',
        color: theme.palette.common.white
    }
}));

type Props = {
    className?: string;
    onOpenNavBarMobile: MouseEventHandler;
}

const TopBar: React.FC<Props> = (props) => {
    const {onOpenNavBarMobile, className, ...rest} = props;
    const {user} = useFetchUser();

    const classes = useStyles();
    const [notifications, setNotifications] = useState<Notification[]>([]);

    useEffect(() => {
        let mounted = true;

        const fetchNotifications = () => {
            if (mounted) {
                setNotifications([
                    {
                        id: 1,
                        title: 'New order has been received',
                        created_at: new Date()
                    },
                    {
                        id: 2,
                        title: 'New customer is registered',
                        created_at: new Date()
                    },
                    {
                        id: 3,
                        title: 'Project has been approved',
                        created_at: new Date()
                    },
                    {
                        id: 4,
                        title: 'New feature has been added',
                        created_at: new Date()
                    }
                ]);
            }
        };

        fetchNotifications();

        return () => {
            mounted = false;
        };
    }, []);

    const notificationsRef = useRef(null);
    const [openNotifications, setOpenNotifications] = useState(false);
    const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);

    const handleNotificationsOpen = () => {
        setOpenNotifications(true);
    };

    const handleNotificationsClose = () => {
        setOpenNotifications(false);
    };

    const handleMenu = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorEl(event.currentTarget);
    };

    const open = Boolean(anchorEl);

    const handleClose = () => {
        setAnchorEl(null);
    };

    return (
        <AppBar
            {...rest}
            className={clsx(classes.root, className)}
            color="primary"
        >
            <Toolbar>
                <Hidden mdDown={true}>
                    <Button
                        color="inherit"
                        className={classes.logo}
                        component={Link}
                        href={Links.Subjects}
                    >
                        <img
                            alt="Logo"
                            src={StorageApi.Static.Icons.Elwark.White.Size48x48}
                        />
                        <Typography variant={'h3'} className={classes.logoText} component={'h2'}>Education</Typography>
                    </Button>
                </Hidden>
                <Hidden lgUp={true}>
                    <IconButton color="inherit" onClick={onOpenNavBarMobile}>
                        <MenuIcon/>
                    </IconButton>
                </Hidden>
                <div className={classes.flexGrow}/>
                <IconButton className={classes.lifeButton} color="inherit">
                    <Badge
                        badgeContent={5}
                        classes={{badge: classes.lifeBadge}}
                        variant={'standard'}
                    >
                        <FavoriteIcon/>
                    </Badge>
                </IconButton>
                <IconButton
                    className={classes.notificationsButton}
                    color="inherit"
                    onClick={handleNotificationsOpen}
                    ref={notificationsRef}
                >
                    <Badge
                        badgeContent={notifications.length}
                        classes={{badge: classes.notificationsBadge}}
                        variant={'dot'}
                    >
                        <NotificationsIcon/>
                    </Badge>
                </IconButton>
                <div>
                    <Button
                        aria-label="account of current user"
                        aria-controls="menu-appbar"
                        aria-haspopup="true"
                        onClick={handleMenu}
                        color="inherit"
                    >
                        <Avatar
                            variant={'circle'}
                            className={classes.userAvatar}
                            src={user?.picture}/>
                        <Typography
                            variant={'h6'}
                            component={'h6'}
                            className={classes.userName}>
                            {user?.name}
                        </Typography>
                    </Button>
                    <Menu
                        id="menu-appbar"
                        anchorEl={anchorEl}
                        anchorOrigin={{
                            vertical: 'top',
                            horizontal: 'right',
                        }}
                        keepMounted
                        transformOrigin={{
                            vertical: 'top',
                            horizontal: 'right',
                        }}
                        open={open}
                        onClose={handleClose}
                    >
                        <MenuItem component={Link} href={Links.Profile}>Profile</MenuItem>
                        <MenuItem component={Link} href={Links.Account} target={'_blank'}>My account</MenuItem>
                        <MenuItem component={Link} href={Links.Logout}>Logout</MenuItem>
                    </Menu>
                </div>
            </Toolbar>
            <NotificationsPopover
                anchorEl={notificationsRef.current}
                notifications={notifications}
                onClose={handleNotificationsClose}
                open={openNotifications}
            />
        </AppBar>
    );
};

export default TopBar;
