import {Card, CardContent, CardMedia, Typography} from '@material-ui/core';
import makeStyles from '@material-ui/core/styles/makeStyles';
import {Storage} from 'api';
import {CompanyCatalogItem} from 'api/bff/types';
import clsx from 'clsx';
import {Link} from 'components';
import React from 'react';

const useStyles = makeStyles((theme) => ({
    root: {},
    media: {
        height: 125,
    },
    content: {
        paddingTop: 0,
    },
}));

export interface CatalogItemCardProps {
    className?: string;
    item: CompanyCatalogItem;
}

const CatalogItemCard: React.FC<CatalogItemCardProps> = (props) => {
    const {className, item} = props;
    const classes = useStyles();

    return (
        <Card className={clsx(classes.root, className)}>
            <CardMedia className={classes.media} image={item.image || Storage.Images.Empty}/>
            <CardContent className={classes.content}>
                <Typography
                    align={'center'}
                    component={Link}
                    display={'block'}
                    href={''}
                    variant={'h5'}>
                    {item.name}
                </Typography>

            </CardContent>
        </Card>
    );
};

export default CatalogItemCard;
