import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { HttpService } from '../../../services/http.service';
import { PostModel } from '../../../models/post.model';
import { HttpErrorResponse, HttpHeaderResponse } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-post-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './post-detail.component.html',
  styleUrl: './post-detail.component.css'
})
export class PostDetailComponent implements OnInit {
  postUrl: any | undefined;
  post: PostModel | undefined;

  constructor(private activatedRoute: ActivatedRoute, private http: HttpService<PostModel>) { }

  ngOnInit(): void {
    this, this.activatedRoute.paramMap.subscribe({
      next: params => {
        this.postUrl = params.get('postUrl')

        if (this.postUrl) {
          this.get();
        }
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
      }
    })
  }

  get() {
    this.http.getByUrl('Posts', this.postUrl).subscribe({
      next: res => {
        this.post = res;
      },
      error: (err: HttpHeaderResponse) => {
        console.log(err);
      }
    })
  }
}
