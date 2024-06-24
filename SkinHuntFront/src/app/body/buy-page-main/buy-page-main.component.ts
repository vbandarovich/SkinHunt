import {ChangeDetectionStrategy, Component, effect, OnInit, signal} from '@angular/core';
import {MdbRippleModule} from 'mdb-angular-ui-kit/ripple';
import { MdbDropdownModule} from 'mdb-angular-ui-kit/dropdown';
import {SkinItemCardComponent} from "../skin-item-card/skin-item-card.component";
import {FormsModule} from "@angular/forms";
import {FiltersSubmenuItems} from "../../models/filters-submenu-items";
import { SortItems } from '../../models/sort';
import { MdbCheckboxModule } from 'mdb-angular-ui-kit/checkbox';
import { HttpClient } from '@angular/common/http';
import { API_URL } from '../../constants/URL';
import { SkinModel } from '../../models/skinModel';

@Component({
  selector: 'app-buy-page-main',
  standalone: true,
  imports: [
    MdbDropdownModule,
    MdbRippleModule,
    MdbCheckboxModule,
    SkinItemCardComponent,
    FormsModule,
  ],
  templateUrl: './buy-page-main.component.html',
  styleUrl: './buy-page-main.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})

export class BuyPageMainComponent implements OnInit{
  cards$ = signal<SkinModel[]>([]);

  sort$ = signal<SortItems>('default');
  typehead$ = signal<string>('');
  showSubmenuList$ = signal<FiltersSubmenuItems[]>([]);

  constructor(private readonly http: HttpClient){}

  ngOnInit() {
    this.setCards();
  }

  onChangedSubmenuList(submenu: FiltersSubmenuItems) {
    if (this.showSubmenuList$().includes(submenu)) {
      this.showSubmenuList$.set(this.showSubmenuList$().filter((item) => item !== submenu));
    } else {
      this.showSubmenuList$.update((items) => [...items, submenu]);
    }
  }

  setSort(sortItem: SortItems) {
    this.sort$.set(sortItem);
  }

  setCards(){
    this.http.get<SkinModel[]>(`${API_URL}/skins`).subscribe(
      (response: SkinModel[]) => {
        this.cards$.set(response);
        console.log(response);
      });
  }
}
