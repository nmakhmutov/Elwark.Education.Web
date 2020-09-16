import {Typography, TypographyProps} from '@material-ui/core';
import React, {useEffect, useState} from 'react';
import moment from 'moment';

type Props = {
    expiredAt: Date,
    onExpired: () => void
}

const Countdown: React.FC<Props & TypographyProps> = ({expiredAt, onExpired, ...props}) => {
    const toDate = moment.utc(expiredAt);
    const [countdown, setCountdown] = useState<string>('');

    useEffect(() => {
        const interval = setInterval(() => {
            const milliseconds = Math.max(0, toDate.diff(moment().utc()));
            const duration = moment.duration(milliseconds);
            setCountdown(moment.utc(duration.as('milliseconds')).format('HH:mm:ss'));

            if (milliseconds === 0)
            {
                onExpired();
                clearInterval(interval);
            }
        }, 1000);
        return () => clearInterval(interval);
    }, []);

    return (<Typography {...props}>
        {countdown}
    </Typography>);
};

export default Countdown;
