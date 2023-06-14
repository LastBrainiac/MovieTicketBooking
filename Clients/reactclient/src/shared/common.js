import { createTheme } from '@mui/material/styles';

const getScreeningData = () => {
    return [...Array(7).keys()]
        .map(index => {
            const currentDay = () => {
                const currentDate = new Date();
                currentDate.setDate(currentDate.getDate() + index);
                return currentDate;
            }
            return (
                {
                    shortDate: currentDay().toISOString().split('T')[0],
                    day: currentDay().toLocaleDateString('en-US', { day: 'numeric' }),
                    dayName: currentDay().toLocaleDateString('en-US', { weekday: 'short' }),
                    isSelected: false
                }
            )
        });
}

const mediumDateShortTime = new Intl.DateTimeFormat('en', {
    timeStyle: "short",
    dateStyle: "medium",
    hour12: false
});

const shortDateShortTime = new Intl.DateTimeFormat('en', {
    timeStyle: "short",
    dateStyle: "short",
    hour12: false
})

const darkTheme = createTheme({
    palette: {
        mode: 'dark',
    },
});

export { getScreeningData, mediumDateShortTime, shortDateShortTime, darkTheme };