import React from 'react';
import clsx from 'clsx';
import {makeStyles} from '@material-ui/styles';
import {Button, colors, Dialog, Theme, Typography} from '@material-ui/core';
import {Link} from 'components';
import WebLinks from 'lib/WebLinks';
import PricingCards from './PricingCards';

const useStyles = makeStyles((theme: Theme) => ({
    root: {
        width: 960
    },
    header: {
        maxWidth: 600,
        margin: '0 auto',
        padding: theme.spacing(3)
    },
    content: {
        padding: theme.spacing(2),
        maxWidth: 720,
        margin: '0 auto'
    },
    actions: {
        backgroundColor: colors.grey[100],
        padding: theme.spacing(2),
        display: 'flex',
        justifyContent: 'center'
    },
    startButton: {
        color: theme.palette.common.white,
        backgroundColor: colors.green[600],
        '&:hover': {
            backgroundColor: colors.green[900],
            textDecoration: 'none'
        }
    }
}));

type Props = {
    className?: string,
    onClose: () => void,
    open: boolean
}

const PricingModal: React.FC<Props> = (props) => {
    const {open, onClose, className} = props;

    const classes = useStyles();

    return (
        <Dialog maxWidth="lg" onClose={onClose} open={open}>
            <div className={clsx(classes.root, className)}>
                <div className={classes.header}>
                    <Typography align={'center'} gutterBottom={true} variant={'h3'}>
                        Boost up your education!
                    </Typography>
                    <Typography align="center" variant="subtitle2">
                        Start with premium subscription today.
                    </Typography>
                </div>
                <div className={classes.content}>
                    <PricingCards/>
                </div>
                <div className={classes.actions}>
                    <Button className={classes.startButton} variant={'contained'} component={Link} href={WebLinks.Premium}>
                        Start with premium
                    </Button>
                </div>
            </div>
        </Dialog>
    );
};

export default PricingModal;
