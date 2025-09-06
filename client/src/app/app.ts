import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Home } from './home/home/home';
import { CommonModule } from '@angular/common';
import { MovieGET } from './CRUD/movie-get/movie-get';
import { MoviePOST } from './CRUD/movie-post/movie-post';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Home, CommonModule, MovieGET, MoviePOST],
  standalone: true,
  template: `
    <h1> GET movies from a specific USER</h1>
    <get-user></get-user>

    <post-movie></post-movie>
  `,
  styles: [],
})
export class App {
  // users$!: any;declare so its usable, the $ indicates it's an observable which is something that emits values over time

  protected readonly title = signal('client');

  
}//      User 2: {{user | json}} outputs all of it in a json array format
