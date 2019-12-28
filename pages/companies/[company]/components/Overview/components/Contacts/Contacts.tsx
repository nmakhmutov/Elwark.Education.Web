import {Avatar, Card, List, ListItem, Typography} from '@material-ui/core';
import CardContent from '@material-ui/core/CardContent';
import CardHeader from '@material-ui/core/CardHeader';
import makeStyles from '@material-ui/core/styles/makeStyles';
import ContactMailIcon from '@material-ui/icons/ContactMail';
import clsx from 'clsx';
import * as React from 'react';

const useStyles = makeStyles((theme) => ({
    root: {},
    header: {
        paddingBottom: 0,
    },
    content: {
        paddingTop: 0,
    },
    listItem: {
        padding: theme.spacing(2, 0),
        justifyContent: 'space-between',
    },
}));

export interface ContactsProps {
    className?: string;
    list: Array<[string, string]>;
}

const Contacts: React.FC<ContactsProps> = (props) => {
    const {list, className, ...rest} = props;
    const classes = useStyles();

    return (
        <Card
            {...rest}
            className={clsx(classes.root, className)}
        >
            <CardHeader
                className={classes.header}
                disableTypography={true}
                avatar={
                    <Avatar alt="Author">
                        <ContactMailIcon/>
                    </Avatar>
                }
                title={
                    <Typography
                        display="block"
                        variant="overline"
                    >
                        Contacts
                    </Typography>
                }
            />
            <CardContent className={classes.content}>
                <List>
                    {list.map((value, index) => (
                        <ListItem key={index} className={classes.listItem} disableGutters={true} divider={true}>
                            <Typography variant="subtitle2">{value[0]}</Typography>
                            <Typography variant="h6">
                                {value[1]}
                            </Typography>
                        </ListItem>
                    ))}
                </List>
            </CardContent>
        </Card>
    );
};

export default Contacts;
