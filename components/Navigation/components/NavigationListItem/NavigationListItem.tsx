import {Button, Collapse, colors, ListItem} from '@material-ui/core';
import makeStyles from '@material-ui/core/styles/makeStyles';
import ExpandLessIcon from '@material-ui/icons/ExpandLess';
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';
import clsx from 'clsx';
import React, {useState} from 'react';
import Link from '../../../Link';

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
        color: theme.palette.icon,
        display: 'flex',
        alignItems: 'center',
        marginRight: theme.spacing(1),
    },
    expandIcon: {
        marginLeft: 'auto',
        height: 16,
        width: 16,
    },
    label: {
        display: 'flex',
        alignItems: 'center',
        marginLeft: 'auto',
    },
    active: {
        'color': theme.palette.primary.main,
        'fontWeight': theme.typography.fontWeightMedium,
        '& $icon': {
            color: theme.palette.primary.main,
        },
    },
}));

export interface NavigationListItemProps {
    className?: string;
    depth: number;
    href?: string;
    icon?: React.ComponentType<any>;
    label?: React.ComponentType<any>;
    open: boolean;
    title: string;
}

const NavigationListItem: React.FC<NavigationListItemProps> = (props) => {
    const {
        title,
        href,
        depth,
        children,
        icon: Icon,
        className,
        open: openProp,
        label: Label,
        ...rest
    } = props;

    const classes = useStyles();
    const [open, setOpen] = useState(openProp);

    const handleToggle = () => {
        setOpen((x) => !x);
    };

    let paddingLeft = 8;

    if (depth > 0) {
        paddingLeft = 32 + 8 * depth;
    }

    const style = {
        paddingLeft,
        flexGrow: 1,
        textDecoration: 'none',
    };

    if (children) {
        return (
            <ListItem
                {...rest}
                className={clsx(classes.item, className)}
                disableGutters
            >
                <Button
                    className={classes.button}
                    onClick={handleToggle}
                    style={style}
                >
                    {Icon && <Icon className={classes.icon}/>}
                    {title}
                    {open ? (
                        <ExpandLessIcon
                            className={classes.expandIcon}
                            color="inherit"
                        />
                    ) : (
                        <ExpandMoreIcon
                            className={classes.expandIcon}
                            color="inherit"
                        />
                    )}
                </Button>
                <Collapse in={open}>{children}</Collapse>
            </ListItem>
        );
    } else {

        return (
            <ListItem
                {...rest}
                className={clsx(classes.itemLeaf, className)}
                disableGutters={true}
            >
                {/*
                // @ts-ignore */}
                <Button
                    activeClassName={classes.active}
                    className={clsx(classes.buttonLeaf, `depth-${depth}`)}
                    component={Link}
                    style={style}
                    href={href}
                >
                    {Icon && <Icon className={classes.icon}/>}
                    {title}
                    {Label && (
                        <span className={classes.label}>
                            <Label/>
                        </span>
                    )}
                </Button>
            </ListItem>
        );
    }
};

NavigationListItem.defaultProps = {
    depth: 0,
    open: false,
};

export default NavigationListItem;
