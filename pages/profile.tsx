import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {useFetchUser} from 'lib/user';
import {NextPage} from 'next';
import React from 'react';
import {useFetchProfile} from 'lib/profile';

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
    const {profile} = useFetchProfile();

    return (
        <DefaultLayout title={'Profile ' + user?.name}>
            <pre>
                {JSON.stringify(user, null, 4)}
                {JSON.stringify(profile, null, 4)}
            </pre>
        </DefaultLayout>
    );
};

// export const getServerSideProps: GetServerSideProps<Props> = async ({req, res}) => {
// const tokenCache = await oidc.tokenCache(req as NextApiRequest, res as NextApiResponse);
// const {accessToken} = await tokenCache.getAccessToken({refresh: true})
//
// const user = await UserApi.get(accessToken!);
// return {props: {user: user.data}};
// }

export default Profile;
