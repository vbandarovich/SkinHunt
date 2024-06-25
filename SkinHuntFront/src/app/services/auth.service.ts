import { HttpClient } from "@angular/common/http";
import { Injectable, signal } from "@angular/core";
import { AuthUser } from "../models/authUser";
import { API_URL } from "../constants/URL";
import { tap } from "rxjs";
import {User} from "../models/User";

@Injectable({
    providedIn: 'root',
})
export class AuthService {

    isAuth$ = signal<User | null>(null);

    constructor(
        private readonly http: HttpClient,
    )
    {
      const user = localStorage.getItem('user');

      if (user) {
        this.isAuth$.set(JSON.parse(user));
      }
    }

    signUp(userData: AuthUser){
        return this.http
        .post<User>(`${API_URL}/signUp`, userData)
        .pipe(
            tap((res) => {
                if(res != null){
                    localStorage.setItem('user', JSON.stringify(res));
                    this.isAuth$.set(res);
                }
            })
        );
    }

    signIn(userData: AuthUser){
        return this.http
        .post<User>(`${API_URL}/signIn`, userData)
        .pipe(
            tap((res) => {
                if(res != null){
                  localStorage.setItem('user', JSON.stringify(res));
                  this.isAuth$.set(res);
                }
            })
        );
    }

    logOut(){
        localStorage.removeItem("user");
        this.isAuth$.set(null);
    }
}
