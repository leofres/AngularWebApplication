import {Http} from "@angular/http";
import {Component} from "@angular/core";
import 'rxjs/Rx';
import {User} from "../models/user";

@Component({
  selector: 'users',
  template: require('./users.html'),
  providers: []
})
export class Users{
  private usersGithub: User[];

  constructor(private http: Http){
    debugger;
    http.get('https://api.github.com/users')
      .toPromise()
      .then((response) => {
        this.usersGithub = response.json() as User[]
      });
  }
}
