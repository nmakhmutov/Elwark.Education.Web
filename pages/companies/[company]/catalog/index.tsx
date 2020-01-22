import {Grid} from '@material-ui/core';
import {Bff} from 'api';
import {CompanyCatalogItem, CompanyModel} from 'api/bff/types';
import {CompanyLayout} from 'layouts';
import {NextPage} from 'next';
import React from 'react';
import {CompanyTabs} from 'utils/Links';
import {CatalogItemCard} from './components';

interface CatalogProps {
    company: CompanyModel;
    catalog: CompanyCatalogItem[];
}

const Catalog: NextPage<CatalogProps> = (props) => {
    const {company, catalog} = props;

    return (
        <CompanyLayout title={`Catalog of ${company.name}`} tab={CompanyTabs.Catalog} company={company}>
            <Grid container={true} spacing={2}>
                {catalog.map((item) =>
                    (<Grid key={item.catalogItemId} item={true} xs={12} md={4} lg={3}>
                        <CatalogItemCard item={item}/>
                    </Grid>),
                )}
            </Grid>
        </CompanyLayout>
    );
};

Catalog.getInitialProps = async ({query}) => {
    const companyId = +query.company;
    const company = await Bff.Company.Get(companyId);
    const catalog = await Bff.Company.Catalog(companyId);

    return {company, catalog} as CatalogProps;
};

export default Catalog;
