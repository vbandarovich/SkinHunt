import {MdbCollapseModule} from 'mdb-angular-ui-kit/collapse';
import {MdbRippleModule} from 'mdb-angular-ui-kit/ripple';
import { MdbDropdownModule} from 'mdb-angular-ui-kit/dropdown';
import {ChangeDetectionStrategy, Component } from '@angular/core';
import {CommonModule} from '@angular/common';
import {SignInComponent} from './sign-in/sign-in.component';
import {MdbModalModule, MdbModalRef, MdbModalService} from 'mdb-angular-ui-kit/modal';

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

  constructor(private modalService: MdbModalService) {
  }

  openSignInModal() {
    this.signInModalRef = this.modalService.open(SignInComponent, {
      modalClass: 'modal-dialog-centered'
    })
  }
}
