import { Component } from '@angular/core';
import {MdbRippleModule} from 'mdb-angular-ui-kit/ripple';
import { MdbDropdownModule} from 'mdb-angular-ui-kit/dropdown';

@Component({
  selector: 'app-buy-page-main',
  standalone: true,
  imports: [
    MdbDropdownModule, 
    MdbRippleModule,
  ],
  templateUrl: './buy-page-main.component.html',
  styleUrl: './buy-page-main.component.scss'
})

export class BuyPageMainComponent {

}
