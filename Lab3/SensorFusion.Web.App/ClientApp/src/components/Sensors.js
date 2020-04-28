import React, {Component} from "react";
import {Button} from "@material-ui/core";
import {withStyles} from "@material-ui/styles";
import axios from "axios";

const styles = {

};

class Sensors extends Component {
  render = () => (
    <div>
      <Button variant="outlined" color="primary">Add Sensor</Button>
    </div>
  );

  componentDidMount() {
    axios.get(`/api/staticdata`)
      .then(res =>
        this.setState({staticdata: res.data})
      )
  };
}

export default withStyles(styles)(Sensors);