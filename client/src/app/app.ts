import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Home } from './home/home';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Home],
  template: `
    <h1>Welcome to {{ title() }}!</h1>
    <app-home></app-home>
    <router-outlet />
  `,
  styles: [],
})
export class App {
  protected readonly title = signal('client');
}
