import React from 'react';
import {Card, CardActionArea, Theme, Typography} from '@material-ui/core';
import Link from 'components/Link/Link';
import {makeStyles} from '@material-ui/styles';
import clsx from 'clsx';

const useStyles = makeStyles((theme: Theme) => ({
    root: {
        width: '100%',
        height: '240px',
        display: 'flex',
        alignItems: 'center',
        flexDirection: 'column',
        justifyContent: 'center',
        textAlign: 'center',
        backgroundColor: 'rgba(0,0,0,0.4)',
        '& > *': {
            color: theme.palette.common.white,
        },
        '&:hover': {
            textDecoration: 'none'
        }
    },
    title: {
        color: theme.palette.common.white,
        padding: theme.spacing( 2)
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
        <Card className={clsx(classes.image, className)} style={{backgroundImage: `url(${image})`}}>
            <CardActionArea className={classes.root} component={Link} href={href}>
                <Typography variant={'h2'} className={classes.title}>
                    {title}
                </Typography>
                <Typography variant={'subtitle1'}>
                    {description}
                </Typography>
            </CardActionArea>
        </Card>
    );
}

export default HistoryPeriodGridItem;
