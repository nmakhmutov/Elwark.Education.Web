import {Drawer} from '@material-ui/core';
import makeStyles from '@material-ui/core/styles/makeStyles';
import clsx from 'clsx';
import React from 'react';
import pages from '../../../../pages';
import {SidebarNav} from './components';

const useStyles = makeStyles((theme) => ({
    drawer: {
        width: 240,
        [theme.breakpoints.up('lg')]: {
            marginTop: 64,
            height: 'calc(100% - 64px)',
        },
    },
    root: {
        backgroundColor: theme.palette.common.white,
        display: 'flex',
        flexDirection: 'column',
        height: '100%',
        padding: theme.spacing(2),
    },
    divider: {
        margin: theme.spacing(2, 0),
    },
    nav: {
        marginBottom: theme.spacing(2),
    },
}));

export interface SidebarProps {
    open: boolean;
    variant?: 'permanent' | 'persistent' | 'temporary';
    onClose: () => void;
    className?: string;
}

const Sidebar: React.FC<SidebarProps> = (props) => {
    const classes = useStyles();
    const {open, variant, onClose, className, ...rest} = props;

    return (
        <Drawer
            anchor={'left'}
            classes={{paper: classes.drawer}}
            onClose={onClose}
            open={open}
            variant={variant}
        >
            <div
                {...rest}
                className={clsx(classes.root, className)}
            >
                {/*<Profile />*/}
                {/*<Divider className={classes.divider}/>*/}
                <SidebarNav
                    className={classes.nav}
                    pages={pages}
                />
            </div>
        </Drawer>
    );
};

export default Sidebar;
