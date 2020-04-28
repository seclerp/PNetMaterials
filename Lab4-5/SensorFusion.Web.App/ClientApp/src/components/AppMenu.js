import React, {Component} from "react";
import withStyles from "@material-ui/core/styles/withStyles";
import {List} from "@material-ui/core";
import AppIcon from "./AppIcon";
import ListItem from "@material-ui/core/ListItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";
import { Link } from "react-router-dom";

class AppMenu extends Component {
  render () {
    return (
      <List>
        {this.props.menu.map(item => (
          <ListItem button component={Link} to={item.route}>
            <ListItemIcon><AppIcon name={item.icon} /></ListItemIcon>
            <ListItemText primary={item.title} />
          </ListItem>
        ))}
      </List>
    )
  }
}

export default AppMenu;