import { routes } from './app.routes';
import { provideRouter } from '@angular/router';
import { ApplicationConfig } from '@angular/core';
import { errorInterceptor } from './interceptors/error.interceptor';
import { apiKeyInterceptor } from './interceptors/api-key.interceptor';
import { provideHttpClient, withInterceptors  } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideHttpClient(withInterceptors([ apiKeyInterceptor, errorInterceptor ])),    
  ]
};
