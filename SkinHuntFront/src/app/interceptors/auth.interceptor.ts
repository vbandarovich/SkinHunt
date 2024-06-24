import { HttpInterceptorFn } from '@angular/common/http';

export const customInterceptor: HttpInterceptorFn = (req, next) => {

  if (req.url.includes('/signIn')) {
    return next(req);
  }

  if (req.url.includes('/signUp')) {
    return next(req);
  }
  
  const token = localStorage.getItem('token');

  if(token){
    const cloneRequest = req.clone({
      setHeaders:{
        Authorization: `Bearer ${token}`
        }
      });

    return next(cloneRequest);
  }

  return next(req);
};
