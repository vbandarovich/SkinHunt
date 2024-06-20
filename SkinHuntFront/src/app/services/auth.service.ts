import { HttpClient, HttpStatusCode } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { AuthUser } from "../models/user-model";

@Injectable({
    providedIn: 'root',
})
export class AuthService {
    constructor(
        private readonly http: HttpClient,
        private readonly router: Router,
    ) 
    { }

    signUp(userData: AuthUser){
        return this.http
        .post("https://localhost:44348/api/signUp", userData)
        .subscribe();
    }

    signIn(userData: AuthUser){
        return this.http
        .post("https://localhost:44348/api/signIn", userData)
        .subscribe();
    }
}