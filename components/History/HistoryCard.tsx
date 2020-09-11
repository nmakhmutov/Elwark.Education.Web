import {makeStyles} from '@material-ui/styles';
import {
    Card,
    CardActions,
    CardContent,
    CardHeader,
    CardMedia,
    createStyles,
    Theme,
    Typography
} from '@material-ui/core';
import React from 'react';
import clsx from 'clsx';

const useStyles = makeStyles((theme: Theme) =>
    createStyles({
        root: {
            // maxWidth: 345
            display: 'flex'
        },
        details: {
            display: 'flex',
            width: '100%'
        },
        row: {
            flexDirection: 'row',
            '& > $media': {
                minWidth: 150,
                minHeight: 150,
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
            flexBasis: '75%'
        },
        media: {}
    })
);

type Props = {
    className?: string,
    title: React.ReactNode,
    direction: 'row' | 'column'
    subtitle?: React.ReactNode,
    image?: string,
    description?: string,
    actions?: React.ReactNode
}

const HistoryCard: React.FC<Props> = ({title, direction, image, subtitle, description, actions, className}) => {
    const classes = useStyles();

    return (
        <Card className={clsx(classes.root, className)}>
            <div className={clsx(classes.details, direction === 'row' ? classes.row : classes.column)}>
                {image && <CardMedia className={classes.media} image={image}/>}
                <div className={classes.content}>
                    <CardHeader title={title} subheader={subtitle}/>
                    {description && <CardContent>
                        <Typography variant={'body1'} color={'textSecondary'} component={'p'}>
                            {description}
                        </Typography>
                    </CardContent>}
                    <CardActions disableSpacing={false}>
                        {actions}
                    </CardActions>
                </div>
            </div>
        </Card>
    );
};

export default HistoryCard;
