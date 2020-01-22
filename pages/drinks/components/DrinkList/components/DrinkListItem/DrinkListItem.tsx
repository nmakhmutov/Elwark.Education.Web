import {Avatar, Button, Collapse, colors, ListItem, makeStyles} from '@material-ui/core';
import ExpandLessIcon from '@material-ui/icons/ExpandLess';
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';
import clsx from 'clsx';
import {Link} from 'components';
import React, {useState} from 'react';

const useStyles = makeStyles((theme) => ({
    item: {
        display: 'block',
        paddingTop: 0,
        paddingBottom: 0,
    },
    itemLeaf: {
        display: 'flex',
        paddingTop: 0,
        paddingBottom: 0,
    },
    button: {
        color: colors.blueGrey[800],
        padding: '10px 8px',
        justifyContent: 'flex-start',
        textTransform: 'none',
        letterSpacing: 0,
        width: '100%',
    },
    buttonLeaf: {
        'color': colors.blueGrey[800],
        'padding': '10px 8px',
        'justifyContent': 'flex-start',
        'textTransform': 'none',
        'letterSpacing': 0,
        'width': '100%',
        'fontWeight': theme.typography.fontWeightRegular,
        '&.depth-0': {
            fontWeight: theme.typography.fontWeightMedium,
        },
    },
    icon: {
        color: theme.palette.common.white,
        display: 'flex',
        alignItems: 'center',
        marginRight: theme.spacing(1),
    },
    expandIcon: {
        marginLeft: 'auto',
        height: 16,
        width: 16,
    },
    active: {
        'color': theme.palette.primary.main,
        'fontWeight': theme.typography.fontWeightMedium,
        '& $icon': {
            color: theme.palette.primary.main,
        },
    },
}));

export interface CoffeeListItemProps {
    className?: string;
    open: boolean;
    depth: number;
    image?: string;
    title: string;
    href?: string;
}

const DrinkImage: React.FC<{ image?: string, title: string, className: string }> = (props) => {
    const {image, title, className} = props;
    if (image) {
        return (<Avatar alt={'Coffee type'} className={className} src={image}/>);
    }

    return (<Avatar alt={'Coffee type'} className={className}>{title[0].toUpperCase()}</Avatar>);
};

const DrinkListItem: React.FC<CoffeeListItemProps> = (props) => {
    const classes = useStyles();
    const {className, open: openProp, depth, image, title, href, children} = props;
    const [open, setOpen] = useState(openProp);

    const handleToggle = () => setOpen((x) => !x);

    let paddingLeft = 8;

    if (depth > 0) {
        paddingLeft = 16 + 8 * depth;
    }

    const style = {
        paddingLeft,
        flexGrow: 1,
        textDecoration: 'none',
    };

    if (children) {
        return (
            <ListItem className={clsx(classes.item, className)} disableGutters={true}>
                <Button className={classes.button} onClick={handleToggle} style={style}>
                    <DrinkImage title={title} className={classes.icon} image={image}/>
                    {title}
                    {open
                        ? (<ExpandLessIcon className={classes.expandIcon} color={'inherit'}/>)
                        : (<ExpandMoreIcon className={classes.expandIcon} color={'inherit'}/>)
                    }
                </Button>
                <Collapse in={open}>{children}</Collapse>
            </ListItem>
        );
    }

    return (
        <ListItem className={clsx(classes.itemLeaf, className)} disableGutters={true}>
            {/*
            // @ts-ignore*/}
            <Button
                activeClassName={classes.active}
                className={clsx(classes.buttonLeaf, `depth-${depth}`)}
                component={Link}
                style={style}
                href={href}
            >
                <DrinkImage title={title} className={classes.icon} image={image}/>
                {title}
            </Button>
        </ListItem>
    );
};

export default DrinkListItem;
