import CompanyIcon from '@material-ui/icons/BusinessSharp';
import HomeIcon from '@material-ui/icons/HomeOutlined';
import LocalCafeIcon from '@material-ui/icons/LocalCafe';
import MapIcon from '@material-ui/icons/Map';
import React from 'react';

export interface Page {
    title: string;
    href: string;
    icon?: React.FC;
    label?: React.FC;
    children?: Page[];
}

export interface SideBarPage {
    title: string;
    pages: Page[];
}

const Pages: SideBarPage[] = [
    {
        title: 'Pages',
        pages: [
            {
                title: 'Home',
                href: '/',
                icon: HomeIcon,
            },
            {
                title: 'Map',
                href: '/map',
                icon: MapIcon,
            },
            {
                title: 'Coffee',
                href: '/coffee',
                icon: LocalCafeIcon,
            },
            {
                title: 'Companies',
                href: '/companies',
                icon: CompanyIcon,
            },
        ],
    },
];

export default Pages;
