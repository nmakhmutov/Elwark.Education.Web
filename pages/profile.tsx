import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/layout/Default/Layout';
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
        <DefaultLayout title={'Profile ' + props.user}>
        </DefaultLayout>
    );
};

Profile.getInitialProps = async ({query, req}) => {
    return ({user: 36});
};

export default Profile;
