import { Component, input } from '@angular/core';
import { SkinModel } from '../../models/skinModel';

@Component({
  selector: 'app-skin-item-card-basket',
  standalone: true,
  imports: [],
  templateUrl: './skin-item-card-basket.component.html',
  styleUrl: './skin-item-card-basket.component.scss'
})
export class SkinItemCardBasketComponent {
  card = input.required<SkinModel>();
}
