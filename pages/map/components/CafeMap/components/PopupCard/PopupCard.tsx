import {
    Avatar,
    Button,
    Card,
    CardActions,
    CardContent,
    CardHeader,
    CardMedia,
    makeStyles,
    Typography,
} from '@material-ui/core';
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
    const companyLink = Links.Company(point.companyId, CompanyTabs.Overview);
    const cafeLink = Links.CafeOverview(point.cafeId);

    return (
        <Card className={classes.card}>
            <CardHeader
                avatar={<Avatar src={point.logo} alt={point.name}/>}
                title={point.name}
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
                <Typography variant={'h3'} align={'center'}>
                    <RatingText value={point.rating.value}/>
                </Typography>
                <Typography variant={'body2'} align={'center'} component={'div'}>
                    <VotersText value={point.rating.voters}/>
                </Typography>
            </CardContent>
            <CardActions disableSpacing>
                <Button className={classes.button}
                        size={'small'}
                        color={'primary'}
                        component={Link}
                        href={cafeLink.href}
                        as={cafeLink.as}>
                    Cafe
                </Button>
                <Button className={classes.button}
                        size={'small'}
                        color={'primary'}
                        component={Link}
                        href={companyLink.href}
                        as={companyLink.as}>
                    Company
                </Button>
            </CardActions>
        </Card>
    );
};

export default PopupCard;
