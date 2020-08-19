import {colors} from '@material-ui/core';

const ratingColor = (rating: number) => {
    if (rating > 90) {
        return colors.green.A400;
    }
    if (rating > 80) {
        return colors.green['700'];
    }
    if (rating > 70) {
        return colors.lightGreen['700'];
    }
    if (rating > 60) {
        return colors.yellow['700'];
    }
    if (rating > 50) {
        return colors.yellow['800'];
    }
    if (rating > 40) {
        return colors.orange['700'];
    }
    if (rating > 30) {
        return colors.deepOrange.A400;
    }
    if (rating > 20) {
        return colors.deepOrange['500'];
    }
    if (rating > 10) {
        return colors.deepOrange['700'];
    }

    return colors.deepOrange.A700;
};

export default ratingColor;
