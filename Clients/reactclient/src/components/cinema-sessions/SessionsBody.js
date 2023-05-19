import TabComponent from "./sessions-tab/TabComponent";

const SessionsBody = ({ startTimes }) => {
    return (
        <div>
            <h3>Session Body</h3>
            <TabComponent startTimes={startTimes} />
        </div>
    )
}

export default SessionsBody;