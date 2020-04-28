import React, {Component} from "react";
import {Button} from "@material-ui/core";
import {withStyles} from "@material-ui/styles";
import axios from "axios";
import {UserManager} from "../services/UserManager";

const styles = {

};

class SignIn extends Component {
  render = () => (
    <div>
      <Button href="/sensors/new" variant="outlined" color="primary">Add Sensor</Button>
    </div>
  );
  userManager = new UserManager();
  
  componentDidMount() {
    axios.get(`/api/sensors`, this.userManager.buildTokenAxiosConfig())
      .then(res =>
        this.setState({ sensors: res.data })
      )
  };
}

export default withStyles(styles)(SignIn);