// INJECTABLE FILE

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MovieModel } from '../MovieModel';


@Injectable({ providedIn: 'root' })
export class InjectablePOST {

  constructor(private http: HttpClient) { }


  PostData(data: MovieModel, inputvalue: string)
  {
    return this.http.post('https://localhost:7278/api/users/' + inputvalue + '/UserMovies', data);
  }

}
