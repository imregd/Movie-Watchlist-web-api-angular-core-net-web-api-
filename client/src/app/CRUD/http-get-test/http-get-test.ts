import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";


@Injectable({ providedIn: 'root' })
export class HttpGetService {
  constructor(private http: HttpClient) {
  }

  getUserData(): Observable<any> {
    return this.http.get('https://localhost:7278/api/users');
  }
    
  }
