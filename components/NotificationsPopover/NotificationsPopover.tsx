import {Button, CardActions, CardHeader, colors, Divider, Popover} from '@material-ui/core';
import {makeStyles} from '@material-ui/styles';
import {Link} from 'components';
import {EmptyList, NotificationList, Notification} from 'components/NotificationsPopover/components';
import React from 'react';

const useStyles = makeStyles(() => ({
    root: {
        width: 350,
        maxWidth: '100%'
    },
    actions: {
        backgroundColor: colors.grey[50],
        justifyContent: 'center'
    }
}));

type Props = {
    notifications: Notification[],
    anchorEl: any,
    className?: string,
    onClose: () => void,
    open: boolean
};

const NotificationsPopover: React.FC<Props> = (props) => {
    const {notifications, anchorEl, ...rest} = props;
    const classes = useStyles();

    return (
        <Popover
            {...rest}
            anchorEl={anchorEl}
            anchorOrigin={{
                vertical: 'bottom',
                horizontal: 'center'
            }}
        >
            <div className={classes.root}>
                <CardHeader title="Notifications"/>
                <Divider/>
                {notifications.length > 0
                    ? <NotificationList notifications={notifications}/>
                    : <EmptyList/>
                }
                <Divider/>
                <CardActions className={classes.actions}>
                    <Button
                        component={Link}
                        size="small"
                        href="#"
                    >
                        See all
                    </Button>
                </CardActions>
            </div>
        </Popover>
    );
};

export default NotificationsPopover;
