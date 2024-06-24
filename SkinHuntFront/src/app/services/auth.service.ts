import { HttpClient, HttpStatusCode } from "@angular/common/http";
import { Injectable, signal } from "@angular/core";
import { Router } from "@angular/router";
import { AuthUser } from "../models/authUser";
import { API_URL } from "../constants/URL";
import { tap } from "rxjs";
import { SignInResultModel } from "../models/sign-in-result-model";

@Injectable({
    providedIn: 'root',
})
export class AuthService {

    isAuth$ = signal<boolean>(false);

    constructor(
        private readonly http: HttpClient,
    ) 
    {
        const token = localStorage.getItem("token");
        this.isAuth$.set(!!token);
    }

    signUp(userData: AuthUser){
        return this.http
        .post<SignInResultModel>(`${API_URL}/signUp`, userData)
        .pipe(
            tap((res) => {
                if(res != null){
                    localStorage.setItem("token", res.token);
                    this.isAuth$.set(true);
                }
            })
        );
    }

    signIn(userData: AuthUser){
        return this.http
        .post<SignInResultModel>(`${API_URL}/signIn`, userData)
        .pipe(
            tap((res) => {
                if(res != null){
                    localStorage.setItem("token", res.token);
                    this.isAuth$.set(true);
                }
            })
        );
    }

    logOut(){
        localStorage.removeItem("token");
        this.isAuth$.set(false);
    }
}