import {Card} from '@material-ui/core';
import CardContent from '@material-ui/core/CardContent';
import CardHeader from '@material-ui/core/CardHeader';
import Divider from '@material-ui/core/Divider';
import makeStyles from '@material-ui/core/styles/makeStyles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableRow from '@material-ui/core/TableRow';
import clsx from 'clsx';
import * as React from 'react';

const useStyles = makeStyles((theme) => ({
    root: {},
    content: {
        padding: 0,
    },
}));

export interface SitesProps {
    className?: string;
    list: Array<[string, string]>;
}

const Sites: React.FC<SitesProps> = (props) => {
    const {list, className, ...rest} = props;
    const classes = useStyles();

    return (
        <Card
            {...rest}
            className={clsx(classes.root, className)}
        >
            <CardHeader title="Sites"/>
            <Divider/>
            <CardContent className={classes.content}>
                <Table>
                    <TableBody>
                        {list.map((value, index) => (
                            <TableRow key={index} selected={index % 2 === 0}>
                                <TableCell>{value[0]}</TableCell>
                                <TableCell>
                                    <a href={value[1]} target={'_blank'}>{value[1]}</a>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </CardContent>
        </Card>
    );
};

export default Sites;
