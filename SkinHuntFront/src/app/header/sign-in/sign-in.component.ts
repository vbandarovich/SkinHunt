import { Component, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MdbModalRef } from "mdb-angular-ui-kit/modal";
import {MdbFormsModule} from 'mdb-angular-ui-kit/forms';
import { MdbTabsComponent, MdbTabsModule } from 'mdb-angular-ui-kit/tabs';
import { AbstractControl, FormControl, FormGroup, MinLengthValidator, ReactiveFormsModule, Validators } from '@angular/forms';
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
    emailSignIn: new FormControl(null, { validators: [Validators.required, Validators.email], updateOn: 'change' }),
    passwordSignIn: new FormControl(null, { validators: [Validators.required, Validators.minLength(8)], updateOn: 'change' }),
  });

  signUpForm = new FormGroup({
    emailSignUp: new FormControl(null, { validators: [Validators.required, Validators.email], updateOn: 'change' }),
    passwordSignUp: new FormControl(null, { validators: [Validators.required, Validators.minLength(8)], updateOn: 'change' }),
    confirmPasswordSignUp: new FormControl(null, { validators: [Validators.required, Validators.minLength(8)], updateOn: 'change' })
  });

  constructor(public modalRef: MdbModalRef<SignInComponent>) {  
  }

  get SignInEmail(): AbstractControl {
    return this.signInForm.get('emailSignIn')!;
  }

  get SignInPassword(): AbstractControl {
    return this.signInForm.get('passwordSignIn')!;
  }

  get SignUpEmail(): AbstractControl {
    return this.signUpForm.get('emailSignUp')!;
  }

  get SignUpPassword(): AbstractControl {
    return this.signUpForm.get('passwordSignUp')!;
  }

  get SignUpRepeatPassword(): AbstractControl {
    return this.signUpForm.get('confirmPasswordSignUp')!;
  }

  setActiveTab() {
    this.tabs.setActiveTab(1);
  }

  onSubmitSignIn(){
    console.log(this.signInForm.value);
  }

  onSubmitSignUp(){
    console.log(this.signUpForm.value);
  }
}
