import {Avatar, Card, CardContent, CardMedia, Divider, Grid, Typography} from '@material-ui/core';
import {CardProps} from '@material-ui/core/Card/Card';
import makeStyles from '@material-ui/core/styles/makeStyles';
import {Storage} from 'api';
import {CompanyCafeItem} from 'api/bff/types';
import clsx from 'clsx';
import Link from 'components/Link';
import RatingText from 'components/RatingText';
import VotersText from 'components/VotersText';
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
    rating: {
        marginTop: 12,
    },
}));

export interface CafeCardProps extends CardProps {
    className?: string;
    cafe: CompanyCafeItem;
}

const CafeCard: React.FC<CafeCardProps> = (props) => {
    const {className, cafe, ...rest} = props;
    const classes = useStyles();

    const overview = Links.CafeOverview(cafe.cafeId);
    const avatar = Storage.Images.CountryFlag(cafe.country.code.toLocaleLowerCase());

    return (
        <Card {...rest} className={clsx(classes.root, className)}>
            <CardMedia className={classes.media} image={cafe.image || Storage.Images.Empty}/>
            <CardContent className={classes.content}>
                <div className={classes.avatarContainer}>
                    <Avatar alt={'Country'} className={classes.avatar} src={avatar}/>
                </div>
                <Typography align={'center'} variant={'body1'}>
                    {cafe.city.name}
                </Typography>
                <Typography align={'center'} variant={'body2'}>
                    {cafe.address}
                </Typography>
                <Divider className={classes.divider}/>
                <Typography align={'center'} component={Link} display={'block'} href={overview.href} as={overview.as}
                            variant={'h5'}>
                    {cafe.name}
                </Typography>
                <Grid container={true} className={classes.rating}>
                    <Grid item={true} xs={6}>
                        <RatingText rating={cafe.rating.value} variant={'h5'}/>
                    </Grid>
                    <Grid item={true} xs={6}>
                        <VotersText voters={cafe.rating.voters} variant={'h6'} align={'right'}/>
                    </Grid>
                </Grid>
            </CardContent>
        </Card>
    );
};

export default CafeCard;
