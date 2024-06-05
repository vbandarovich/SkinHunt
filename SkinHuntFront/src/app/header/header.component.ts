import { MdbCollapseModule } from 'mdb-angular-ui-kit/collapse';
import { MdbRippleModule } from 'mdb-angular-ui-kit/ripple';
import { MdbDropdownModule } from 'mdb-angular-ui-kit/dropdown';
import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MdbDropdownDirective } from 'mdb-angular-ui-kit/dropdown';
import { CommonModule } from '@angular/common';
import { SignInComponent } from './sign-in/sign-in.component';
import { MdbModalModule, MdbModalRef, MdbModalService } from 'mdb-angular-ui-kit/modal';

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
  styleUrls: ['./header.component.scss']
})

export class HeaderComponent implements AfterViewInit {
  @ViewChild('dropdown') dropdown!: MdbDropdownDirective;

  signInModalRef: MdbModalRef<SignInComponent> | null = null;

  constructor(private modalService: MdbModalService) {
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      this.dropdown.show();
    }, 2000);
  }

  openSignInModal() {
    this.signInModalRef = this.modalService.open(SignInComponent, {
      modalClass: 'modal-dialog-centered'
    })
  }
}
