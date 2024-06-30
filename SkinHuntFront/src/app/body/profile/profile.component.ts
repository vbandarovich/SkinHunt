import {Component, inject, OnInit, signal} from '@angular/core';
import {UserService} from "../../services/user.service";
import {AuthService} from "../../services/auth.service";

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss'
})
export class ProfileComponent implements OnInit {
  userService = inject(UserService);
  authService = inject(AuthService);
  selectedImage$ = signal<string>("../../../assets/unAuthAvatar.jpg");
  userEmail$ = signal<string>('-');
  userNumber$ = signal<string>('-');

  ngOnInit() {
    const avatar = this.authService.user$()?.avatar;
    const email = this.authService.user$()?.email;
    const phoneNumber = this.authService.user$()?.phoneNumber;

    if (avatar) {
      this.selectedImage$.set(avatar);
    }

    if (email) {
      this.userEmail$.set(email);
    }

    if (phoneNumber) {
      this.userNumber$.set(phoneNumber);
    }
  }

  onFileSelected(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    const file = inputElement.files![0];

    if (file) {
      const reader = new FileReader();
      reader.onload = (e) => {
        this.selectedImage$.set(e.target!.result as string);
        const userId = this.authService.user$()?.id;
        if (userId) {
          this.userService.updateAvatar(userId, e.target!.result as string).subscribe((user) => {
            this.authService.user$.set(user);
          });
        }
      };
      reader.readAsDataURL(file);
    }
  }
}
