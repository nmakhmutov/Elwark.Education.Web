import {Avatar, Card, CardContent, CardHeader, CardMedia, makeStyles, Typography,} from '@material-ui/core';
import {CoffeeHouseMapPoint} from 'api/bff/types';
import {Link, RatingText, VotersText} from 'components';
import React from 'react';
import {Links} from 'utils';
import {CompanyTabs} from 'utils/Links';

const useStyles = makeStyles((theme) => ({
    card: {
        maxWidth: 345,
        margin: '-14px -20px',
        boxShadow: 'none',
    },
    media: {
        height: 0,
        paddingTop: '56.25%', // 16:9
    },
    button: {
        '&:hover': {
            textDecoration: 'none',
        },
    },
}));

interface PopupCardProps {
    point: CoffeeHouseMapPoint;
}

const PopupCard: React.FC<PopupCardProps> = (props) => {
    const {point} = props;
    const classes = useStyles();
    const companyLink = Links.Company(point.company.id, CompanyTabs.Overview);
    const cafeLink = Links.CafeOverview(point.cafeId);

    return (
        <Card className={classes.card}>
            <CardHeader
                avatar={<Avatar src={point.company.logotype.rectangle} alt={point.name}/>}
                title={<Link href={companyLink.href} as={companyLink.as}>{point.company.name}</Link>}
                titleTypographyProps={{variant: 'body1'}}
                subheader={point.address}
            />
            {point.image &&
            <CardMedia
                className={classes.media}
                image={point.image}
                title={point.name}
            />
            }
            <CardContent>
                <Typography
                    align={'center'}
                    component={Link}
                    display={'block'}
                    href={cafeLink.href}
                    as={cafeLink.as}
                    variant={'h5'}>
                    {point.name}
                </Typography>
                <Typography variant={'h3'} align={'center'}>
                    <RatingText value={point.rating.value}/>
                </Typography>
                <Typography variant={'body2'} align={'center'} component={'div'}>
                    <VotersText value={point.rating.voters}/>
                </Typography>
            </CardContent>
        </Card>
    );
};

export default PopupCard;
