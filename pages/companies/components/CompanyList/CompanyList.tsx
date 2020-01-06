import {Grid, IconButton} from '@material-ui/core';
import makeStyles from '@material-ui/core/styles/makeStyles';
import ChevronLeftIcon from '@material-ui/icons/ChevronLeft';
import ChevronRightIcon from '@material-ui/icons/ChevronRight';
import {CompanyShortModel} from 'api/bff/types';
import React, {MutableRefObject, useRef} from 'react';
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

    onPrevClick: (container: React.MutableRefObject<HTMLDivElement | null>) => Promise<void>;
    onPrevDisabled: boolean;

    onNextClick: (container: MutableRefObject<HTMLDivElement | null>) => Promise<void>;
    onNextDisabled: boolean;
}

const CompanyList: React.FC<CompanyListProps> = (props) => {
    const classes = useStyles();

    const {companies, onNextClick, onNextDisabled, onPrevClick, onPrevDisabled} = props;
    const contentRef = useRef<null | HTMLDivElement>(null);

    return (
        <div className={classes.root}>
            <CompanyToolbar/>
            <div className={classes.content} ref={contentRef}>
                <Grid container={true} spacing={3}>
                    {companies.map((company) => (
                        <Grid item={true} key={company.id} lg={4} md={6} xs={12}>
                            <CompanyCard company={company}/>
                        </Grid>
                    ))}
                </Grid>
            </div>
            <div className={classes.pagination}>
                <IconButton onClick={() => onPrevClick(contentRef)} disabled={onPrevDisabled}>
                    <ChevronLeftIcon/>
                </IconButton>
                <IconButton onClick={() => onNextClick(contentRef)} disabled={onNextDisabled}>
                    <ChevronRightIcon/>
                </IconButton>
            </div>
        </div>
    );
};

export default CompanyList;
