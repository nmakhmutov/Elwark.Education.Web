import React from 'react';
import {Card, Theme, Typography} from '@material-ui/core';
import Link from 'components/Link/Link';
import {makeStyles} from '@material-ui/styles';
import clsx from 'clsx';

const useStyles = makeStyles((theme: Theme) => ({
    root: {
        display: 'flex',
        flexDirection: 'column',
        width: '100%',
        height: '100%',
        minHeight: '250px',
        padding: theme.spacing(2),
    },
    top: {
        justifyContent: 'space-around',
        alignItems: 'center',
    },
    end: {
        justifyContent: 'flex-end',
        alignItems: 'flex-start',
    },
    center: {
        justifyContent: 'center',
        alignItems: 'center',
    },
    gradient: {
        background: 'rgba(0,0,0,0.3)',
        color: theme.palette.common.white,
    },
    white: {
        background: theme.palette.common.white,
        color: theme.typography.h1.color,
        boxShadow: theme.shadows['2']
    },
    image: {
        height: '100%',
        backgroundRepeat: 'no-repeat',
        backgroundPosition: 'center center',
        backgroundSize: 'cover',
    },
    title: {
        color: theme.palette.common.white,
        marginBottom: theme.spacing(2)
    },
    description: {
        color: 'inherit'
    }
}));

type Props = {
    className?: string,
    image?: string,
    title: string,
    description?: string,
    href: string,
    as?: string
}

const HistoryArticleGridItem: React.FC<Props> = (props) => {
    const {className, image, title, href, as, description} = props;
    const classes = useStyles();

    if (image)
        return (
            <Card className={clsx(classes.image, className)} style={{backgroundImage: `url(${image})`}}>
                <div className={clsx(classes.root, classes.gradient, classes.end)}>
                    <Typography variant={'h2'} className={classes.title} component={Link} href={href} as={as}>
                        {title}
                    </Typography>
                    <Typography variant={'body1'} className={classes.description}>
                        {description}
                    </Typography>
                </div>
            </Card>
        );

    return (
        <Card className={className}>
            <div className={clsx(classes.root, classes.white, description ? classes.top : classes.center, className)}>
                <Typography variant={'h2'} component={Link} href={href} as={as}>
                    {title}
                </Typography>
                <Typography variant={'body1'} className={classes.description}>
                    {description}
                </Typography>
            </div>
        </Card>
    );
}

export default HistoryArticleGridItem;
