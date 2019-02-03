import React from "react";
import { Switch, Route } from "react-router-dom";
// import { RequireAuth } from "./Auth/RequireAuth";
import Fundings from "./Components/Fundings/Fundings";
import NoMatch from "./Components/NoMatch/NoMatch";
import CreateFunding from "./Components/CreateFunding/CreateFunding";

class Main extends React.Component {
  render() {
    return (
      <div className="container">
        <Switch>
          <Route
            path="/fundings"
            render={({ match }) => (
              <Switch>
                <Route path={`${match.path}/:id`} component={CreateFunding} />
                <Route component={NoMatch} />
              </Switch>
            )}
          />
          <Route path="/" exact component={Fundings} />
          <Route component={NoMatch} />
        </Switch>
      </div>
    );
  }
}

export default Main;
