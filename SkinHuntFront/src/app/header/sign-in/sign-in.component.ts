import { Component, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MdbModalRef } from "mdb-angular-ui-kit/modal";
import {MdbFormsModule} from 'mdb-angular-ui-kit/forms';
import { MdbTabsComponent, MdbTabsModule } from 'mdb-angular-ui-kit/tabs';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  ValidationErrors,
  ValidatorFn,
  Validators
} from '@angular/forms';
import { MdbValidationModule } from 'mdb-angular-ui-kit/validation';

export  const  PasswordValidator:  ValidatorFn  = (control:AbstractControl):  ValidationErrors|  null  =>{
  const  password  =  control.get('passwordSignUp');
  const  confirmpassword  =  control.get('confirmPasswordSignUp');

  if (password  &&  confirmpassword  &&  password.value  !==  confirmpassword.value){
    return { passwordMismatch :  true }
  }

  return  null;
}

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
    emailSignIn: new FormControl<string>('', { validators: [Validators.required, Validators.email], updateOn: 'change' }),
    passwordSignIn: new FormControl<string>('', { validators: [Validators.required, Validators.minLength(8)], updateOn: 'change' }),
  });

  signUpForm = new FormGroup({
    emailSignUp: new FormControl<string>('', { validators: [Validators.required, Validators.email], updateOn: 'change' }),
    passwordSignUp: new FormControl<string>('', { validators: [Validators.required, Validators.minLength(8)], updateOn: 'change' }),
    confirmPasswordSignUp: new FormControl<string>('', { validators: [Validators.required, Validators.minLength(8)], updateOn: 'change' })
  },
    {
      validators: PasswordValidator,
    });

  constructor(public modalRef: MdbModalRef<SignInComponent>) {
  }

  get SignInEmail() {
    return this.signInForm.controls.emailSignIn;
  }

  get SignInPassword() {
    return this.signInForm.controls.passwordSignIn;
  }

  get SignUpEmail() {
    return this.signUpForm.controls.emailSignUp;
  }

  get SignUpPassword() {
    return this.signUpForm.controls.passwordSignUp;
  }

  get SignUpRepeatPassword() {
    return this.signUpForm.controls.confirmPasswordSignUp;
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
