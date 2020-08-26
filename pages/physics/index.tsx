import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {NextPage} from 'next';
import React from 'react';

const useStyles = makeStyles((theme) => ({
    root: {
        padding: theme.spacing(3),
    }
}));

type Props = {
    user: number
}

const PhysicsPage: NextPage<Props> = (props) => {
    const classes = useStyles();

    return (
        <DefaultLayout title={'History page'}>
            <h1>Physics</h1>
        </DefaultLayout>
    );
};

export default PhysicsPage;
