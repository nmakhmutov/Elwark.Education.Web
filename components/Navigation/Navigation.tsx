import {List, Typography} from '@material-ui/core';
import makeStyles from '@material-ui/core/styles/makeStyles';
import clsx from 'clsx';
import {NextRouter, useRouter} from 'next/router';
import React from 'react';
import {Page} from 'utils/SideBarLinks';

import {NavigationListItem} from './components';

const useStyles = makeStyles((theme) => ({
    root: {
        marginBottom: theme.spacing(3),
    },
}));

interface NavigationListProps {
    depth?: number;
    pages: Page[];
    router: NextRouter;
}

const NavigationList: React.FC<NavigationListProps> = (props) => {
    const {pages, ...rest} = props;

    return (
        <List>
            {pages.reduce((items, page) => reduceChildRoutes({items, page, ...rest}), [])}
        </List>
    );
};

const reduceChildRoutes = (props: any) => {
    const {router, items, page, depth} = props;
    const open = router.pathname === page.href;

    if (page.children) {
        items.push(
            <NavigationListItem
                depth={depth}
                icon={page.icon}
                key={page.title}
                label={page.label}
                open={open}
                title={page.title}
            >
                <NavigationList depth={depth + 1} pages={page.children} router={router}/>
            </NavigationListItem>,
        );
    } else {
        items.push(
            <NavigationListItem
                open={false}
                depth={depth}
                href={page.href}
                icon={page.icon}
                key={page.title}
                label={page.label}
                title={page.title}
            />,
        );
    }

    return items;
};

export interface NavigationProps {
    className?: string;
    component?: any;
    pages: Page[];
    title?: string;
}

const Navigation: React.FC<NavigationProps> = (props) => {
    const {title, pages, className, component: Component, ...rest} = props;

    const classes = useStyles();
    const router = useRouter();

    return (
        <Component {...rest} className={clsx(classes.root, className)}>
            {title && <Typography variant="overline">{title}</Typography>}
            <NavigationList depth={0} pages={pages} router={router}/>
        </Component>
    );
};

Navigation.defaultProps = {
    component: 'nav',
};

export default Navigation;
