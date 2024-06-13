import {ChangeDetectionStrategy, Component, effect, OnInit, signal} from '@angular/core';
import {MdbRippleModule} from 'mdb-angular-ui-kit/ripple';
import { MdbDropdownModule} from 'mdb-angular-ui-kit/dropdown';
import {SkinItemCardComponent} from "../skin-item-card/skin-item-card.component";
import {FormsModule} from "@angular/forms";

export interface ItemCard {
  name: string;
  price: number;
}
@Component({
  selector: 'app-buy-page-main',
  standalone: true,
  imports: [
    MdbDropdownModule,
    MdbRippleModule,
    SkinItemCardComponent,
    FormsModule,
  ],
  templateUrl: './buy-page-main.component.html',
  styleUrl: './buy-page-main.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})

export class BuyPageMainComponent implements OnInit{
  cards$ = signal<ItemCard[]>([]);

  typehead$ = signal<string>('');

  ngOnInit() {
    this.setCards();
  }

  setCards() {
    this.cards$.set([
      {
        name: 'cardName1',
        price: 100,
      },
      {
        name: 'cardName2',
        price: 150,
      },
      {
        name: 'cardName3',
        price: 100,
      },
      {
        name: 'cardName4',
        price: 100,
      },
      {
        name: 'cardName5',
        price: 100,
      },
      {
        name: 'cardName6',
        price: 100,
      },
      {
        name: 'cardName7',
        price: 100,
      },
      {
        name: 'cardName8',
        price: 100,
      },
      {
        name: 'cardName9',
        price: 100,
      },
      {
        name: 'cardName10',
        price: 100,
      },
      {
        name: 'cardName11',
        price: 100,
      },
      {
        name: 'cardName12',
        price: 100,
      },
      {
        name: 'cardName13',
        price: 100,
      },
      {
        name: 'cardName14',
        price: 100,
      },
      {
        name: 'cardName15',
        price: 100,
      },
      {
        name: 'cardName16',
        price: 100,
      },
      {
        name: 'cardName17',
        price: 100,
      },
      {
        name: 'cardName18',
        price: 100,
      },
      {
        name: 'cardName19',
        price: 100,
      },
      {
        name: 'cardName20',
        price: 100,
      },
      {
        name: 'cardName21',
        price: 100,
      },
      {
        name: 'cardName22',
        price: 100,
      },
      {
        name: 'cardName23',
        price: 100,
      },
      {
        name: 'cardName24',
        price: 100,
      },
      {
        name: 'cardName25',
        price: 100,
      },
      {
        name: 'cardName26',
        price: 100,
      },
      {
        name: 'cardName27',
        price: 100,
      },
      {
        name: 'cardName28',
        price: 100,
      },
      {
        name: 'cardName29',
        price: 100,
      },
      {
        name: 'cardName30',
        price: 100,
      },
      {
        name: 'cardName31',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName29',
        price: 100,
      },
      {
        name: 'cardName30',
        price: 100,
      },
      {
        name: 'cardName31',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName29',
        price: 100,
      },
      {
        name: 'cardName30',
        price: 100,
      },
      {
        name: 'cardName31',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName29',
        price: 100,
      },
      {
        name: 'cardName30',
        price: 100,
      },
      {
        name: 'cardName31',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName29',
        price: 100,
      },
      {
        name: 'cardName30',
        price: 100,
      },
      {
        name: 'cardName31',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName29',
        price: 100,
      },
      {
        name: 'cardName30',
        price: 100,
      },
      {
        name: 'cardName31',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName29',
        price: 100,
      },
      {
        name: 'cardName30',
        price: 100,
      },
      {
        name: 'cardName31',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
      {
        name: 'cardName33',
        price: 100,
      },
      {
        name: 'cardName32',
        price: 100,
      },
    ]);
  }
}
