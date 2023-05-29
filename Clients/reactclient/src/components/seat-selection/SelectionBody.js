import { useContext } from "react";
import { MovieContext } from "../../MovieContext";
import Legend from "./Legend";
import Row from "./viewing-area/Row";

const SelectionBody = () => {
    const { apiResponse } = useContext(MovieContext);
    const rows = apiResponse.rows?.map(row => {
        return (
            apiResponse?.rows?.length > 0 &&
            <Row key={row.rowNumber} rowNumber={row.rowNumber} seats={row.seats} />
        )
    });

    return (
        <div className="selection-body">
            <Legend />
            <div className="viewing-area">{rows}</div>
        </div>
    )
}

export default SelectionBody;