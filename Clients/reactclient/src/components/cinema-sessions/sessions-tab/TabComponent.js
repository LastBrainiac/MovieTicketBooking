import { useContext } from "react";
import { MovieContext } from "../../../MovieContext";
import TabItem from "./TabItem";

const TabComponent = () => {
    const { getScreeningData } = useContext(MovieContext);
    var screeningData = getScreeningData();

    const tabHeaderItems = screeningData.map(data => {
        return (
            <TabItem key={data.day} data={data} />
        );
    });

    return (
        <div className="tab-component">
            {tabHeaderItems}            
        </div>
    );
}

export default TabComponent;