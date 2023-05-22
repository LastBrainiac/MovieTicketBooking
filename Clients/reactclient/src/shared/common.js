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

export { getScreeningData };