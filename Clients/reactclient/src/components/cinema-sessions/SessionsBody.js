import TabComponent from "./sessions-tab/TabComponent";
import TabContent from "./sessions-tab/TabContent";

const SessionsBody = () => {
    return (
        <div className="session-body">
            <TabComponent />
            <p className="screening-title">SCREENING TIMES</p>
            <TabContent />
        </div>
    )
}

export default SessionsBody;