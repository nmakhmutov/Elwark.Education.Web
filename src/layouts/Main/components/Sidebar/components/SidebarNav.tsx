import makeStyles from "@material-ui/core/styles/makeStyles";
import {colors} from "@material-ui/core";
import React from "react";
import List from "@material-ui/core/List";
import clsx from "clsx";
import ListItem from "@material-ui/core/ListItem";
import Button from "@material-ui/core/Button";
import Link from "../../../../../Link";

const useStyles = makeStyles(theme => ({
    root: {},
    item: {
        display: 'flex',
        paddingTop: 0,
        paddingBottom: 0
    },
    button: {
        color: colors.blueGrey[800],
        padding: '10px 8px',
        justifyContent: 'flex-start',
        textTransform: 'none',
        letterSpacing: 0,
        width: '100%',
        fontWeight: theme.typography.fontWeightMedium,
        '&:hover': {
            textDecoration: 'none'
        }
    },
    icon: {
        color: colors.blueGrey[800],
        width: 24,
        height: 24,
        display: 'flex',
        alignItems: 'center',
        marginRight: theme.spacing(1)
    },
    active: {
        color: theme.palette.primary.main,
        fontWeight: theme.typography.fontWeightMedium,
        '& $icon': {
            color: theme.palette.primary.main
        }
    }
}));

export interface SidebarPage {
    title: string,
    href: string,
    icon: JSX.Element
}

export interface SidebarNavProps {
    className?: string,
    pages: SidebarPage[],
}

const SidebarNav: React.FC<SidebarNavProps> = (props) => {
    const {pages, className, ...rest} = props;

    const classes = useStyles();

    return (
        <List
            {...rest}
            className={clsx(classes.root, className)}>
            {
                pages.map(page => (
                    <ListItem
                        className={classes.item}
                        disableGutters
                        key={page.title}
                    >
                        <Button
                            activeClassName={classes.active}
                            className={classes.button}
                            component={Link}
                            href={page.href}
                        >
                            <div className={classes.icon}>{page.icon}</div>
                            {page.title}
                        </Button>
                    </ListItem>
                ))
            }
        </List>
    );
};

export default SidebarNav;