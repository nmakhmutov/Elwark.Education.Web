import {Avatar, Card, CardContent, CardMedia, Divider, Typography} from '@material-ui/core';
import makeStyles from '@material-ui/core/styles/makeStyles';
import {Storage} from 'api';
import {CompanyCafeItem} from 'api/bff/types';
import clsx from 'clsx';
import {Link} from 'components';
import React from 'react';
import {Links} from 'utils';

const useStyles = makeStyles((theme) => ({
    root: {},
    media: {
        height: 125,
    },
    content: {
        paddingTop: 0,
    },
    avatarContainer: {
        marginTop: -32,
        display: 'flex',
        justifyContent: 'center',
    },
    avatar: {
        height: 64,
        width: 64,
        borderWidth: 4,
        borderStyle: 'solid',
        borderColor: theme.palette.common.white,
    },
    divider: {
        margin: theme.spacing(2, 0),
    },
}));

export interface CafeCardProps {
    className?: string;
    cafe: CompanyCafeItem;
}

const CafeCard: React.FC<CafeCardProps> = (props) => {
    const {className, cafe, ...rest} = props;
    const classes = useStyles();

    const cafeOverview = Links.CafeOverview(cafe.cafeId);

    return (
        <Card {...rest} className={clsx(classes.root, className)}>
            <CardMedia className={classes.media} image={cafe.image || Storage.Images.Empty}/>
            <CardContent className={classes.content}>
                <div className={classes.avatarContainer}>
                    <Avatar
                        alt={'Country'}
                        className={classes.avatar}
                        src={Storage.Images.CountryFlag(cafe.country.code.toLocaleLowerCase())}
                    />
                </div>
                <Typography align={'center'} variant={'body1'}>
                    {cafe.city.name}
                </Typography>
                <Typography align={'center'} variant={'body2'}>
                    {cafe.address}
                </Typography>
                <Divider className={classes.divider}/>
                <Typography
                    align={'center'}
                    component={Link}
                    display={'block'}
                    href={cafeOverview.href}
                    as={cafeOverview.as}
                    variant={'h5'}>
                    {cafe.name}
                </Typography>

            </CardContent>
        </Card>
    );
};

export default CafeCard;
