const TabItem = (data) => {
    const itemClass = data.data.isSelected ? 'tab-item-selected' : 'tab-item';
    return (
        <div className={`${itemClass}`}>
            <p className="day">{data.data.day}</p>
            <p>{data.data.dayName}</p>
        </div>
    )
}

export default TabItem;