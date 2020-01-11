import {Card, CardActions, CardContent, Divider, Grid, Typography} from '@material-ui/core';
import makeStyles from '@material-ui/core/styles/makeStyles';
import AccessTimeIcon from '@material-ui/icons/AccessTime';
import GetAppIcon from '@material-ui/icons/GetApp';
import {CompanyShortModel} from 'api/bff/types';
import clsx from 'clsx';
import {Link} from 'components';
import React from 'react';
import {Links} from 'utils';
import {CompanyTabs} from 'utils/Links';

const useStyles = makeStyles((theme) => ({
    root: {},
    imageContainer: {
        height: 64,
        width: 64,
        margin: '0 auto',
        border: `1px solid ${theme.palette.divider}`,
        borderRadius: '5px',
        overflow: 'hidden',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
    },
    image: {
        width: '100%',
    },
    statsItem: {
        display: 'flex',
        alignItems: 'center',
    },
    statsIcon: {
        color: theme.palette.grey['700'],
        marginRight: theme.spacing(1),
    },
}));

export interface CompanyCardProps {
    className?: string;
    company: CompanyShortModel;
}

const CompanyCard: React.FC<CompanyCardProps> = (props) => {
    const {className, company, ...rest} = props;
    const classes = useStyles();
    const companyOverview = Links.Company(company.id, CompanyTabs.Overview);
    return (
        <Card
            {...rest}
            className={clsx(classes.root, className)}
        >
            <CardContent>
                <div className={classes.imageContainer}>
                    <img alt="Company logotype" className={classes.image} src={company.logotype.square}/>
                </div>
                <Typography align={'center'} gutterBottom={true} variant={'h4'}>
                    <Link href={companyOverview.href} as={companyOverview.as}>
                        {company.name}
                    </Link>
                </Typography>
                <Typography align={'center'} variant={'body1'}>
                    {company.name}
                </Typography>
            </CardContent>
            <Divider/>
            <CardActions>
                <Grid container justify="space-between">
                    <Grid className={classes.statsItem} item={true}>
                        <AccessTimeIcon className={classes.statsIcon}/>
                        <Typography display="inline" variant="body2">
                            Updated 2hr ago
                        </Typography>
                    </Grid>
                    <Grid className={classes.statsItem} item>
                        <GetAppIcon className={classes.statsIcon}/>
                        <Typography display="inline" variant="body2">
                            {company.id} Downloads
                        </Typography>
                    </Grid>
                </Grid>
            </CardActions>
        </Card>
    );
};

export default CompanyCard;
