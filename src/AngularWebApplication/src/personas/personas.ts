import {Component} from "@angular/core";
import {Persona} from "../models/persona";
import {Http} from "@angular/http";
import * as _ from "underscore.string";
import 'rxjs/Rx';

@Component({
  selector: 'personas',
  template: require('./personas.html')
})
export class PersonasComponent{
  public title: string;
  public personas: Persona[];
  public selectedPerson: Persona;
  public page: number;
  public search: string;

  constructor(private http: Http) {
    this.page = 1;
    this.title = "Personas";
    this.personas = [];
    this.loadPersonas();
  }

  onSelectPerson(persona: Persona): void {
    this.selectedPerson = persona;
  }

  onNewPerson(): void {
    this.selectedPerson = new Persona();
  }

  addPerson(persona: Persona): void {
    this.personas.push(persona);
  }

  nextPage(): void {
      this.page = this.page + 1;
      this.loadPersonas();
  }

  previousPage(): void {
      if (this.page > 1) {
          this.page = this.page - 1;
          this.loadPersonas();
      }
  }

  searchPersona() {
      this.loadPersonas();
  }

  loadPersonas() {
      let params: string[] = [];
      let queryParams:string  = "";

      params.push(`page=${this.page}`);

      if (!_.isBlank(this.search)) {
          params.push(`search=${this.search}`);
      }

      if (params.length > 0) {
          queryParams = "?" + params.join("&");
      }

      this.http.get(`/api/people${queryParams}`)
          .toPromise()
          .then((response) => {
              this.personas = response.json() as Persona[];
          });
  }
}
