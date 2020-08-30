import {Link} from 'components';
import {Breadcrumbs as UiBreadcrumbs, Theme, Typography} from '@material-ui/core';
import React from 'react';
import {makeStyles} from '@material-ui/styles';
import NavigateNextIcon from '@material-ui/icons/NavigateNext';
import clsx from 'clsx';

const useStyles = makeStyles((theme: Theme) => ({
    root: {}
}));

type Props = {
    className?: string,
    paths: { title: string, link?: { href: string, as?: string } }[]
}

const Breadcrumbs: React.FC<Props> = (props) => {
    const {className, paths} = props;
    const classes = useStyles();

    return (
        <UiBreadcrumbs
            className={clsx(classes.root, className)}
            separator={<NavigateNextIcon fontSize="small"/>}
            aria-label="breadcrumb">
            {paths.map((path) => {
                if (path.link)
                    return (
                        <Link color="inherit" href={path.link.href} as={path.link.as}>
                            {path.title}
                        </Link>
                    );

                return (
                    <Typography color="textPrimary">
                        {path.title}
                    </Typography>
                )
            })}
        </UiBreadcrumbs>
    )
}

export default Breadcrumbs;
