import {Grid, Typography} from '@material-ui/core';
import makeStyles from '@material-ui/core/styles/makeStyles';
import AccountBalanceIcon from '@material-ui/icons/AccountBalance';
import Atom from 'components/icons/Atom';
import WebLinks from 'lib/WebLinks';
import {useRouter} from 'next/router';
import React from 'react';
import SubjectCard from 'components/Subjects/Card';
import FlareIcon from '@material-ui/icons/Flare';

const useStyles = makeStyles(theme => ({
    root: {},
    header: {
        maxWidth: 600,
        margin: '0 auto',
        padding: theme.spacing(3)
    },
    content: {
        marginTop: theme.spacing(5),
        padding: theme.spacing(2),
        maxWidth: 1280,
        margin: '0 auto'
    },
    subtitle: {
        marginTop: theme.spacing(3)
    },
    contact: {
        margin: theme.spacing(3, 0)
    }
}));

const Subjects: React.FC = () => {
    const classes = useStyles();

    return (
        <div className={classes.root}>
            <div className={classes.header}>
                <Typography align="center" gutterBottom variant="h1">
                    Choose your favorite subject
                </Typography>
                <Typography align="center" variant="subtitle2" className={classes.subtitle}>
                    Welcome to the first platform for education!
                </Typography>
            </div>
            <div className={classes.content}>
                <Grid container spacing={6} justify={'center'}>
                    <Grid item xs={12} sm={6} md={4}>
                        <SubjectCard
                            link={WebLinks.History}
                            title={'History'}
                            topics={20}
                            articles={30}
                            questions={40}
                            icon={<AccountBalanceIcon/>}
                            background={'/images/backgrounds/history.png'}
                            gradient={'linear-gradient(140deg, rgba(226,110,67,1) 0%, rgba(248,206,14,1) 100%)'}/>
                    </Grid>
                    <Grid item xs={12} sm={6} md={4}>
                        <SubjectCard
                            link={WebLinks.Physics}
                            title={'Physics'}
                            topics={20}
                            articles={30}
                            questions={40}
                            icon={<Atom style={{fontSize: '2rem'}}/>}
                            background={'/images/backgrounds/physics.jpg'}
                            gradient={'linear-gradient(140deg, rgba(28,46,76,1) 0%, rgba(108,208,255,1) 100%)'}/>
                    </Grid>
                    <Grid item md={4} xs={12}>
                        <SubjectCard
                            link={WebLinks.Astronomy}
                            title={'Astronomy'}
                            topics={20}
                            articles={30}
                            questions={40}
                            icon={<FlareIcon/>}
                            background={'/images/backgrounds/astronomy.jpg'}
                            gradient={'linear-gradient(140deg, rgba(53,58,95,1) 0%, rgba(158,186,243,1) 100%)'}/>
                    </Grid>
                </Grid>
            </div>
        </div>
    );
};

export default Subjects;
