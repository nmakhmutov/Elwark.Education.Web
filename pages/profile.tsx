import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {fetchUser, useFetchUser} from 'lib/utils/user';
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
    const {user} = useFetchUser();

    return (
        <DefaultLayout title={'Profile ' + props.user}>
            <pre>
                {JSON.stringify(user, null, 4)}
            </pre>
        </DefaultLayout>
    );
};

Profile.getInitialProps = async ({query, req}) => {
    return ({user: 36});
};

export default Profile;
