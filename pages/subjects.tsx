import {Avatar, Divider, Grid, Paper, Typography} from '@material-ui/core';
import makeStyles from '@material-ui/core/styles/makeStyles';
import AccountBalanceIcon from '@material-ui/icons/AccountBalance';
import clsx from 'clsx';
import Atom from 'components/icons/Atom';
import DefaultLayout from 'components/Layout';
import {Links} from 'lib/utils';
import {NextPage} from 'next';
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
        '& *': {
            color: `${theme.palette.common.white} !important`
        },
        backgroundRepeat: 'no-repeat',
        backgroundPosition: 'center center',
        backgroundSize: 'cover'
    },
    history: {
        backgroundImage: 'url(/static/images/bg/history.jpg)',
    },
    physics: {
        backgroundImage: 'url(/static/images/bg/physics.jpg)',
    },
    image: {
        borderRadius: theme.shape.borderRadius,
        position: 'absolute',
        top: -24,
        left: theme.spacing(3),
        height: 48,
        width: 48,
        fontSize: 24,
        background: theme.palette.primary.main
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

const Subjects: NextPage = (props) => {
    const classes = useStyles();
    const router = useRouter();

    return (
        <DefaultLayout title={'Subjects'}>
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
                            <Paper className={clsx(classes.subject, classes.history)}
                                   elevation={1}
                                   onClick={() => router.push(Links.History)}>
                                <Avatar className={classes.image}>
                                    <AccountBalanceIcon/>
                                </Avatar>
                                <Typography
                                    component="h3"
                                    gutterBottom
                                    variant="overline"
                                >
                                    Freelancer
                                </Typography>
                                <div>
                                    <Typography
                                        component="span"
                                        display="inline"
                                        variant="h3"
                                    >
                                        $5
                                    </Typography>
                                    <Typography
                                        component="span"
                                        display="inline"
                                        variant="subtitle2"
                                    >
                                        /month
                                    </Typography>
                                </div>
                                <Typography variant="overline">Max 1 user</Typography>
                                <Divider className={classes.divider}/>
                                <Typography
                                    className={classes.options}
                                    variant="subtitle2"
                                >
                                    <b>20</b> proposals/month <br/>
                                    <b>10</b> templates <br/>
                                    Analytics <b>dashboard</b> <br/>
                                    <b>Email</b> alerts
                                </Typography>
                            </Paper>
                        </Grid>
                        <Grid item md={4} xs={12}>
                            <Paper
                                className={clsx(classes.subject, classes.physics)}
                                elevation={1}
                            >
                                <img
                                    alt="Product"
                                    className={classes.image}
                                    src={'/static/images/icon/physics.svg'}
                                />
                                <Avatar className={classes.image}>
                                    <Atom/>
                                </Avatar>
                                <Typography
                                    component="h3"
                                    gutterBottom
                                    variant="overline"
                                >
                                    Agency
                                </Typography>
                                <div>
                                    <Typography
                                        component="span"
                                        display="inline"
                                        variant="h3"
                                    >
                                        $29
                                    </Typography>
                                    <Typography
                                        component="span"
                                        display="inline"
                                        variant="subtitle2"
                                    >
                                        /month
                                    </Typography>
                                </div>
                                <Typography variant="overline">Max 3 user</Typography>
                                <Divider className={classes.divider}/>
                                <Typography
                                    className={classes.options}
                                    variant="subtitle2"
                                >
                                    <b>20</b> proposals/month <br/>
                                    <b>10</b> templates <br/>
                                    Analytics <b>dashboard</b> <br/>
                                    <b>Email</b> alerts
                                </Typography>
                            </Paper>
                        </Grid>
                    </Grid>
                </div>
            </div>
        </DefaultLayout>
    );
};

export default Subjects;
