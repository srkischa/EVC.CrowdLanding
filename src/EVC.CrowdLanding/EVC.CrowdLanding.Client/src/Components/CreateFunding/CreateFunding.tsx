import React, { useState, useEffect } from "react";
import { RouteComponentProps } from "react-router-dom";
import axios from "../../axios";
import "./CreateFunding.css";

interface MatchParams {
  id: string;
}

const CreateFunding: React.SFC<RouteComponentProps<MatchParams>> = ({
  match,
  history
}) => {
  const [fundingAmount, setFundingAmount] = useState(100);
  const [fundingDescription, setFundingDescription] = useState("");
  const [isFoundedByMe, setIsFoundedByMe] = useState(false);
  const [isAmountValid, setIsAmountValid] = useState(true);
  const id = match.params.id;

  function getFunding() {
    axios.get(`/funding/${id}`).then(response => {
      setFundingDescription(response.data.description);
      setIsFoundedByMe(response.data.isFoundedByMe);
    });
  }

  useEffect(() => {
    getFunding();
  }, []);

  function handleAmountChange(e: InputChangeEvent) {
    const amount = parseFloat(e.target.value);
    setIsAmountValid(amount <= 10000 && amount >= 100);
    setFundingAmount(amount);
  }

  function hanldeInvestClick(e: MouseClickEvent) {
    e.preventDefault();
    axios
      .post("funding", {
        fundingId: id,
        fundingAmount: fundingAmount
      })
      .then(response => {
        getFunding();
      });
    // todo missing server side validation handle here
  }

  function handleCancelClick(e: MouseClickEvent) {
    e.preventDefault();
    history.push("/");
  }

  const isDisabled = isFoundedByMe || !isAmountValid;

  return (
    <>
      <section className="jumbotron text-center">
        <div className="container">
          <h1 className="jumbotron-heading">Funding on investment</h1>
          <p className="lead text-muted">{fundingDescription}</p>
          <form>
            <div className="form-group row">
              <label
                htmlFor="inputEmail3"
                className="col-sm-1 offset-sm-4 col-form-label"
              >
                Amount
              </label>
              <div className="col-sm-2">
                <input
                  type="number"
                  className="form-control"
                  placeholder="Fund amount"
                  value={fundingAmount}
                  readOnly={isFoundedByMe}
                  onChange={handleAmountChange}
                />
                {!isAmountValid && (
                  <div className="invalid-value">
                    Value must me betweeen 100 and 10000
                  </div>
                )}
                {isFoundedByMe && (
                  <div className="invalid-value">
                    You have already founded this investment
                  </div>
                )}
              </div>
            </div>
            <div className="form-group row">
              <div className="col-sm-6 offset-sm-3">
                <button
                  type="submit"
                  disabled={isDisabled}
                  className="btn btn-primary btn-lg mx-2"
                  onClick={hanldeInvestClick}
                >
                  Invest
                </button>
                <button
                  type="submit"
                  className="btn btn-primary btn-lg mx-2"
                  onClick={handleCancelClick}
                >
                  Cancel
                </button>
              </div>
            </div>
          </form>
        </div>
      </section>
    </>
  );
};

export default CreateFunding;
