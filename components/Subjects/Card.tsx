import {Avatar, Divider, Theme, Typography} from '@material-ui/core';
import React from 'react';
import {makeStyles} from '@material-ui/styles';
import {useRouter} from 'next/router';

const useStyles = makeStyles((theme: Theme) => ({
    root: {
        overflow: 'unset',
        position: 'relative',
        cursor: 'pointer',
        transition: theme.transitions.create('transform', {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.leavingScreen
        }),
        '&:hover': {
            transform: 'scale(1.1)'
        },
        borderRadius: theme.shape.borderRadius,
        backgroundRepeat: 'no-repeat',
        backgroundPosition: 'center center',
        backgroundSize: 'cover',
        boxShadow: theme.shadows[3]
    },
    content: {
        backgroundColor: 'rgba(0,0,0,0.5)',
        padding: theme.spacing(5, 3),
        borderRadius: theme.shape.borderRadius,
        '& *': {
            color: theme.palette.common.white
        },
    },
    avatar: {
        borderRadius: theme.shape.borderRadius,
        position: 'absolute',
        top: -24,
        left: theme.spacing(3),
        height: 48,
        width: 48,
        fontSize: 24,
    },
    divider: {
        margin: theme.spacing(2, 0)
    },
    options: {
        lineHeight: '26px'
    },
}));

type Props = {
    link: string,
    title: string,
    topics: number,
    articles: number
    questions: number,
    icon: JSX.Element,
    background: string,
    gradient: string
}

const SubjectCard: React.FC<Props> = (props) => {
    const {link, title, topics, articles, questions, icon, background, gradient} = props;
    const classes = useStyles();
    const router = useRouter();

    return (
        <div className={classes.root} style={{backgroundImage: `url(${background})`}}>
            <div className={classes.content} onClick={() => router.push(link)}>
                <Avatar className={classes.avatar} style={{background: gradient}}>
                    {icon}
                </Avatar>
                <Typography component="h3" gutterBottom variant="overline">
                    Subject
                </Typography>
                <Typography component="span" display="inline" variant="h3">
                    {title}
                </Typography>
                <Divider className={classes.divider}/>
                <Typography variant={'subtitle2'} className={classes.options}>
                    <strong>{topics}+</strong> Topics
                </Typography>
                <Typography variant={'subtitle2'} className={classes.options}>
                    <strong>{articles}+</strong> Articles
                </Typography>
                <Typography variant={'subtitle2'} className={classes.options}>
                    <strong>{questions}+</strong> Questions
                </Typography>
            </div>
        </div>
    )
}

export default SubjectCard;
