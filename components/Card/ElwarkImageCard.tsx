import React from 'react';
import {makeStyles} from '@material-ui/styles';
import {Card, Theme} from '@material-ui/core';
import clsx from 'clsx';

const useStyles = makeStyles((theme: Theme) => ({
    root: {
        width: '100%',
        height: '100%',
        backgroundColor: 'rgba(0,0,0,0.4)'
    },
    title: {
        color: theme.palette.common.white
    },
    image: {
        backgroundPosition: 'center center !important',
        backgroundSize: 'cover !important',
        backgroundRepeat: 'no-repeat'
    }
}));

type Props = {
    className?: string,
    image: string
}

const ElwarkImageCard: React.FC<Props> = ({className, image, children}) => {
    const classes = useStyles();

    return (
        <Card className={clsx(classes.image, className)} style={{backgroundImage: `url(${image})`}}>
            <div className={classes.root}>
                {children}
            </div>
        </Card>
    );
};

export default ElwarkImageCard;
