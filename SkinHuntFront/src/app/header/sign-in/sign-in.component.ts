import { Component, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MdbModalRef } from "mdb-angular-ui-kit/modal";
import {MdbFormsModule} from 'mdb-angular-ui-kit/forms';
import { MdbTabsComponent, MdbTabsModule } from 'mdb-angular-ui-kit/tabs';
import { AbstractControl, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MdbValidationModule } from 'mdb-angular-ui-kit/validation';

@Component({
  selector: 'app-sign-in',
  standalone: true,
  imports: [
    CommonModule,
    MdbFormsModule,
    MdbTabsModule,
    MdbValidationModule, 
    ReactiveFormsModule
  ],
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})

export class SignInComponent {

  @ViewChild('tabs') tabs!: MdbTabsComponent;

  signInForm = new FormGroup({
    email: new FormControl(null, { validators: [Validators.required, Validators.email], updateOn: 'change' }),
    password: new FormControl(null, { validators: Validators.required, updateOn: 'change' }),
  });

  signUpForm = new FormGroup({
    email: new FormControl(null, { validators: [Validators.required, Validators.email], updateOn: 'change' }),
    password: new FormControl(null, { validators: [Validators.required, Validators.minLength(8)], updateOn: 'change' }),
    confirmPassword: new FormControl(null, { validators: [Validators.required], updateOn: 'change' })
  });

  constructor(public modalRef: MdbModalRef<SignInComponent>) {  
  }

  get LogInEmail(): AbstractControl {
    return this.signInForm.get('email')!;
  }

  get LogInPassword(): AbstractControl {
    return this.signInForm.get('password')!;
  }

  get SignUpEmail(): AbstractControl {
    return this.signUpForm.get('email')!;
  }

  get SignUpPassword(): AbstractControl {
    return this.signUpForm.get('password')!;
  }

  get SignUpRepeatPassword(): AbstractControl {
    return this.signUpForm.get('confirmPassword')!;
  }

  setActiveTab() {
    this.tabs.setActiveTab(1);
  }
}
