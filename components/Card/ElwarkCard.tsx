import {makeStyles} from '@material-ui/styles';
import {Card, CardActions, CardContent, CardHeader, CardMedia, Divider, Theme, Typography} from '@material-ui/core';
import React from 'react';
import clsx from 'clsx';

const useStyles = makeStyles((theme: Theme) => ({
    root: {
        display: 'flex'
    },
    details: {
        display: 'flex',
        width: '100%'
    },
    row: {
        flexDirection: 'row',
        '& > $media': {
            minHeight: 200,
            maxWidth: 200,
            flexBasis: '25%'
        }
    },
    column: {
        flexDirection: 'column',
        '& > $media': {
            height: 0,
            paddingTop: '56.25%' // 16:9
        }
    },
    content: {
        flex: '1 1 auto',
        flexBasis: '75%',
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'space-between'
    },
    media: {}
}));

type Props = {
    className?: string,
    title: React.ReactNode,
    direction: 'row' | 'column'
    subtitle?: React.ReactNode,
    image?: string,
    description?: string,
    actions?: React.ReactNode
}

const ElwarkCard: React.FC<Props> = ({title, direction, image, subtitle, description, actions, className}) => {
    const classes = useStyles();

    return (
        <Card className={clsx(classes.root, className)}>
            <div className={clsx(classes.details, direction === 'row' ? classes.row : classes.column)}>
                {image && <CardMedia className={classes.media} image={image}/>}
                <div className={classes.content}>
                    <CardHeader title={title} subheader={subtitle}/>
                    {description && <CardContent>
                        <Typography variant={'body1'} color={'textPrimary'} component={'p'}>
                            {description}
                        </Typography>
                    </CardContent>}
                    {actions && <div>
                        <Divider/>
                        <CardActions>
                            {actions}
                        </CardActions>
                    </div>}
                </div>
            </div>
        </Card>
    );
};

export default ElwarkCard;
