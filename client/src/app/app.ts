import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Home } from './home/home/home';
import { HttpGetService } from './CRUD/http-get-test/http-get-test';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Home, CommonModule],
  standalone: true,
  template: `
    <h1>Welcome to {{ title() }}!</h1>
    <app-home></app-home>
    <li *ngFor="let user of users$ | async">
     User: {{user.Username}}
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

  
}
