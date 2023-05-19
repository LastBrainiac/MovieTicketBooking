import { GetScreeningData } from "../../../shared/utils";

const TabComponent = ({ startTimes }) => {

    var screeningData = GetScreeningData(startTimes);

    return (
        <div>
            <h3>Tab Component</h3>
        </div>
    );
}

export default TabComponent;