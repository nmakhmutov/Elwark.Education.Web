import {Typography} from '@material-ui/core';
import Button from '@material-ui/core/Button';
import Grid from '@material-ui/core/Grid';
import makeStyles from '@material-ui/core/styles/makeStyles';
import clsx from 'clsx';
import {useRouter} from 'next/router';
import React from 'react';
import Storage from '../../../../api/storage';
import {ImageResolution} from '../../../../interfaces';

const useStyles = makeStyles((theme) => ({
    root: {
        backgroundColor: theme.palette.common.white,
        backgroundImage: `url(${Storage.Images.RandomByImageResolution(ImageResolution.FHD)})`,
    },
    header: {
        width: theme.breakpoints.values.md,
        maxWidth: '100%',
        margin: '0 auto',
        padding: '80px 24px',
        [theme.breakpoints.up('md')]: {
            padding: '160px 24px',
        },
    },
    buttons: {
        marginTop: theme.spacing(3),
        display: 'flex',
        justifyContent: 'center',
    },
    media: {
        width: '100%',
    },
    stats: {
        backgroundColor: theme.palette.primary.main,
        color: theme.palette.primary.contrastText,
        padding: theme.spacing(1),
    },
    statsInner: {
        width: theme.breakpoints.values.md,
        maxWidth: '100%',
        margin: '0 auto',
    },
}));

export interface HeaderProps {
    className?: string;
}

const Header: React.FC<HeaderProps> = (props) => {
    const {className, ...rest} = props;

    const classes = useStyles();
    const router = useRouter();

    return (
        <div
            {...rest}
            className={clsx(classes.root, className)}
        >
            <div className={classes.header}>
                <Typography align="center" gutterBottom variant="h1">
                    Elwark cafe
                </Typography>
                <Typography align="center" component="h2" variant="subtitle1">
                    Enjoy your coffee wherever you go
                </Typography>
                <div className={classes.buttons}>
                    <Button color={'primary'} variant={'contained'} onClick={() => router.push('/map')}>
                        Explore coffee houses
                    </Button>
                </div>
            </div>
            <div className={classes.stats}>
                <Grid
                    alignItems="center"
                    className={classes.statsInner}
                    container
                    justify="center"
                    spacing={3}
                >
                    <Grid
                        item
                        lg={3}
                        md={6}
                        xs={12}
                    >
                        <Typography
                            color="inherit"
                            gutterBottom
                            variant="h3"
                        >
                            100+
                        </Typography>
                        <Typography
                            color="inherit"
                            variant="body2"
                        >
                            Coffee companies
                        </Typography>
                    </Grid>
                    <Grid
                        item
                        lg={3}
                        md={6}
                        xs={12}
                    >
                        <Typography
                            color="inherit"
                            gutterBottom
                            variant="h3"
                        >
                            60+
                        </Typography>
                        <Typography
                            color="inherit"
                            variant="body2"
                        >
                            Coffee
                        </Typography>
                    </Grid>
                    <Grid
                        item
                        lg={3}
                        md={6}
                        xs={12}
                    >
                        <Typography
                            color="inherit"
                            gutterBottom
                            variant="h3"
                        >
                            1000+
                        </Typography>
                        <Typography
                            color="inherit"
                            variant="body2"
                        >
                            Coffee houses
                        </Typography>
                    </Grid>
                    <Grid
                        item
                        lg={3}
                        md={6}
                        xs={12}
                    >
                        <div>
                            <img alt="Elwark" src={Storage.Static.Icons.Elwark.White.Size48x48}/>
                        </div>
                        <Typography color="inherit" variant="body2">
                            Just coffee
                        </Typography>
                    </Grid>
                </Grid>
            </div>
        </div>
    );
};

export default Header;
