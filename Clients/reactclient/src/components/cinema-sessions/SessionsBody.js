import TabComponent from "./sessions-tab/TabComponent";
import TabContent from "./sessions-tab/TabContent";
import { useContext } from "react";
import { MovieContext } from "../../MovieContext";

const SessionsBody = () => {
    const { selectedMovie } = useContext(MovieContext);

    return (
        <div className="session-body">
            <TabComponent />
            <p className="screening-title">SCREENING TIMES</p>
            <TabContent />
        </div>
    )
}

export default SessionsBody;