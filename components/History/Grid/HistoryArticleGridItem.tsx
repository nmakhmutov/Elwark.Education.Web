import React from 'react';
import {Theme, Typography} from '@material-ui/core';
import Link from 'components/Link/Link';
import {makeStyles} from '@material-ui/styles';

const useStyles = makeStyles((theme: Theme) => ({
    root: {
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'flex-end',
        alignItems:'flex-end',
        width: '100%',
        height: '100%',
        padding: theme.spacing(2),
        background: 'linear-gradient(0deg, rgba(0,0,0,1) 0%, rgba(0,0,0,0) 50%)',
        color: theme.palette.common.white,
    },
    image: {
        backgroundRepeat: 'no-repeat',
        backgroundPosition: 'center center',
        backgroundSize: 'cover',
    },
    title: {
        color: theme.palette.common.white,
    }
}));

type Props = {
    elementIndex: number,
    className?: string,
    image?: string,
    title: string,
    description?: string,
    href: string,
    as?: string
}

const HistoryArticleGridItem: React.FC<Props> = (props) => {
    const {className, image, title, href, as, description, elementIndex} = props;
    const classes = useStyles();

    return (
        <div className={classes.image} style={{backgroundImage: `url(${image})`}}>
            <div className={classes.root}>
                <Typography variant={'h2'} className={classes.title} component={Link} href={href} as={as}>
                    {title}
                </Typography>
                <Typography variant={'body1'} color={'inherit'}>
                    {description} {elementIndex}
                </Typography>
            </div>
        </div>
    );
}

export default HistoryArticleGridItem;
