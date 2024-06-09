import { Component } from "@angular/core";
import { RouterOutlet } from "@angular/router";
import { MdbCheckboxModule } from "mdb-angular-ui-kit/checkbox";
import { HeaderComponent } from "../../header/header.component";

@Component({
    selector: 'app-body',
    standalone: true,
    imports: [
      RouterOutlet,
      MdbCheckboxModule,
      HeaderComponent,
    ],
    template: `
        <div>
            <router-outlet></router-outlet>
        </div>
    `,
    styles: [
        `
        `,
    ]
  })
  export class BodyComponent {
  }
  