import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class BaseUrlService {

  constructor (private router: Router) { }

  BaseUrl() {
    return "https://localhost:44333"
  }
  RedirectUrl() {
    return "http://localhost:4200"
  }
}
