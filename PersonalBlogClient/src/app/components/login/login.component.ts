import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { HttpService } from '../../services/http.service';
import { SwalService } from '../../services/swal.service';
import { LoginModel } from '../../models/login.model';
import { FormsModule, NgForm } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  model: LoginModel = new LoginModel();

  constructor(private http: HttpService<any>, private swal: SwalService, private router: Router) { }

  login(form: NgForm) {
    if (form.valid) {
      this.http.login('Auth', this.model).subscribe({
        next: (res) => {
          console.log(res);

          localStorage.setItem('token', res.token)
          form.resetForm();
          this.router.navigateByUrl('/admin');
          this.swal.callToast('Welcome', 'info');
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);

          this.swal.callToast(err.error.error, 'error');
        }
      })
    }
  }
}
