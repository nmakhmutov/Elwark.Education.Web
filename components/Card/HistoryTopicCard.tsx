import {makeStyles} from '@material-ui/styles';
import {Avatar, Card, CardContent, CardMedia, Divider, Grid, Theme, Typography} from '@material-ui/core';
import clsx from 'clsx';
import React from 'react';
import {Link} from 'components';
import Links from 'lib/utils/Links';
import {TopicItem} from 'lib/api/history';
import TopicProgress from 'components/Progress/TopicProgress';

const useStyles = makeStyles((theme: Theme) => ({
    root: {
        maxWidth: 250,
        margin: '0 auto'
    },
    media: {
        height: 125
    },
    content: {
        paddingTop: 0
    },
    avatarContainer: {
        marginTop: -32,
        display: 'flex',
        justifyContent: 'center'
    },
    avatar: {
        height: 64,
        width: 64,
        borderWidth: 4,
        borderStyle: 'solid',
        borderColor: theme.palette.common.white
    },
    divider: {
        margin: theme.spacing(2, 0)
    },
    w100: {
        width: '100%'
    }
}));

type Props = {
    className?: string
    topic: TopicItem
}

const HistoryTopicCard: React.FC<Props> = (props) => {
    const {className, topic} = props;

    const classes = useStyles();
    const topicLink = Links.HistoryTopic(topic.topicId);

    return (
        <Card className={clsx(classes.root, className)}>
            <CardMedia className={classes.media} image={topic.image}/>
            <CardContent className={classes.content}>
                <div className={classes.avatarContainer}>
                    <Avatar className={classes.avatar}>Avatar</Avatar>
                </div>
                <Typography
                    align="center"
                    component={Link}
                    display="block"
                    href={topicLink.href}
                    as={topicLink.as}
                    variant="h6"
                >
                    {topic.title}
                </Typography>
                <Typography align="center" variant="body2">
                    {topic.range ? topic.range : '\u00A0'}
                </Typography>
                <Divider className={classes.divider}/>
                <Grid container spacing={1}>
                    <div className={classes.w100}>
                        <TopicProgress passed={topic.progress.passed} total={topic.progress.count}/>
                    </div>
                </Grid>
            </CardContent>
        </Card>
    );
};

export default HistoryTopicCard
