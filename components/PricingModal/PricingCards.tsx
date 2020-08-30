import {Divider, Grid, Paper, Theme, Typography} from '@material-ui/core';
import clsx from 'clsx';
import React from 'react';
import {makeStyles} from '@material-ui/styles';

const useStyles = makeStyles((theme: Theme) => ({
    product: {
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
        }
    },
    divider: {
        margin: theme.spacing(2, 0)
    },
    options: {
        lineHeight: '26px'
    },
    recommended: {
        backgroundColor: theme.palette.primary.main,
        '& *': {
            color: `${theme.palette.common.white} !important`
        }
    },
}));
const PricingCards: React.FC = () => {
    const classes = useStyles();

    return (
        <Grid container={true} spacing={4}>
            <Grid item={true} md={4} xs={12}>
                <Paper className={classes.product} elevation={1}>
                    <Typography component="h3" gutterBottom={true} variant="overline">
                        Month
                    </Typography>
                    <div>
                        <Typography component="span" display="inline" variant="h3">
                            $9
                        </Typography>
                        <Typography component="span" display="inline" variant="subtitle2">
                            /month
                        </Typography>
                    </div>
                    <Divider className={classes.divider}/>
                    <Typography className={classes.options} variant="subtitle2">
                        <b>20</b> proposals/month <br/>
                        <b>10</b> templates <br/>
                        Analytics <b>dashboard</b> <br/>
                        <b>Email</b> alerts
                    </Typography>
                </Paper>
            </Grid>
            <Grid item={true} md={4} xs={12}>
                <Paper className={classes.product} elevation={1}>
                    <Typography component="h3" gutterBottom variant="overline">
                        three month
                    </Typography>
                    <div>
                        <Typography component="span" display="inline" variant="h3">
                            $25
                        </Typography>
                        <Typography component="span" display="inline" variant="subtitle2">
                            /3 month
                        </Typography>
                    </div>
                    <Divider className={classes.divider}/>
                    <Typography className={classes.options} variant="subtitle2">
                        <b>20</b> proposals/month <br/>
                        <b>10</b> templates <br/>
                        Analytics <b>dashboard</b> <br/>
                        <b>Email</b> alerts
                    </Typography>
                </Paper>
            </Grid>
            <Grid item={true} md={4} xs={12}>
                <Paper className={clsx(classes.product, classes.recommended)} elevation={1}>
                    <Typography component="h3" gutterBottom={true} variant="overline">
                        Year
                    </Typography>
                    <div>
                        <Typography component="span" display="inline" variant="h3">
                            $99
                        </Typography>
                        <Typography component="span" display="inline" variant="subtitle2">
                            /12 month
                        </Typography>
                    </div>
                    <Divider className={classes.divider}/>
                    <Typography className={classes.options} variant="subtitle2">
                        All from above <br/>
                        <b>Unlimited</b> 24/7 support <br/>
                        Personalised <b>Page</b> <br/>
                        <b>Advertise</b> your profile
                    </Typography>
                </Paper>
            </Grid>
        </Grid>
    )
}

export default PricingCards;
