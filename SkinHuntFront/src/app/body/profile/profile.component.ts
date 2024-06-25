import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss'
})
export class ProfileComponent {
  selectedImage$ = signal<string>("../../../assets/unAuthAvatar.jpg");

  onFileSelected(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    const file = inputElement.files![0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e) => {
        this.selectedImage$.set(e.target!.result as string);
      };
      reader.readAsDataURL(file);
    }
  }
}
