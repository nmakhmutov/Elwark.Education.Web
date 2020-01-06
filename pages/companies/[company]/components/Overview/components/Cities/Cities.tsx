import {
    Card,
    CardActions,
    CardContent,
    CardHeader,
    Divider,
    makeStyles,
    Table,
    TableBody,
    TableCell,
    TableHead,
    TablePagination,
    TableRow,
} from '@material-ui/core';
import {CafeModel} from 'api/bff/types';
import clsx from 'clsx';
import {RatingText, VotersText} from 'components';
import React, {useState} from 'react';

const useStyles = makeStyles((theme) => ({
    root: {},
    content: {
        padding: 0,
    },
    inner: {
        minWidth: 700,
    },
    progressContainer: {
        padding: theme.spacing(3),
        display: 'flex',
        justifyContent: 'center',
    },
    actions: {
        justifyContent: 'flex-end',
    },
    arrowForwardIcon: {
        marginLeft: theme.spacing(1),
    },
}));

export interface CitiesProps {
    className?: string;
    cafes: CafeModel[];
}

const Cities: React.FC<CitiesProps> = (props) => {
    const {className, cafes, ...rest} = props;

    const classes = useStyles();
    const [page, setPage] = useState(0);
    const [rows, setRows] = useState(5);

    const slice = cafes.sort((a, b) => a.rating.value > b.rating.value ? -1 : 1)
        .slice(page * rows, page * rows + rows);

    return (
        <Card {...rest} className={clsx(classes.root, className)}>
            <CardHeader title="Rating by cities"/>
            <Divider/>
            <CardContent className={classes.content}>
                <div className={classes.inner}>
                    {slice && (
                        <Table>
                            <TableHead>
                                <TableRow>
                                    <TableCell>Country</TableCell>
                                    <TableCell>City</TableCell>
                                    <TableCell align={'center'}>Cafes</TableCell>
                                    <TableCell align={'center'}>Voters</TableCell>
                                    <TableCell align={'center'}>Rating</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {slice.map((cafe, index) => (
                                    <TableRow hover key={index}>
                                        <TableCell>{cafe.country.name}</TableCell>
                                        <TableCell>{cafe.city.name}</TableCell>
                                        <TableCell align={'center'}>{cafe.cafeCount}</TableCell>
                                        <TableCell align={'center'}>
                                            <VotersText value={cafe.rating.voters}/></TableCell>
                                        <TableCell align={'center'}>
                                            <RatingText value={cafe.rating.value}/>
                                        </TableCell>
                                    </TableRow>
                                ))}
                            </TableBody>
                        </Table>
                    )}
                </div>
            </CardContent>
            <Divider/>
            <CardActions className={classes.actions}>
                <TablePagination
                    component={'div'}
                    count={cafes.length}
                    page={page}
                    rowsPerPage={rows}
                    rowsPerPageOptions={[5, 10, 20]}
                    onChangePage={(evt, value) => setPage(value)}
                    onChangeRowsPerPage={(evt) => {
                        setPage(0);
                        setRows(Number(evt.target.value));
                    }}
                />
            </CardActions>
        </Card>
    );
};

export default Cities;
