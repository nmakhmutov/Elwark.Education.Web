import React from 'react';
import {Grid, Theme, Typography} from '@material-ui/core';
import {HistoryTopicItem} from 'lib/api/history';
import {makeStyles} from '@material-ui/styles';
import clsx from 'clsx';
import TopicProgress from 'components/Progress/TopicProgress';
import WebLinks from 'lib/WebLinks';
import {Link} from 'components';
import HistoryCard from 'components/History/HistoryCard';

const useStyles = makeStyles((theme: Theme) => ({
    root: {},
    card: {
        margin: '0 auto',

        [theme.breakpoints.up('md')]: {
            maxWidth: 250
        }
    }
}));

type Props = {
    className?: string;
    topics: HistoryTopicItem[]
}

const HistoryTopicGrid: React.FC<Props> = (props) => {
    const classes = useStyles();
    const {topics, className} = props;

    let i = 0;
    const get = () => {
        if (i >= 8)
            i = 0;

        i++;

        if (i === 3 || i === 4 || i === 5)
            return 4;

        if (i === 8)
            return 12;

        return 5;
    };

    return (
        <div className={clsx(classes.root, className)}>
            <Grid container={true} spacing={3} justify={'center'}>
                {topics.map((topic) => {
                        const link = WebLinks.HistoryTopic(topic.topicId);
                        return (
                            <Grid key={topic.topicId} item={true} xs={12} sm={6} md={get()}>
                                <HistoryCard
                                    className={classes.card}
                                    direction={'column'}
                                    title={
                                        <Typography component={Link} href={link.href} as={link.as} variant={'h4'}>
                                            {topic.title}
                                        </Typography>
                                    }
                                    image={topic.image}
                                    subtitle={topic.range}
                                    actions={<TopicProgress passed={topic.progress.passed} total={topic.progress.count}/>}/>
                            </Grid>
                        );
                    }
                )}
            </Grid>
        </div>
    );
};

export default HistoryTopicGrid;
