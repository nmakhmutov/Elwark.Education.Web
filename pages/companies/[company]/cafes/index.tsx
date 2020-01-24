import {Grid} from '@material-ui/core';
import {Bff} from 'api';
import {CompanyCafeItem, CompanyModel} from 'api/bff/types';
import {CompanyLayout} from 'layouts';
import {NextPage} from 'next';
import React from 'react';
import {CompanyTabs} from 'utils/Links';
import {CafeCard} from './components';

interface CafeProps {
    company: CompanyModel;
    cafes: CompanyCafeItem[];
}

const Cafes: NextPage<CafeProps> = (props) => {
    const {company, cafes} = props;

    return (
        <CompanyLayout title={`Cafes of ${company.name}`} tab={CompanyTabs.Cafes} company={company}>
            <Grid container={true} spacing={2}>
                {cafes.map((cafe) =>
                    (<Grid key={cafe.cafeId} item={true} xs={12} md={4} lg={3}>
                        <CafeCard cafe={cafe} />
                    </Grid>),
                )}
            </Grid>
        </CompanyLayout>
    );
};

Cafes.getInitialProps = async ({query}) => {
    const companyId = +query.company;
    const company = await Bff.Company.Get(companyId);
    const cafes = await Bff.Company.Cafes(companyId, 24, 0);

    return {company, cafes} as CafeProps;
};

export default Cafes;
