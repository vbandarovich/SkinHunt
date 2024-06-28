import {ChangeDetectionStrategy, Component, computed, effect, OnInit, signal} from '@angular/core';
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

  cardsList$ = computed(() => {
    if (this.typehead$()) {
      return this.cards$().filter((o) => o.name.toLowerCase().includes(this.typehead$().toLowerCase()));
    }

    return this.cards$();
  });

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
    this.setCards();
  }

  setCards(){
    const apiUrl = `${API_URL}/skins?option=${this.sort$()}`;

    this.http.get<SkinModel[]>(apiUrl).subscribe(
      (response: SkinModel[]) => {
        this.cards$.set(response);
    });
  }
}
