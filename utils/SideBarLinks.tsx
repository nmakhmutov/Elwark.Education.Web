import CompanyIcon from '@material-ui/icons/BusinessSharp';
import HomeIcon from '@material-ui/icons/HomeOutlined';
import LocalCafeIcon from '@material-ui/icons/LocalCafe';
import MapIcon from '@material-ui/icons/Map';
import React from 'react';
import Links from './Links';

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

const SideBarLinks: SideBarPage[] = [
    {
        title: 'Pages',
        pages: [
            {
                title: 'Home',
                href: Links.Home,
                icon: HomeIcon,
            },
            {
                title: 'Map',
                href: Links.Map,
                icon: MapIcon,
            },
            {
                title: 'Coffee',
                href: Links.Coffee,
                icon: LocalCafeIcon,
            },
            {
                title: 'Companies',
                href: Links.Companies,
                icon: CompanyIcon,
            },
        ],
    },
];

export default SideBarLinks;
