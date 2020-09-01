import {makeStyles} from '@material-ui/styles';
import {Card, CardContent, CardMedia, Theme, Typography} from '@material-ui/core';
import clsx from 'clsx';
import React from 'react';
import {Link} from 'components';
import Links from 'lib/utils/Links';
import {HistoryTopicItem} from 'lib/api/history';
import TopicProgress from 'components/Progress/TopicProgress';

const useStyles = makeStyles((theme: Theme) => ({
    root: {
        maxWidth: 250,
        margin: '0 auto'
    },
    media: {
        height: 125
    },
    content: {},
    title: {
        display: 'block',
        marginBottom: theme.spacing(1)
    },
    date: {
        marginBottom: theme.spacing(2)
    },
}));

type Props = {
    className?: string
    topic: HistoryTopicItem
}

const HistoryTopicCard: React.FC<Props> = (props) => {
    const {className, topic} = props;

    const classes = useStyles();
    const topicLink = Links.HistoryTopic(topic.topicId);

    return (
        <Card className={clsx(classes.root, className)}>
            <CardMedia className={classes.media} image={topic.image}/>
            <CardContent className={classes.content}>
                <Typography
                    className={classes.title}
                    component={Link}
                    href={topicLink.href}
                    as={topicLink.as}
                    color={'textPrimary'}
                    variant={'h5'}
                >
                    {topic.title}
                </Typography>
                <Typography className={classes.date} variant="body2">
                    {topic.range ? topic.range : '\u00A0'}
                </Typography>
                <TopicProgress passed={topic.progress.passed} total={topic.progress.count}/>
            </CardContent>
        </Card>
    );
};

export default HistoryTopicCard
