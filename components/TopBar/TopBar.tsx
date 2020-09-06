import {colors, Toolbar} from '@material-ui/core';
import AppBar from '@material-ui/core/AppBar';
import Badge from '@material-ui/core/Badge';
import Button from '@material-ui/core/Button';
import Hidden from '@material-ui/core/Hidden';
import IconButton from '@material-ui/core/IconButton';
import makeStyles from '@material-ui/core/styles/makeStyles';
import Typography from '@material-ui/core/Typography';
import FavoriteIcon from '@material-ui/icons/Favorite';
import MenuIcon from '@material-ui/icons/Menu';
import NotificationsIcon from '@material-ui/icons/NotificationsOutlined';
import clsx from 'clsx';
import {Link} from 'components';
import {Notification, NotificationsPopover} from 'components/NotificationsPopover';
import {StorageApi} from 'lib/clients/storage';
import Links from 'lib/utils/Links';
import React, {MouseEventHandler, useEffect, useRef, useState} from 'react';
import {ProfileContext} from "lib/profile";

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
    regularLifeBadge: {
        backgroundColor: colors.red[600]
    },
    premiumLifeBadge: {
        backgroundColor: colors.blue[600]
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

const TopBar: React.FC<Props> = ({className, onOpenNavBarMobile}) => {
    const classes = useStyles();
    const [notifications, setNotifications] = useState<Notification[]>([]);
    const {profile} = React.useContext(ProfileContext);
    const isRegular = profile?.subscription.type === 'regular';

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

    const handleNotificationsOpen = () => {
        setOpenNotifications(true);
    };

    const handleNotificationsClose = () => {
        setOpenNotifications(false);
    };

    return (
        <AppBar className={clsx(classes.root, className)} color="primary">
            <Toolbar>
                <Hidden mdDown={true}>
                    <Button color="inherit" className={classes.logo} component={Link} href={Links.Home}>
                        <img alt="Logo" src={StorageApi.Static.Icons.Elwark.White.Size48x48}/>
                        <Typography variant={'h3'} className={classes.logoText} component={'h2'}>Education</Typography>
                    </Button>
                </Hidden>
                <Hidden lgUp={true}>
                    <IconButton color="inherit" onClick={onOpenNavBarMobile}>
                        <MenuIcon/>
                    </IconButton>
                </Hidden>
                <div className={classes.flexGrow}/>
                {profile && <>
                    <IconButton
                        className={classes.notificationsButton}
                        color="inherit"
                        onClick={handleNotificationsOpen}
                        ref={notificationsRef}>
                        <Badge
                            badgeContent={notifications.length}
                            classes={{badge: classes.notificationsBadge}}
                            variant={'dot'}>
                            <NotificationsIcon/>
                        </Badge>
                    </IconButton>
                    <IconButton className={classes.lifeButton} color="inherit">
                        <Badge
                            badgeContent={isRegular ? profile?.life.points : '∞'}
                            classes={{badge: isRegular ? classes.regularLifeBadge : classes.premiumLifeBadge}}>
                            <FavoriteIcon/>
                        </Badge>
                    </IconButton>
                </>}
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
