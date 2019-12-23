import React from 'react';
import clsx from 'clsx';
import makeStyles from '@material-ui/core/styles/makeStyles';
import {
    Card,
    CardContent,
    CardActions,
    Typography,
    Grid,
    Divider
} from '@material-ui/core';
import AccessTimeIcon from '@material-ui/icons/AccessTime';
import GetAppIcon from '@material-ui/icons/GetApp';
import {CompanyShortModel} from "../../../../interfaces";

const useStyles = makeStyles(theme => ({
    root: {},
    imageContainer: {
        height: 64,
        width: 64,
        margin: '0 auto',
        border: `1px solid ${theme.palette.divider}`,
        borderRadius: '5px',
        overflow: 'hidden',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center'
    },
    image: {
        width: '100%'
    },
    statsItem: {
        display: 'flex',
        alignItems: 'center'
    },
    statsIcon: {
        color: theme.palette.grey["700"],
        marginRight: theme.spacing(1)
    }
}));

export interface CompanyCardProps {
    className?: string,
    company: CompanyShortModel
}

const CompanyCard: React.FC<CompanyCardProps> = (props) => {
    const {className, company, ...rest} = props;

    const classes = useStyles();

    return (
        <Card
            {...rest}
            className={clsx(classes.root, className)}
        >
            <CardContent>
                <div className={classes.imageContainer}>
                    <img
                        alt="Product"
                        className={classes.image}
                        src={company.logotype.square}
                    />
                </div>
                <Typography
                    align="center"
                    gutterBottom
                    variant="h4"
                >
                    {company.name}
                </Typography>
                <Typography
                    align="center"
                    variant="body1"
                >
                    {company.name}
                </Typography>
            </CardContent>
            <Divider/>
            <CardActions>
                <Grid
                    container
                    justify="space-between"
                >
                    <Grid
                        className={classes.statsItem}
                        item
                    >
                        <AccessTimeIcon className={classes.statsIcon}/>
                        <Typography
                            display="inline"
                            variant="body2"
                        >
                            Updated 2hr ago
                        </Typography>
                    </Grid>
                    <Grid
                        className={classes.statsItem}
                        item
                    >
                        <GetAppIcon className={classes.statsIcon}/>
                        <Typography
                            display="inline"
                            variant="body2"
                        >
                            {company.id} Downloads
                        </Typography>
                    </Grid>
                </Grid>
            </CardActions>
        </Card>
    );
};

export default CompanyCard;