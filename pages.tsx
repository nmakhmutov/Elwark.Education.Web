import DashboardIcon from '@material-ui/icons/Dashboard';
import MapIcon from '@material-ui/icons/Map';
import PeopleIcon from '@material-ui/icons/People';
import React from 'react';

export interface SidebarPage {
    title: string;
    href: string;
    icon: JSX.Element;
}

const pages: SidebarPage[] = [
    {
        title: 'Home',
        href: '/',
        icon: <DashboardIcon/>,
    },
    {
        title: 'Map',
        href: '/map',
        icon: <MapIcon/>,
    },
    {
        title: 'Companies',
        href: '/companies',
        icon: <PeopleIcon/>,
    },
];

export default pages;
