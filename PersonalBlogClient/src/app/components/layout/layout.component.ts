import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { SocialModel } from '../../models/social.model';
import { HttpService } from '../../services/http.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [RouterOutlet, RouterLink],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent {
  socials: SocialModel[] = [];

  constructor(private http: HttpService<SocialModel>) {
    this.getAll();
  }

  getAll() {
    this.http.getAll('Socials').subscribe({
      next: res => {
        this.socials = res;
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
      }
    })
  }
}
