import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5045/api';
  private tokenSubject: BehaviorSubject<string>;
  public token: Observable<string>;

  constructor(private http: HttpClient, private router: Router) {
    const token = localStorage.getItem('token') || '';
    this.tokenSubject = new BehaviorSubject<string>(token);
    this.token = this.tokenSubject.asObservable();
  }

  public get tokenValue(): string {
    return this.tokenSubject.value;
  }

  login(username: string, password: string) {
    return this.http.post<any>(`${this.apiUrl}/account/login`, { username, password })
      .pipe(map(response => {
        if (response.token) {
          localStorage.setItem('token', response.token);
          this.tokenSubject.next(response.token);
        }
        return response;
      }));
  }

  register(username: string, email: string, password: string) {
    return this.http.post<any>(`${this.apiUrl}/account/register`, { username, email, password })
      .pipe(map(response => {
        if (response.token) {
          localStorage.setItem('token', response.token);
          this.tokenSubject.next(response.token);
        }
        return response;
      }));
  }

  logout() {
    localStorage.removeItem('token');
    this.tokenSubject.next('');
    this.router.navigate(['/login']);
  }

}

