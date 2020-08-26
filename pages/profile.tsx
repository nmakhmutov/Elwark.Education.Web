import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {useFetchUser} from 'lib/utils/user';
import {GetServerSideProps, NextPage} from 'next';
import React from 'react';
import oidc from 'lib/oidc';
import UserApi from 'lib/api/user';

const useStyles = makeStyles((theme) => ({
    root: {
        padding: theme.spacing(3),
    }
}));

type Props = {
    user: any
}

const Profile: NextPage<Props> = (props) => {
    const classes = useStyles();
    const {user} = useFetchUser();

    return (
        <DefaultLayout title={'Profile ' + props.user}>
            <pre>
                {JSON.stringify(user, null, 4)}
                {JSON.stringify(props.user, null, 4)}
            </pre>
        </DefaultLayout>
    );
};

export const getServerSideProps: GetServerSideProps = async ({req, res}) => {
    const tokenCache = await oidc.tokenCache(req, res);
    const {accessToken} = await tokenCache.getAccessToken({refresh: true})

    const user = await UserApi.get(accessToken!);
    return {props: {user: user.data} as Props};
}

export default Profile;
