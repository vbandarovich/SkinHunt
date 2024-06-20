import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideHttpClient } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter([
      { 
        path: '',
        loadChildren: () => import('./app.routes')
          .then(r => r.BODY_ROUTES)
      },
    ]),
    provideAnimations(),
    provideHttpClient(),
  ]
};
