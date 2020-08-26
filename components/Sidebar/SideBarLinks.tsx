import AccountBalanceIcon from '@material-ui/icons/AccountBalance';
import React from 'react';
import Links from 'lib/utils/Links';
import Atom from 'components/icons/Atom';

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
        title: 'Subjects',
        pages: [
            {
                title: 'History',
                href: Links.History,
                icon: AccountBalanceIcon,
            },
            {
                title: 'Physics',
                href: Links.Physics,
                icon: Atom,
            },
        ],
    },
];

export default SideBarLinks;
