import CompanyIcon from '@material-ui/icons/BusinessSharp';
import HomeIcon from '@material-ui/icons/HomeOutlined';
import MapIcon from '@material-ui/icons/Map';

import React from 'react';

export default [
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
                title: 'Companies',
                href: '/companies',
                icon: CompanyIcon,
            },
        ],
    },
];
