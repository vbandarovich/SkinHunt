import { Component, OnInit, inject, signal } from '@angular/core';
import { SideNavComponent } from '../side-nav/side-nav.component';
import { SkinService } from '../../services/skin.service';
import { SkinItemCardBasketComponent } from '../skin-item-card-basket/skin-item-card-basket.component';
import { AuthService } from '../../services/auth.service';
import { SkinItemCardComponent } from "../skin-item-card/skin-item-card.component";
import { BasketValue } from '../../models/basket-value';

@Component({
    selector: 'app-basket',
    standalone: true,
    templateUrl: './basket.component.html',
    styleUrl: './basket.component.scss',
    imports: [
        SideNavComponent,
        SkinItemCardBasketComponent,
        SkinItemCardComponent
    ]
})
export class BasketComponent implements OnInit {
  skinService = inject(SkinService);
  authService = inject(AuthService);
  
  basketValueList$ = signal<BasketValue[]>([]);

  ngOnInit() {
    const userId = this.authService.user$()?.id;

    if (userId) {
      this.skinService.getUserBasketValue(userId)
        .subscribe((res) => {
          this.basketValueList$.set(res);
        });
    }
  }
}
