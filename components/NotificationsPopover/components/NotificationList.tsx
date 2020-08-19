import {List, ListItem, ListItemText} from '@material-ui/core';
import ArrowForwardIcon from '@material-ui/icons/ArrowForward';
import {makeStyles} from '@material-ui/styles';
import clsx from 'clsx';
import {Link} from 'components';
import moment from 'moment';
import React from 'react';

const useStyles = makeStyles((theme) => ({
    root: {},
    listItem: {
        '&:hover': {
            backgroundColor: theme.palette.background.default,
            textDecoration: 'none'
        }
    },
    arrowForwardIcon: {
        color: theme.palette.icon
    }
}));

export interface Notification {
    id: number,
    title: string,
    created_at: Date,
}

type Props = {
    notifications: Notification[],
    className?: string
}

const NotificationList: React.FC<Props> = (props) => {
    const {notifications, className, ...rest} = props;

    const classes = useStyles();

    return (
        <List
            {...rest}
            className={clsx(classes.root, className)}
            disablePadding
        >
            {
                notifications.map((notification, i) => (
                    <ListItem
                        className={classes.listItem}
                        component={Link}
                        divider={i < notifications.length - 1}
                        key={notification.id}
                        href="/"
                    >
                        <ListItemText
                            primary={notification.title}
                            primaryTypographyProps={{variant: 'body1'}}
                            secondary={moment(notification.created_at).fromNow()}
                        />
                        <ArrowForwardIcon className={classes.arrowForwardIcon}/>
                    </ListItem>
                ))
            }
        </List>
    );
};

export default NotificationList;
