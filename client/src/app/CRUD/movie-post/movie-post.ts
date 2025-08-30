// main file for input movie post data


import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { InjectablePOST } from './injectablepost';
import { MovieModel } from '../MovieModel';

@Component({
  selector: 'post-movie', 
  imports: [CommonModule, FormsModule],
  template: `
   <h1>POST movie data for a USER</h1>
  <input type="text" [(ngModel)]="idinputvalue" placeholder ="Type a user ID"/>



  <input type="text" [(ngModel)]="movie.movieName" placeholder ="Type a movie name"/>
  <input type="checkbox" [(ngModel)]="movie.movieWatched"/> Watched
  <input type="number" [(ngModel)]="movie.movieRating" placeholder ="Type a movie rating"/>

  <button (click) = "submitmovieinput()">POST Movie</button>



  `,
  styles: ``
})
export class postMovie {
  movie: MovieModel = {
    movieName: '',
    movieWatched: false,
    movieRating: 0
  };

  idinputvalue = '';


  constructor(private injectablepost: InjectablePOST) { }

  submitmovieinput()
  {
    console.log('User typed:', this.idinputvalue, '\nAttempting POST...');
  }

}
