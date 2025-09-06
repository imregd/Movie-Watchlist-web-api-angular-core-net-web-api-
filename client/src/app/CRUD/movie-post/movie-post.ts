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
  <p> USER ID: <input type="text" [(ngModel)]="idinputvalue" placeholder ="Type a user ID"/> </p>

  <p> Movie Data to POST: </p>
  <ul>
    <li> <input type="text" [(ngModel)]="movie.movieName" placeholder ="Type a movie name"/> </li>
    <li> <input type="checkbox" [(ngModel)]="movie.movieWatched"/> Watched </li>
    <li> <input type="number" [(ngModel)]="movie.movieRating" placeholder ="Type a movie rating"/> </li>

    <li> <button (click) = "submitmovieinput()">POST Movie</button> </li>



  `,
  styles: ``
})
export class MoviePOST {
  movie: MovieModel = {
    movieName: '',
    movieWatched: false,
    movieRating: 0
  };

  idinputvalue = '';

  constructor(private injectablepost: InjectablePOST) { }

  submitmovieinput()
  {
    this.injectablepost.PostData(this.movie, this.idinputvalue).subscribe({
      next: (response) => {
        alert(`POSTED movie data for user ID: ${this.idinputvalue}`);
      },
      error: (err) => {
        console.error(err);
        alert(`ERROR POSTING! Check console for details (F12)`);
      }
    });


    
    
  }

}
