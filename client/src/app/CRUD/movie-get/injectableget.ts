import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { MovieModel } from "./MovieModel";


@Injectable({ providedIn: 'root' })
export class InjectableGET {

  constructor(private http: HttpClient) {
  }


  getmoviedata(inputvalue: string): Observable<MovieModel[]> {
    return this.http.get < MovieModel[]>('https://localhost:7278/api/users/' + inputvalue + '/UserMovies');
  }
}
