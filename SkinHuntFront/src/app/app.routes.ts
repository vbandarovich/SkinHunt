import { Routes } from '@angular/router';
import { BuyPageComponent } from './body/buy-page/buy-page.component';
import { ProfileComponent } from './body/profile/profile.component';
import { authGuard } from './guards/auth.guard';

export const BODY_ROUTES: Routes = [
  { path: '',
    pathMatch: 'full',
    component: BuyPageComponent
  },
  { 
    path: 'profile',
    pathMatch: 'full',
    component: ProfileComponent,
    canActivate: [ authGuard() ]
  },
]
