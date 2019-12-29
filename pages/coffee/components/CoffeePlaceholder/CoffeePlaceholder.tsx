import {makeStyles, Typography} from '@material-ui/core';
import clsx from 'clsx';
import React from 'react';
import {ImageResolution, Storage} from '../../../../api';

const useStyles = makeStyles((theme) => ({
    root: {
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
    },
    inner: {
        textAlign: 'center',
    },
    image: {
        maxWidth: 400,
    },
    title: {
        margin: theme.spacing(4, 0, 1, 0),
    },
}));

export interface PlaceholderProps {
    className?: string;
}

const CoffeePlaceholder: React.FC<PlaceholderProps> = (props) => {
    const classes = useStyles();
    const {className, ...rest} = props;

    return (
        <div
            {...rest}
            className={clsx(classes.root, className)}
        >
            <div className={classes.inner}>
                <img
                    alt="Select coffee"
                    className={classes.image}
                    src={Storage.Images.RandomByImageResolution(ImageResolution.FHD)}
                />
                <Typography
                    className={classes.title}
                    variant="h4"
                >
                    Select coffee to display
                </Typography>
                <Typography variant="subtitle1">
                    To start a conversation just click the message button from a person
                    profile
                </Typography>
            </div>
        </div>
    );
};

export default CoffeePlaceholder;
