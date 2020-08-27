import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {NextPage} from 'next';
import React from 'react';
import clsx from 'clsx';

const useStyles = makeStyles((theme) => ({
    grid: {
        margin: theme.spacing(3),
        display: 'grid',
        gridRowGap: '15px',
        gridTemplateColumns: 'repeat(auto-fill, minmax(250px,1fr))',
    },
    smallGrid: {
        display: 'grid',
        gridTemplateColumns: '1fr 1fr 1fr'
    },
    textHolder: {
        position: 'absolute',
        top: '50%',
        transform: 'translateY(-50%)'
    },
    title: {
        fontSize: '1.6em',
        color: theme.palette.common.black,
        margin: '0 30px 5px 30px',
        textTransform: 'uppercase'
    },
    subtitle: {
        fontSize: '0.9em',
        margin: '0 30px 5px 30px',
        textTransform: 'uppercase'
    },
    caption: {
        margin: '0 30px 0 30px;',
    },
    odd: {
        '& > $desc': {
            backgroundColor: theme.palette.warning.light,
            zIndex: 4,
            width: '112%',
            marginLeft: '-10.5%',
            transform: 'perspective(1000px) rotateY(-30deg)',
            gridColumn: '1 / 3',
            gridRow: '1 / 2',
            textAlign: 'right',
            '& > $textHolder': {
                right: 0
            }
        },
        '& > $photo': {
            zIndex: 5,
            width: '150%',
            marginLeft: '-22%',
            transform: 'perspective(1000px) rotateY(45deg)',
            gridColumn: '3 / 4',
            gridRow: '1 / 2'
        }
    },
    even: {
        '& > $desc': {
            zIndex: 2,
            backgroundColor: theme.palette.primary.light,
            width: '112%',
            transform: 'perspective(1000px) rotateY(30deg)',
            gridColumn: '2 / 4',
            gridRow: '1 / 2',
        },
        '& > $photo': {
            zIndex: 3,
            width: '150%',
            marginLeft: '-25%',
            transform: 'perspective(1000px) rotateY(-45deg)',
            gridColumn: '1 / 2',
            gridRow: '1 / 2',
        }
    },
    desc: {
        boxShadow: theme.shadows[10]
    },
    photo: {
        '& img': {
            display: 'block',
            width: '100%'
        }
    }
}));

type Props = {
    user: number
}

const HistoryPage: NextPage<Props> = (props) => {
    const classes = useStyles();
    const data = [];
    for (let i = 0; i < 100; i++) {
        data.push(i + 1)
    }

    let image = 0;
    const get = () => {
        image++;
        if (image < 10)
            return '0' + image;

        if (image > 30)
            image = 0;

        return image;
    }

    return (
        <DefaultLayout title={'History page'}>
            <div className={classes.grid}>
                {data.map((item, index) =>
                    <div className={clsx(classes.smallGrid, index % 2 === 1 ? classes.even : classes.odd)}>
                        <div className={classes.desc}>
                            <div className={classes.textHolder}>
                                <h3 className={classes.subtitle}>{item}: Radiohead</h3>
                                <h2 className={classes.title}>OK Computer</h2>
                                <p className={classes.caption}>[1997 / Capitol]</p>
                            </div>
                        </div>
                        <div className={classes.photo}>
                            <img src={`http://andybarefoot.com/codepen/images/albums/${get()}.jpg`}/>
                        </div>
                    </div>
                )}
            </div>
        </DefaultLayout>
    );
};

export default HistoryPage;
