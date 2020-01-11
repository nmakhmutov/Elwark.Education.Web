import {Grid, IconButton} from '@material-ui/core';
import makeStyles from '@material-ui/core/styles/makeStyles';
import ChevronLeftIcon from '@material-ui/icons/ChevronLeft';
import ChevronRightIcon from '@material-ui/icons/ChevronRight';
import {Bff} from 'api';
import {CompanyShortModel} from 'api/bff/types';
import {Link} from 'components';
import {DefaultLayout} from 'layouts';
import {NextPage} from 'next';
import React, {useEffect, useRef} from 'react';
import {Links} from 'utils';
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

interface CompaniesProps {
    page: number;
    companies: CompanyShortModel[];
}

const limit = 30;

const Index: NextPage<CompaniesProps> = (props) => {
    const classes = useStyles();
    const {page, companies} = props;
    const ref = useRef<HTMLDivElement>(null);

    useEffect(() => {
        setTimeout(() => ref.current?.scrollIntoView({behavior: 'smooth'}), 10);
    }, [page]);

    return (
        <DefaultLayout title={'Companies'}>
            <div className={classes.root} ref={ref}>
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
                    <IconButton disabled={page <= 1}
                                component={Link}
                                href={Links.CompaniesPaging(page - 1)}>
                        <ChevronLeftIcon/>
                    </IconButton>
                    <IconButton disabled={companies.length !== limit}
                                component={Link}
                                href={Links.CompaniesPaging(page + 1)}>
                        <ChevronRightIcon/>
                    </IconButton>
                </div>
            </div>
        </DefaultLayout>
    );
};

Index.getInitialProps = async ({query, req}) => {
    const page = +(query.page as string) || 1;
    const offset = (page - 1) * limit;
    const companies = await Bff.Company.List(limit, offset);

    return {
        page,
        companies,
    } as CompaniesProps;
};

export default Index;
