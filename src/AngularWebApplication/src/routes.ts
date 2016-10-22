/// <reference path="../typings/index.d.ts"/>

import {Injectable} from '@angular/core';
import {UIRouter} from 'ui-router-ng2/router';
import {HelloComponent} from './app/hello';
import {PersonasComponent} from "./personas/personas";
import {Users} from "./github/users";

const INITIAL_STATES: any[] = [
  {name: 'App', url: '/', component: HelloComponent},
  {name: 'personas', url: '/personas', component: PersonasComponent},
  {name: 'users', url: '/users', component: Users}
];

@Injectable()
export class MyUIRouterConfig {
  configure(uiRouter: UIRouter) {
    uiRouter.urlRouterProvider.otherwise(() => uiRouter.stateService.go('App', null, null));
    uiRouter.stateRegistry.root();
    INITIAL_STATES.forEach(state => uiRouter.stateRegistry.register(state));
  }
}
