import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import Hidden from '@material-ui/core/Hidden';
import IconButton from '@material-ui/core/IconButton';
import makeStyles from '@material-ui/core/styles/makeStyles';
import Tooltip from '@material-ui/core/Tooltip';
import Typography from '@material-ui/core/Typography';
import ChatIcon from '@material-ui/icons/ChatOutlined';
import MoreIcon from '@material-ui/icons/MoreVert';
import clsx from 'clsx';
import React from 'react';

const useStyles = makeStyles((theme) => {
    return ({
        root: {},
        cover: {
            'position': 'relative',
            'height': 240,
            'backgroundSize': 'cover',
            'backgroundRepeat': 'no-repeat',
            'backgroundPosition': 'center center',
            '&:before': {
                position: 'absolute',
                content: '" "',
                top: 0,
                left: 0,
                height: '100%',
                width: '100%',
                backgroundImage: 'linear-gradient(-180deg, rgba(0,0,0,0.00) 58%, rgba(0,0,0,0.32) 100%)',
            },
        },
        container: {
            width: theme.breakpoints.values.lg,
            maxWidth: '100%',
            padding: theme.spacing(2, 3),
            margin: '0 auto',
            position: 'relative',
            display: 'flex',
            flexWrap: 'wrap',
            [theme.breakpoints.down('sm')]: {
                flexDirection: 'column',
            },
        },
        avatar: {
            border: `2px solid ${theme.palette.common.white}`,
            height: 120,
            width: 120,
            top: -60,
            left: theme.spacing(3),
            position: 'absolute',
        },
        details: {
            marginLeft: 136,
        },
        actions: {
            'marginLeft': 'auto',
            [theme.breakpoints.down('sm')]: {
                marginTop: theme.spacing(1),
            },
            '& > * + *': {
                marginLeft: theme.spacing(1),
            },
        },
        mailIcon: {
            marginRight: theme.spacing(1),
        },
    });
});

export interface HeaderProps {
    className?: string;
    name: string;
    bio?: string;
    avatar: string;
    cover: string;
}

const Header: React.FC<HeaderProps> = (props) => {
    const {className, name, bio, avatar, cover, ...rest} = props;
    const classes = useStyles();

    return (
        <div
            {...rest}
            className={clsx(classes.root, className)}
        >
            <div className={classes.cover} style={{backgroundImage: `url(${cover})`}}/>
            <div className={classes.container}>
                <Avatar alt="Company" className={classes.avatar} src={avatar}/>
                <div className={classes.details}>
                    <Typography component="h2" gutterBottom variant="overline">
                        {bio}
                    </Typography>
                    <Typography component="h1" variant="h4">
                        {name}
                    </Typography>
                </div>
                <Hidden smDown>
                    <div className={classes.actions}>
                        <Button color="secondary" variant="contained">
                            <ChatIcon className={classes.mailIcon}/>
                            Send message
                        </Button>
                        <Tooltip title="More options">
                            <IconButton>
                                <MoreIcon/>
                            </IconButton>
                        </Tooltip>
                    </div>
                </Hidden>
            </div>
        </div>
    );
};

export default Header;
