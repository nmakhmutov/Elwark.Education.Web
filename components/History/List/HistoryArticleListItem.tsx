import {makeStyles} from '@material-ui/styles';
import {Link as UiLink, Theme, Typography, withStyles} from '@material-ui/core';
import clsx from 'clsx';
import React from 'react';
import WebLinks from 'lib/WebLinks';
import {Link} from 'components';
import {HistoryArticleItem} from 'lib/api/history';
import {amber} from '@material-ui/core/colors';
import moment from 'moment';

const useStyles = makeStyles((theme: Theme) => ({
    root: {
        display: 'flex',
        position: 'relative',
        justifyContent: 'space-between',
        flexWrap: 'wrap',
    },
    card: {
        position: 'relative',
        display: 'flex',

        [theme.breakpoints.only('xs')]: {
            flexDirection: 'column'
        }
    },
    content: {
        marginLeft: theme.spacing(2),
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'flex-end',
    },
    image: {
        flex: '0 0 150px',
        width: '60%',
        margin: '0 auto',
        marginBottom: theme.spacing(2),
        [theme.breakpoints.up('sm')]: {
            height: 150,
            width: 150,
            margin: 0
        },
        '& > img': {
            maxWidth: '100%'
        }
    },
    title: {
        marginBottom: theme.spacing(2)
    },
    subtitle: {
        marginBottom: theme.spacing(1)
    }
}));

const PremiumTypography = withStyles({root: {color: amber.A700}})(Typography);

type Props = {
    className?: string,
    onPremiumPopup?: () => void
    article: HistoryArticleItem
}

const HistoryArticleListItem: React.FC<Props> = (props) => {
    const {className, article, onPremiumPopup} = props;

    const classes = useStyles();
    const link = WebLinks.HistoryArticle(article.articleId);

    const title = () => {
        if (article.type === 'premium' && onPremiumPopup) {
            const onClick = (event: MouseEvent) => {
                event.preventDefault();
                onPremiumPopup();
            };

            return (
                <Typography
                    component={UiLink}
                    className={classes.title}
                    display={'block'}
                    color={'textPrimary'}
                    variant={'h4'}
                    href={'#'}
                    onClick={onClick}>
                    {article.title}
                </Typography>
            )
        }

        return (
            <Typography
                component={Link}
                className={classes.title}
                display={'block'}
                href={link.href}
                as={link.as}
                color={'textPrimary'}
                variant={'h4'}>
                {article.title}
            </Typography>
        )
    }

    return (
        <div className={clsx(classes.root, className)}>
            <div className={classes.card}>
                <div className={classes.image}>
                    {article.image && <img src={article.image} alt={article.title}/>}
                </div>
                <div className={classes.content}>
                    {article.type === 'premium' &&
                    <PremiumTypography variant={'subtitle1'}>
                        Premium
                    </PremiumTypography>}
                    {title()}
                    <Typography variant={'subtitle2'} className={classes.subtitle}>
                        {article.subtitle}
                    </Typography>
                    <Typography variant={'caption'}>
                        {article.passedAt ? 'Test passed ' + moment(article.passedAt).fromNow() : 'Test not passed'}
                    </Typography>
                </div>
            </div>
        </div>
    );
};

export default HistoryArticleListItem
