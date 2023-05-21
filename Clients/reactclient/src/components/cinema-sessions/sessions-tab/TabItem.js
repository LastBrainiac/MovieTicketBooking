const TabItem = ({ data }) => {
    const itemClass = data.isSelected ? 'tab-item-selected' : 'tab-item';

    const clickHandler = () => {
        console.log(data)
    }

    return (
        <div className={`${itemClass}`} onClick={clickHandler}>
            <p className="day">{data.day}</p>
            <p>{data.dayName}</p>
        </div>
    )
}

export default TabItem;