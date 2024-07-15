import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { SwalService } from './swal.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private router: Router, private swal: SwalService) { }

  isAuthenticated() {
    const token = localStorage.getItem('token');
    if (token) {
      return true;
    } else {
      this.router.navigateByUrl('/login');
      this.swal.callToast('Please login!', 'warning');
      return false;
    }
  }

  logout() {
    localStorage.clear();
    this.router.navigateByUrl('/');
    this.swal.callToast('Logged out', 'info');
  }
}
