import {MdbCollapseModule} from 'mdb-angular-ui-kit/collapse';
import {MdbRippleModule} from 'mdb-angular-ui-kit/ripple';
import { MdbDropdownModule} from 'mdb-angular-ui-kit/dropdown';
import {ChangeDetectionStrategy, Component, signal} from '@angular/core';
import {CommonModule} from '@angular/common';
import {SignInComponent} from './sign-in/sign-in.component';
import {MdbModalModule, MdbModalRef, MdbModalService} from 'mdb-angular-ui-kit/modal';
import {InterfaceLanguage} from "../models/interface-language";
import {Currency} from "../models/currency";

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    CommonModule,
    MdbCollapseModule,
    MdbRippleModule,
    MdbDropdownModule,
    MdbModalModule
  ],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class HeaderComponent {

  signInModalRef: MdbModalRef<SignInComponent> | null = null;

  language$ = signal<InterfaceLanguage>('eng');
  currency$ = signal<Currency>('usd');

  constructor(private modalService: MdbModalService) {
  }

  openSignInModal() {
    this.signInModalRef = this.modalService.open(SignInComponent, {
      modalClass: 'modal-dialog-centered'
    })
  }

  setLanguage(language: InterfaceLanguage) {
    this.language$.set(language);
  }

  setCurrency(currency: Currency) {
    this.currency$.set(currency);
  }
}
