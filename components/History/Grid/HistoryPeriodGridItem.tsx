import React from 'react';
import {Theme, Typography} from '@material-ui/core';
import Link from 'components/Link/Link';
import {makeStyles} from '@material-ui/styles';
import clsx from 'clsx';

const useStyles = makeStyles((theme: Theme) => ({
    root: {
        width: '100%',
        height: '100%',
        display: 'flex',
        alignItems: 'center',
        flexDirection: 'column',
        justifyContent: 'center',
        textAlign: 'center',
        backgroundColor: 'rgba(0,0,0,0.4)',
        '& > *': {
            color: theme.palette.common.white,
        }
    },
    title: {
        color: theme.palette.common.white,
        padding: theme.spacing(0, 2)
    },
    image: {
        backgroundPosition: 'center center !important',
        backgroundSize: 'cover !important',
        backgroundRepeat: 'no-repeat'
    }
}));

type Props = {
    className?: string,
    image: string,
    title: string,
    description: string,
    href: string
}

const HistoryPeriodGridItem: React.FC<Props> = (props) => {
    const {className, image, title, href, description} = props;
    const classes = useStyles();

    return (
        <div className={clsx(classes.image, className)} style={{backgroundImage: `url(${image})`}}>
            <div className={classes.root}>
                <Typography
                    variant={'h2'}
                    className={classes.title}
                    component={Link}
                    href={href}>
                    {title}
                </Typography>
                <Typography variant={'subtitle1'}>
                    {description}
                </Typography>
            </div>
        </div>
    );
}

export default HistoryPeriodGridItem;
