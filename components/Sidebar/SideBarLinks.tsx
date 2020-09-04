import AccountBalanceIcon from '@material-ui/icons/AccountBalance';
import React from 'react';
import Links from 'lib/utils/Links';
import Atom from 'components/icons/Atom';
import DonutLargeIcon from '@material-ui/icons/DonutLarge';
import PersonIcon from '@material-ui/icons/Person';

export interface Page {
    title: string;
    href: string;
    target?: string;
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
        title: '',
        pages: [
            {
                title: 'My Account',
                href: Links.Account,
                target: '_blank',
                icon: PersonIcon
            },
            {
                title: 'Profile',
                href: Links.Profile,
                icon: DonutLargeIcon,
            }
        ]
    },
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
