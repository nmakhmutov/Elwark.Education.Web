import {Button, Grid, Theme, Typography} from '@material-ui/core';
import {makeStyles} from '@material-ui/styles';
import clsx from 'clsx';
import {StorageApi} from 'lib/clients/storage';
import React from 'react';

const useStyles = makeStyles((theme: Theme) => ({
    root: {
        backgroundColor: theme.palette.common.white
    },
    header: {
        width: theme.breakpoints.values.md,
        maxWidth: '100%',
        margin: '0 auto',
        padding: '80px 24px',
        [theme.breakpoints.up('md')]: {
            padding: '160px 24px'
        }
    },
    buttons: {
        marginTop: theme.spacing(3),
        display: 'flex',
        justifyContent: 'center'
    },
    mediaContainer: {
        overflow: 'hidden',
        width: '100%',
        height: 120
    },
    media: {
        width: '100%',
        height: '100%',
        backgroundImage: 'url(https://lh3.googleusercontent.com/proxy/zmcgCpLe0Vxr6eII2ui-aHKWH-w1sNlIw_iuylcfPY7-O4OsLim_XB7kolcWJuy5jX11Tlwsof_AmspLlF4x86MaZ11obYbUGKBR6Shk9TAK-u09nVR0c1kec2s4hm_0Bd-qU6hK_GtnQupjGDOnx6r8HA)',
        backgroundPosition: 'center center'
    },
    stats: {
        backgroundColor: theme.palette.primary.main,
        color: theme.palette.primary.contrastText,
        padding: theme.spacing(1)
    },
    statsInner: {
        width: theme.breakpoints.values.md,
        maxWidth: '100%',
        margin: '0 auto'
    }
}));

type Props = {
    className?: string
}

const Header: React.FC<Props> = (props) => {
    const {className, ...rest} = props;

    const classes = useStyles();

    return (
        <div
            {...rest}
            className={clsx(classes.root, className)}
        >
            <div className={classes.header}>
                <Typography align="center" gutterBottom={true} variant="h1">
                    Elwark Education
                </Typography>
                <Typography align="center" component="h2" variant="subtitle1">
                    Education for everyone in everywhere
                </Typography>
                <div className={classes.buttons}>
                    <Button color="primary" component="a" href="/api/login" variant="contained">
                        Try for free
                    </Button>
                </div>
            </div>
            <div className={classes.mediaContainer}>
                <div className={classes.media}/>
                {/*<img*/}
                {/*    className={classes.media}*/}
                {/*    src="/static/landing.jpg"*/}
                {/*/>*/}
            </div>
            <div className={classes.stats}>
                <Grid
                    alignItems="center"
                    className={classes.statsInner}
                    container
                    justify="center"
                    spacing={3}
                >
                    <Grid item lg={3} md={6} xs={12}>
                        <Typography color="inherit" gutterBottom variant="h3">
                            40+
                        </Typography>
                        <Typography color="inherit" variant="body2">
                            Topics
                        </Typography>
                    </Grid>
                    <Grid item lg={3} md={6} xs={12}>
                        <Typography color="inherit" gutterBottom={true} variant="h3">
                            60+
                        </Typography>
                        <Typography color="inherit" variant="body2">
                            Articles
                        </Typography>
                    </Grid>
                    <Grid item lg={3} md={6} xs={12}>
                        <Typography color="inherit" gutterBottom={true} variant="h3">
                            80+
                        </Typography>
                        <Typography color="inherit" variant="body2">
                            Questions
                        </Typography>
                    </Grid>
                    <Grid item={true} lg={3} md={6} xs={12}>
                        <div>
                            <img
                                alt="Elwark"
                                src={StorageApi.Static.Icons.Elwark.White.Size32x32}
                            />
                        </div>
                        <Typography color="inherit" variant="body2">
                            Education
                        </Typography>
                    </Grid>
                </Grid>
            </div>
        </div>
    );
};

export default Header;
