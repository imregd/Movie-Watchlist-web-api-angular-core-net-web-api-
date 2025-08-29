import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Home } from './home/home/home';
import { HttpGetService } from './CRUD/http-get-test/http-get-test';
import { CommonModule } from '@angular/common';
import { MovieGET } from './CRUD/movie-get/movie-get';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Home, CommonModule, MovieGET],
  standalone: true,
  template: `
    <h1>Welcome to {{ title() }}!</h1>
    <app-home></app-home>
    <h3> GET movies from a specific USER</h3>
    <get-user></get-user>
    <h2>Users</h2>
    <p>Users are fetched from the API and displayed below:</p>
    <li *ngFor="let user of users$ | async">
     User: {{user.username}}
     </li>
    <router-outlet />
  `,
  styles: [],
})
export class App {
  users$!: any; // declare so its usable, the $ indicates it's an observable which is something that emits values over time

  protected readonly title = signal('client');

  constructor(private httpGetService: HttpGetService) {
    this.users$ = this.httpGetService.getUserData(); // observable for user data
  }



  
}//      User 2: {{user | json}} outputs all of it in a json array format
