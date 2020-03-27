import {Avatar, Card, CardContent, CardMedia, Divider, Grid, Typography} from '@material-ui/core';
import makeStyles from '@material-ui/core/styles/makeStyles';
import {CompanyShortModel} from 'api/bff/types';
import clsx from 'clsx';
import {Link} from 'components';
import React from 'react';
import {Links} from 'utils';
import {CompanyTabs} from 'utils/Links';

const useStyles = makeStyles((theme) => ({
    root: {},
    media: {
        height: 125,
    },
    content: {
        paddingTop: 0,
    },
    avatarContainer: {
        marginTop: -32,
        display: 'flex',
        justifyContent: 'center',
    },
    avatar: {
        height: 64,
        width: 64,
        borderWidth: 4,
        borderStyle: 'solid',
        borderColor: theme.palette.common.white,
    },
    divider: {
        margin: theme.spacing(2, 0),
    },
    button: {
        'textDecoration': 'none',
        '&:hover': {
            textDecoration: 'none',
        },
    },
}));

export interface CompanyCardProps {
    className?: string;
    company: CompanyShortModel;
}

const CompanyCard: React.FC<CompanyCardProps> = (props) => {
    const {className, company: {id, logotype, name, description}} = props;
    const classes = useStyles();
    const companyOverview = Links.Company(id, CompanyTabs.Overview);
    const companyCatalog = Links.Company(id, CompanyTabs.Catalog);
    const companyCafes = Links.Company(id, CompanyTabs.Cafes);

    return (
        <Card className={clsx(classes.root, className)}>
            <CardMedia
                className={classes.media}
                image={logotype.background}
            />
            <CardContent className={classes.content}>
                <div className={classes.avatarContainer}>
                    <Avatar
                        className={classes.avatar}
                        component={Link}
                        href={companyOverview.href}
                        as={companyOverview.as}
                        src={logotype.square}
                    />
                </div>
                <Typography
                    align={'center'}
                    component={Link}
                    display="block"
                    href={companyOverview.href}
                    as={companyOverview.as}
                    variant="h5">
                    {name}
                </Typography>
                <Typography align="center" variant="body2" noWrap={true}>
                    {description}
                </Typography>
                <Divider className={classes.divider}/>
                <Grid container={true} justify="space-between">
                    <Grid item={true}>
                        <Typography
                            align={'center'}
                            component={Link}
                            display="block"
                            href={companyCafes.href}
                            as={companyCafes.as}
                            variant="h6">
                            Cafes
                        </Typography>
                    </Grid>
                    <Grid item={true}>
                        <Typography
                            align={'center'}
                            component={Link}
                            display="block"
                            href={companyCatalog.href}
                            as={companyCatalog.as}
                            variant="h6">
                            Catalog
                        </Typography>
                    </Grid>
                </Grid>
            </CardContent>
        </Card>
    );
};

export default CompanyCard;
