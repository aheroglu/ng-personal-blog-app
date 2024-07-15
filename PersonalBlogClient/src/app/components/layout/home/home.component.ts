import { Component } from '@angular/core';
import { PostModel } from '../../../models/post.model';
import { HttpService } from '../../../services/http.service';
import { HttpErrorResponse } from '@angular/common/http';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { NgxPaginationModule } from 'ngx-pagination';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterLink, CommonModule, NgxPaginationModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  posts: PostModel[] = [];
  p: number = 1;

  constructor(private http: HttpService<PostModel>) {
    this.getAll();
  }

  getAll() {
    this.http.getAll('posts').subscribe({
      next: res => {
        this.posts = res;
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
      }
    })
  }
}
