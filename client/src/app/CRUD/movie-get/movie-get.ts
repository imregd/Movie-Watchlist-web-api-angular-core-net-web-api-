import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { InjectableGET } from './injectableget';
import { MovieModel } from './MovieModel';
import { Observable } from 'rxjs';

@Component({
  selector: 'get-user',
  imports: [CommonModule,FormsModule],
  template: `

  <ng-template #loading>Loading movies...</ng-template>

  <input type="text" [(ngModel)]="idinputvalue" placeholder ="Type a user ID"/>
  <button (click)="submitidinput()">Submit ID</button>
  <p>CURRENT VALUE: {{ idinputvalue }}</p>

  <p> Movies from user ID {{ idinputvalue }}:</p>
    <ul>
      <li *ngFor="let movie of movies$ | async">
        NAME: {{ movie.movieName }} <br>
        WATCHED: {{ movie.movieWatched }} <br>
        RATING: {{ movie.movieRating }}
      </li>
    </ul>



  <H3>input test</H3>
      <input type="text" [(ngModel)]="Inputvalue" placeholder ="Type a username"/>

      <button (click)="submitInput()">Submit</button>

      <p>You typed: {{ Inputvalue }}</p>
  `,
  styles: ``
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
    
  



