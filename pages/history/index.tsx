import makeStyles from '@material-ui/core/styles/makeStyles';
import DefaultLayout from 'components/Layout';
import {NextPage} from 'next';
import React from 'react';
import {Card, CardContent, Grid, Typography} from '@material-ui/core';
import clsx from 'clsx';

const useStyles = makeStyles((theme) => ({
    grid: {
        display: 'grid',
        gridGap: '10px',
        gridTemplateColumns: 'repeat(3, auto)',
        marginTop: '50px'
        // padding: '80px 30px 30px 30px'
    },
    box: {
        // width: '80px',
        // height: '80px',
        // background: '#000',
        // borderRadius: '50%',
    },
    offset: {
        marginTop: '-40px'
    }
}));

type Props = {
    user: number
}

const HistoryPage: NextPage<Props> = (props) => {
    const classes = useStyles();
    const data = [];
    for (let i = 0; i < 200; i++) {
        data.push(i + 1)
    }
    const result = [];
    let t = 5;
    let lr = 6;
    result.push(data.slice(0, lr))

    while (lr < data.length) {
        result.push(data.slice(lr, lr + t));
        lr += 5;
        result.push(data.slice(lr, lr + t));

        t = t === 5 ? 6 : 5;
    }

    return (
        <DefaultLayout title={'History page'}>
            <Grid container={true}>
                <Grid item={true} md={3}/>
                <Grid item={true} md={9}>
                    <div className={classes.grid}>
                        {data.map(x =>
                            <div key={x} className={clsx(classes.box, x % 3 === 2 ? classes.offset : null)}>
                                <Card>
                                    <CardContent>
                                        <Typography variant={'body1'} align={'center'}>{x}</Typography>
                                    </CardContent>
                                </Card>
                            </div>)
                        }
                    </div>
                    {/*{result.map(first =>*/}
                    {/*    <Grid container={true} spacing={3} justify={'space-around'}>*/}
                    {/*        {first.map(second =>*/}
                    {/*            <Grid item={true} sm={2}>*/}
                    {/*                <Card>*/}
                    {/*                    <CardContent>*/}
                    {/*                        <Typography variant={'body1'} align={'center'}>{second}</Typography>*/}
                    {/*                    </CardContent>*/}
                    {/*                </Card>*/}
                    {/*            </Grid>*/}
                    {/*        )}*/}
                    {/*    </Grid>*/}
                    {/*)}*/}
                </Grid>
            </Grid>
        </DefaultLayout>
    );
};

export default HistoryPage;
