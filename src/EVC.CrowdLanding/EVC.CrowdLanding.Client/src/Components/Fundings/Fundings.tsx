import React, { useState, useEffect } from "react";
import { RouteComponentProps } from "react-router-dom";
import axios from "../../axios";
import "./Fundings.css";

type Funding = {
  id: string;
  description: string;
  investmentStatus: string;
  typeOfInvestment: string;
  investmentCompany: string;
  startTime: string;
  endTime: string;
};

type FundingKeys = keyof Funding;

type ColumnNames = { [K in FundingKeys]?: string };

const columnsNames: ColumnNames = {
  description: "Description",
  investmentStatus: "Status",
  typeOfInvestment: "Type of investment",
  investmentCompany: "Company",
  startTime: "Start time",
  endTime: "End time"
};

const Fundings: React.SFC<RouteComponentProps> = ({ history }) => {
  const [fundings, setFundings] = useState<Funding[]>([]);

  useEffect(() => {
    axios.get("funding").then(response => {
      setFundings(response.data);
    });
  }, []);

  function handleRowClick(e: TableRowClickEvent, id: string) {
    history.push("/fundings/" + id);
  }

  return (
    <>
      <table className="table table-bordered table-hover">
        <thead>
          <tr>
            {Object.values(columnsNames).map(columnName => (
              <th scope="col" key={columnName}>
                {columnName}
              </th>
            ))}
          </tr>
        </thead>
        <tbody>
          {fundings.map((funding: Funding) => (
            <tr key={funding.id} onClick={e => handleRowClick(e, funding.id)}>
              {Object.keys(columnsNames).map(columnName => (
                <td key={`${funding.id}${columnName}`}>
                  {funding[columnName as FundingKeys]}
                </td>
              ))}
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
};

export default Fundings;
