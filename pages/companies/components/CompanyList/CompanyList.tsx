import {Grid, IconButton, Typography} from '@material-ui/core';
import makeStyles from '@material-ui/core/styles/makeStyles';
import ChevronLeftIcon from '@material-ui/icons/ChevronLeft';
import ChevronRightIcon from '@material-ui/icons/ChevronRight';
import React from 'react';
import {CompanyShortModel} from '../../../../interfaces';
import {CompanyCard, CompanyToolbar} from './components';

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

    onPrevClick: () => void;
    onPrevDisabled: boolean;

    onNextClick: () => void;
    onNextDisabled: boolean;
}

const CompanyList: React.FC<CompanyListProps> = (props) => {
    const classes = useStyles();

    const {companies, onNextClick, onNextDisabled, onPrevClick, onPrevDisabled} = props;

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
                <IconButton onClick={onPrevClick} disabled={onPrevDisabled}>
                    <ChevronLeftIcon/>
                </IconButton>
                <IconButton onClick={onNextClick} disabled={onNextDisabled}>
                    <ChevronRightIcon/>
                </IconButton>
            </div>
        </div>
    );
};

export default CompanyList;
