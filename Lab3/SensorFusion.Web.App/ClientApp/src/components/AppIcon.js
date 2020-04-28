import React, {Component} from "react";
import {Icon, SvgIcon} from "@material-ui/core";

class AppIcon extends Component {
  render = () => (
    <Icon>{this.props.name}</Icon>
  )
}

export default AppIcon;