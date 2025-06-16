import { HttpInterceptorFn } from '@angular/common/http';
import { environment }    from '../../enviroments/environment';

export const apiKeyInterceptor: HttpInterceptorFn = (req, next) => {
  const authReq = req.clone({
    setHeaders: { 'X-Api-Key': environment.apiKey }
  });
  return next(authReq);
};
