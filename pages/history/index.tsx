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

const Profile: NextPage<Props> = (props) => {
    const classes = useStyles();

    return (
        <DefaultLayout title={'History page'}>
        </DefaultLayout>
    );
};

export default Profile;
