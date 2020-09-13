import React from 'react';
import {Theme, Typography} from '@material-ui/core';
import {HistoryTopicItem} from 'lib/api/history';
import {makeStyles} from '@material-ui/styles';
import clsx from 'clsx';
import TopicProgress from 'components/Progress/TopicProgress';
import WebLinks from 'lib/WebLinks';
import {Link} from 'components';
import ElwarkCard from 'components/Card/ElwarkCard';

const useStyles = makeStyles((theme: Theme) => ({
    root: {
        display: 'grid',
        gridTemplateColumns: 'repeat(auto-fit, minmax(250px, 1fr))',
        gap: theme.spacing(3) + 'px'
    }
}));

type Props = {
    className?: string;
    topics: HistoryTopicItem[]
}

const HistoryTopicGrid: React.FC<Props> = (props) => {
    const classes = useStyles();
    const {topics, className} = props;

    return (
        <div className={clsx(classes.root, className)}>
            {topics.map((topic) => {
                    const link = WebLinks.HistoryTopic(topic.topicId);
                    return (
                        <ElwarkCard
                            key={topic.topicId}
                            direction={'column'}
                            title={
                                <Typography component={Link} href={link.href} as={link.as} variant={'h5'}>
                                    {topic.title}
                                </Typography>
                            }
                            image={topic.image}
                            subtitle={topic.range}
                            actions={
                                topic.progress &&
                                <TopicProgress passed={topic.progress.passed} total={topic.progress.count}/>
                            }/>
                    );
                }
            )}
        </div>
    );
};

export default HistoryTopicGrid;
