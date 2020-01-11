import {Avatar, Card, Link as MuiLink, List, ListItem, ListItemAvatar, ListItemText} from '@material-ui/core';
import CardContent from '@material-ui/core/CardContent';
import CardHeader from '@material-ui/core/CardHeader';
import makeStyles from '@material-ui/core/styles/makeStyles';
import InstagramIcon from '@material-ui/icons/Instagram';
import TwitterIcon from '@material-ui/icons/Twitter';
import WebIcon from '@material-ui/icons/Web';
import YouTubeIcon from '@material-ui/icons/YouTube';
import clsx from 'clsx';
import * as React from 'react';

const useStyles = makeStyles(() => ({
    root: {},
    header: {
        paddingBottom: 0,
    },
    content: {
        paddingTop: 0,
    },
}));

export interface SitesProps {
    className?: string;
    list: Array<[string, string]>;
}

const Sites: React.FC<SitesProps> = (props) => {
        const {list, className, ...rest} = props;
        const classes = useStyles();

        const icons = (name: string) => {
            switch (name.toLowerCase()) {
                case 'website':
                    return <WebIcon/>;
                case 'twitter':
                    return <TwitterIcon/>;
                case 'youtube':
                    return <YouTubeIcon/>;
                case 'instagram':
                    return <InstagramIcon/>;
                default:
                    return name[0].toUpperCase();
            }
        };

        return (
            <Card
                {...rest}
                className={clsx(classes.root, className)}
            >
                <CardHeader
                    className={classes.header}
                    title="Company sites"
                    titleTypographyProps={{
                        variant: 'overline',
                    }}
                />
                <CardContent className={classes.content}>
                    <List>
                        {list.map((value, index) => (
                            <ListItem disableGutters={true} key={index}>
                                <ListItemAvatar>
                                    <Avatar alt="Site logo">
                                        {icons(value[0])}
                                    </Avatar>
                                </ListItemAvatar>
                                <ListItemText
                                    primary={value[0]}
                                    primaryTypographyProps={{variant: 'h6'}}
                                    secondary={
                                        <MuiLink href={value[1]} target={'_blank'}>{value[1]}</MuiLink>
                                    }
                                />
                            </ListItem>
                        ))}
                    </List>
                </CardContent>
            </Card>
        );
    }
;

export default Sites;
