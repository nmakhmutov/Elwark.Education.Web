import {Avatar, colors, ListItem, ListItemAvatar, ListItemText, makeStyles} from '@material-ui/core';
import {CoffeeCategoryModel} from 'api/bff/types';
import clsx from 'clsx';
import {Link} from 'components';
import React from 'react';

const useStyles = makeStyles((theme) => ({
    active: {
        boxShadow: `inset 4px 0px 0px ${theme.palette.primary.main}`,
        backgroundColor: colors.grey[50],
    },
    avatar: {
        height: 40,
        width: 40,
    },
    details: {
        marginLeft: theme.spacing(2),
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'flex-end',
    },
    unread: {
        marginTop: 2,
        padding: 2,
        height: 18,
        minWidth: 18,
    },
}));

export interface CoffeeListItemProps {
    className?: string;
    category: CoffeeCategoryModel;
    active: boolean;
}

const CoffeeListItem: React.FC<CoffeeListItemProps> = (props) => {
    const {active, category, className, ...rest} = props;
    const classes = useStyles();

    return (
        <ListItem
            {...rest}
            button
            className={clsx(
                {
                    [classes.active]: active,
                },
                className,
            )}
            component={Link}
            href={`/coffee?id=${category.id}`}
        >
            <ListItemAvatar>
                {category.image
                    ? (<Avatar alt="Coffee type" className={classes.avatar} src={category.image}/>)
                    : (<Avatar alt="Coffee type" className={classes.avatar}>{category.name[0].toUpperCase()}</Avatar>)
                }
            </ListItemAvatar>
            <ListItemText
                primary={category.name}
                primaryTypographyProps={{
                    noWrap: true,
                    variant: 'h6',
                }}
                secondary={category.description}
                secondaryTypographyProps={{
                    noWrap: true,
                    variant: 'body1',
                }}
            />
            <div className={classes.details}>
            </div>
        </ListItem>
    );
};

export default CoffeeListItem;
