import {Avatar, Divider, Grid, Paper, Typography} from '@material-ui/core';
import makeStyles from '@material-ui/core/styles/makeStyles';
import AccountBalanceIcon from '@material-ui/icons/AccountBalance';
import clsx from 'clsx';
import Atom from 'components/icons/Atom';
import Links from 'lib/utils/Links';
import {useRouter} from 'next/router';
import React from 'react';

const useStyles = makeStyles(theme => ({
    root: {},
    header: {
        maxWidth: 600,
        margin: '0 auto',
        padding: theme.spacing(3)
    },
    content: {
        marginTop: theme.spacing(5),
        padding: theme.spacing(2),
        maxWidth: 1280,
        margin: '0 auto'
    },
    subtitle: {
        marginTop: theme.spacing(3)
    },
    subject: {
        overflow: 'unset',
        position: 'relative',
        padding: theme.spacing(5, 3),
        cursor: 'pointer',
        transition: theme.transitions.create('transform', {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.leavingScreen
        }),
        '&:hover': {
            transform: 'scale(1.1)'
        },
        backgroundRepeat: 'no-repeat',
        backgroundPosition: 'center center',
        backgroundSize: 'cover'
    },
    history: {
        background: 'linear-gradient(140deg, rgba(226,110,67,1) 0%, rgba(248,206,14,1) 100%)'
    },
    physics: {
        background: 'linear-gradient(140deg, rgba(28,46,76,1) 0%, rgba(108,208,255,1) 100%)'
    },
    avatar: {
        borderRadius: theme.shape.borderRadius,
        position: 'absolute',
        top: -24,
        left: theme.spacing(3),
        height: 48,
        width: 48,
        fontSize: 24,
    },
    divider: {
        margin: theme.spacing(2, 0)
    },
    options: {
        lineHeight: '26px'
    },
    contact: {
        margin: theme.spacing(3, 0)
    }
}));

const Subjects: React.FC = (props) => {
    const classes = useStyles();
    const router = useRouter();

    return (
        <div className={classes.root}>
            <div className={classes.header}>
                <Typography align="center" gutterBottom variant="h1">
                    Choose your love subject
                </Typography>
                <Typography align="center" variant="subtitle2" className={classes.subtitle}>
                    Welcome to the first platform for education!
                </Typography>
            </div>
            <div className={classes.content}>
                <Grid container spacing={6} justify={'center'}>
                    <Grid item md={4} xs={12}>
                        <Paper className={classes.subject} elevation={1} onClick={() => router.push(Links.History)}>
                            <Avatar className={clsx(classes.avatar, classes.history)}>
                                <AccountBalanceIcon/>
                            </Avatar>
                            <Typography
                                component="h3"
                                gutterBottom
                                variant="overline"
                            >
                                Subject
                            </Typography>
                            <Typography
                                component="span"
                                display="inline"
                                variant="h3"
                            >
                                History
                            </Typography>
                            <Divider className={classes.divider}/>
                            <Typography variant={'subtitle2'} className={classes.options}>
                                <strong>20+</strong> Topics
                            </Typography>
                            <Typography variant={'subtitle2'} className={classes.options}>
                                <strong>30+</strong> Articles
                            </Typography>
                            <Typography variant={'subtitle2'} className={classes.options}>
                                <strong>40+</strong> Questions
                            </Typography>
                        </Paper>
                    </Grid>
                    <Grid item md={4} xs={12}>
                        <Paper className={classes.subject} elevation={1} onClick={() => router.push(Links.Physics)}>
                            <Avatar className={clsx(classes.avatar, classes.physics)}>
                                <Atom/>
                            </Avatar>
                            <Typography
                                component="h3"
                                gutterBottom
                                variant="overline"
                            >
                                Subject
                            </Typography>
                            <Typography
                                component="span"
                                display="inline"
                                variant="h3"
                            >
                                Physics
                            </Typography>
                            <Divider className={classes.divider}/>
                            <Typography variant={'subtitle2'} className={classes.options}>
                                <strong>20+</strong> Topics
                            </Typography>
                            <Typography variant={'subtitle2'} className={classes.options}>
                                <strong>30+</strong> Articles
                            </Typography>
                            <Typography variant={'subtitle2'} className={classes.options}>
                                <strong>40+</strong> Questions
                            </Typography>
                        </Paper>
                    </Grid>
                </Grid>
            </div>
        </div>
    );
};

export default Subjects;
