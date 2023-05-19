const GetScreeningData = (startTimes) => {
    var weekDays = [];

    weekDays = [...Array(7).keys()]
        .map(item => {
            const currentDay = () => {
                const currentDate = new Date();
                currentDate.setDate(currentDate.getDate() + item);
                return currentDate;
            }
            return (
                {
                    fullDate: currentDay().toLocaleDateString('en-US', { year: 'numeric', month: 'numeric', day: 'numeric' }),
                    day: currentDay().toLocaleDateString('en-US', { day: 'numeric' }),
                    dayName: currentDay().toLocaleDateString('en-US', { weekday: 'short' }),
                    startTimes: startTimes
                }
            )
        });
    return weekDays;
}

export { GetScreeningData };