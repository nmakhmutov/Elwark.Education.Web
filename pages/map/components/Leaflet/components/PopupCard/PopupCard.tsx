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
import {RatingText, VotersText} from 'components';
import React from 'react';

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
}));

interface PopupCardProps {
    point: CoffeeHouseMapPoint;
}

const PopupCard: React.FC<PopupCardProps> = (props) => {
    const {point} = props;
    const classes = useStyles();
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
                <Button size="small" color="primary">
                    Learn More
                </Button>
            </CardActions>
        </Card>
    );
};

export default PopupCard;
