import makeStyles from '@material-ui/core/styles/makeStyles';
import Link from 'components/Link';
import React from 'react';

const useStyles = makeStyles(() => ({

}));

const LandingLayout: React.FC = (props) => {
    const classes = useStyles();

    return (
        <div>
            Landing page
            <Link href={'/profile'}>Profile</Link>
        </div>
    );
};

export default LandingLayout;
