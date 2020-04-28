export default class UserManager {
  buildTokenAxiosConfig = () => ({
    headers: {'Authorization': "bearer " + localStorage.getItem("token")}
  });
  isAuthorized = () => localStorage.getItem("token") != null;
  login = (token) => localStorage.setItem("token", token);
  logout = () => localStorage.setItem("token", null);
}