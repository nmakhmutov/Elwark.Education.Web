import {colors, Toolbar} from '@material-ui/core';
import AppBar from '@material-ui/core/AppBar';
import Badge from '@material-ui/core/Badge';
import Hidden from '@material-ui/core/Hidden';
import IconButton from '@material-ui/core/IconButton';
import makeStyles from '@material-ui/core/styles/makeStyles';
import MenuIcon from '@material-ui/icons/Menu';
import NotificationsIcon from '@material-ui/icons/NotificationsOutlined';
import clsx from 'clsx';
import {Link} from 'components';
import {Notification} from 'components/NotificationsPopover/components/NotificationList';
import NotificationsPopover from 'components/NotificationsPopover/NotificationsPopover';
import {StorageApi} from 'lib/api/storage';
import React, {MouseEventHandler, useEffect, useRef, useState} from 'react';

const useStyles = makeStyles((theme) => ({
    root: {
        boxShadow: 'none'
    },
    flexGrow: {
        flexGrow: 1
    },
    search: {
        backgroundColor: 'rgba(255,255,255, 0.1)',
        borderRadius: 4,
        flexBasis: 300,
        height: 36,
        padding: theme.spacing(0, 2),
        display: 'flex',
        alignItems: 'center'
    },
    searchIcon: {
        marginRight: theme.spacing(2),
        color: 'inherit'
    },
    searchInput: {
        flexGrow: 1,
        color: 'inherit',
        '& input::placeholder': {
            opacity: 1,
            color: 'inherit'
        }
    },
    searchPopper: {
        zIndex: theme.zIndex.appBar + 100
    },
    searchPopperContent: {
        marginTop: theme.spacing(1)
    },
    trialButton: {
        marginLeft: theme.spacing(2),
        color: theme.palette.common.white,
        backgroundColor: colors.green[600],
        '&:hover': {
            backgroundColor: colors.green[900]
        }
    },
    trialIcon: {
        marginRight: theme.spacing(1)
    },
    notificationsButton: {
        marginLeft: theme.spacing(1)
    },
    notificationsBadge: {
        backgroundColor: colors.orange[600]
    },
    logoutButton: {
        marginLeft: theme.spacing(1)
    },
    logoutIcon: {
        marginRight: theme.spacing(1)
    }
}));

type Props = {
    className?: string;
    onOpenNavBarMobile: MouseEventHandler;
}

const TopBar: React.FC<Props> = (props) => {
    const {onOpenNavBarMobile, className, ...rest} = props;

    const classes = useStyles();
    const [notifications, setNotifications] = useState<Notification[]>([]);

    useEffect(() => {
        let mounted = true;

        const fetchNotifications = () => {
            if (mounted) {
                setNotifications([{
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
                    }]);
            }
        };

        fetchNotifications();

        return () => {
            mounted = false;
        };
    }, []);

    const notificationsRef = useRef(null);
    const [openNotifications, setOpenNotifications] = useState(false);

    const handleNotificationsOpen = () => {
        setOpenNotifications(true);
    };

    const handleNotificationsClose = () => {
        setOpenNotifications(false);
    };

    return (
        <AppBar
            {...rest}
            className={clsx(classes.root, className)}
            color="primary"
        >
            <Toolbar>
                <Hidden mdDown={true}>
                    <Link href="/">
                        <img
                            alt="Logo"
                            src={StorageApi.Static.Icons.Elwark.White.Size48x48}
                        />
                    </Link>
                </Hidden>
                <Hidden lgUp={true}>
                    <IconButton
                        color="inherit"
                        onClick={onOpenNavBarMobile}
                    >
                        <MenuIcon/>
                    </IconButton>
                </Hidden>
                <div className={classes.flexGrow}/>
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
