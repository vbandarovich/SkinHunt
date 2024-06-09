import { Routes } from '@angular/router';
import { BuyPageComponent } from './body/buy-page/buy-page.component';

export const BODY_ROUTES: Routes = [
    { path: '', pathMatch: 'full', component: BuyPageComponent }
  ]
