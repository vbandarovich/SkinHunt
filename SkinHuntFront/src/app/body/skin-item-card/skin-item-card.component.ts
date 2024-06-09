import {Component} from "@angular/core";
import {RouterOutlet} from "@angular/router";
import {MdbCheckboxModule} from "mdb-angular-ui-kit/checkbox";
import {HeaderComponent} from "../../header/header.component";

@Component({
  selector: 'skin-item-card',
  standalone: true,
  imports: [
    RouterOutlet,
    MdbCheckboxModule,
    HeaderComponent,
  ],
  template: `
    <div class="card-container">
      text
    </div>
    `,
  styles: [
    `
      .card-container {
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        width: 161px;
        height: 218px;
        background: #fff;
      }
    `,
  ]
})
export class SkinItemCardComponent {
}
