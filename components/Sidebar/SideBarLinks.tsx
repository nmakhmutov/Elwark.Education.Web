import AccountBalanceIcon from '@material-ui/icons/AccountBalance';
import React from 'react';
import WebLinks from 'lib/WebLinks';
import Atom from 'components/icons/Atom';
import DonutLargeIcon from '@material-ui/icons/DonutLarge';
import PersonIcon from '@material-ui/icons/Person';

export interface Page
{
    title: string;
    href: string;
    target?: string;
    icon?: React.FC;
    label?: React.FC;
    children?: Page[];
}

export interface SideBarPage
{
    title: string;
    pages: Page[];
}

const SideBarLinks: SideBarPage[] = [
    {
        title: '',
        pages: [
            {
                title: 'My Account',
                href: WebLinks.Account,
                target: '_blank',
                icon: PersonIcon
            },
            {
                title: 'Profile',
                href: WebLinks.Profile,
                icon: DonutLargeIcon
            }
        ]
    },
    {
        title: 'Subjects',
        pages: [
            {
                title: 'History',
                href: WebLinks.History,
                icon: AccountBalanceIcon,
                children: [
                    {
                        title: 'Prehistory',
                        href: WebLinks.HistoryPeriod('prehistory')
                    },
                    {
                        title: 'Ancient',
                        href: WebLinks.HistoryPeriod('ancient')
                    }
                ]
            },
            {
                title: 'Physics',
                href: WebLinks.Physics,
                icon: Atom
            }
        ]
    }
];

export default SideBarLinks;
