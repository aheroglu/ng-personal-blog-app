import { Component } from '@angular/core';
import { HttpService } from '../../../services/http.service';
import { AboutModel } from '../../../models/about.model';
import { SwalService } from '../../../services/swal.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-about',
  standalone: true,
  imports: [],
  templateUrl: './about.component.html',
  styleUrl: './about.component.css'
})
export class AboutComponent {
  about: AboutModel | undefined;

  constructor(private http: HttpService<AboutModel>, private swal: SwalService) {
    this.getAbout();
  }

  getAbout() {
    this.http.getAll('Abouts').subscribe({
      next: res => {
        this.about = res[0];
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
      }
    })
  }
}
