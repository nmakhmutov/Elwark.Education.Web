import {Grid, IconButton, Typography} from '@material-ui/core';
import makeStyles from '@material-ui/core/styles/makeStyles';
import ChevronLeftIcon from '@material-ui/icons/ChevronLeft';
import ChevronRightIcon from '@material-ui/icons/ChevronRight';
import React, {useState} from 'react';
import {CompanyShortModel} from '../../interfaces';
import {CompanyToolbar} from './components';
import CompanyCard from './components/CompanyCard/CompanyCard';

const useStyles = makeStyles((theme) => ({
    root: {
        padding: theme.spacing(3),
    },
    content: {
        marginTop: theme.spacing(2),
    },
    pagination: {
        marginTop: theme.spacing(3),
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'flex-end',
    },
}));

export interface CompanyListProps {
    companies: CompanyShortModel[];
}

const CompanyList: React.FC<CompanyListProps> = (props) => {
    const classes = useStyles();

    const {companies} = props;

    return (
        <div className={classes.root}>
            <CompanyToolbar/>
            <div className={classes.content}>
                <Grid container={true} spacing={3}>
                    {companies.map((company) => (
                        <Grid item={true} key={company.id} lg={4} md={6} xs={12}>
                            <CompanyCard company={company}/>
                        </Grid>
                    ))}
                </Grid>
            </div>
            <div className={classes.pagination}>
                <Typography variant="caption">1-6 of 20</Typography>
                <IconButton>
                    <ChevronLeftIcon/>
                </IconButton>
                <IconButton>
                    <ChevronRightIcon/>
                </IconButton>
            </div>
        </div>
    );
};

export default CompanyList;
