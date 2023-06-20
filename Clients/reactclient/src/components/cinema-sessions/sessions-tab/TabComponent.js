import { useContext } from "react";
import { MovieContext } from "../../../MovieContext";
import TabItem from "./TabItem";

const TabComponent = () => {
    const {screeningData} = useContext(MovieContext);

    const tabHeaderItems = screeningData.map((data, index) => {
        return (
            <TabItem key={index} data={data} index={index}/>
        );
    });

    return (
        <div className="tab-component">
            {tabHeaderItems}            
        </div>
    );
}

export default TabComponent;