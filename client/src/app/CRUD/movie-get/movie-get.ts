import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { InjectableGET } from './injectableget';
import { MovieModel } from '../MovieModel';
import { Observable } from 'rxjs';

@Component({
  selector: 'get-user',
  imports: [CommonModule,FormsModule],
  template: `

  <ng-template #loading>Loading movies...</ng-template>

  <input type="text" [(ngModel)]="idinputvalue" placeholder ="Type a user ID"/>


  <button (click)="submitidinput()">GET USER ID: {{idinputvalue}}</button>

  <p> Movies from user ID {{ idinputvalue }}:</p>

  <ul>
  @for (movie of movies$ | async; track movie.movieName){
      <li>
        NAME: {{ movie.movieName }} <br>
        WATCHED: {{ movie.movieWatched }} <br>
        RATING: {{ movie.movieRating }}
        
      </li>
  } @empty {
    <p>No movies found. :( </p>
  }
  </ul>
  `,
  styles: `button {
    display: block;
    }`
})
export class MovieGET {
  Inputvalue: string = '';
  idinputvalue = '';
  movies$!: Observable<MovieModel[]>;


  submitInput() {
    console.log('User typed:', this.Inputvalue);
    alert(`You typed: ${this.Inputvalue}`);
  }

  submitidinput() {
    console.log('User typed:', this.idinputvalue);
    this.movies$ = this.injectableget.getmoviedata(this.idinputvalue);
  }

  constructor(private injectableget: InjectableGET) { }
  }
    
  



