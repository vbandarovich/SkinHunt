import { Injectable } from "@angular/core";
import { User } from "../models/User";
import { HttpClient } from "@angular/common/http";
import { API_URL } from "../constants/URL";
import { tap } from "rxjs";

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private readonly http: HttpClient) {}

  updateAvatar(userId: string, avatar: string){
    const command = {
      userId,
      avatar
    };

    return this.http
      .post<User>(`${API_URL}/users`, command)
      .pipe(
        tap((res) => {
          if (res != null) {
            localStorage.setItem('user', JSON.stringify(res));
          }
        })
      );
  }
}
