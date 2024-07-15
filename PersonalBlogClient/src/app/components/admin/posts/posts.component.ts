import { Component, ElementRef, ViewChild } from '@angular/core';
import { HttpService } from '../../../services/http.service';
import { SwalService } from '../../../services/swal.service';
import { PostModel } from '../../../models/post.model';
import { HttpErrorResponse } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import {
  ClassicEditor,
  Bold,
  Essentials,
  Heading,
  Indent,
  IndentBlock,
  Italic,
  Link,
  List,
  MediaEmbed,
  Paragraph,
  Table,
  Undo
} from 'ckeditor5';
import 'ckeditor5/ckeditor5.css';
import { NgxPaginationModule } from 'ngx-pagination';


@Component({
  selector: 'app-posts',
  standalone: true,
  imports: [CommonModule, FormsModule, CKEditorModule, NgxPaginationModule],
  templateUrl: './posts.component.html',
  styleUrl: './posts.component.css'
})
export class PostsComponent {
  @ViewChild('createModalCloseBtn') createModalCloseBtn: | ElementRef<HTMLButtonElement> | undefined;
  @ViewChild('updateModalCloseBtn') updateModalCloseBtn: | ElementRef<HTMLButtonElement> | undefined;

  public Editor = ClassicEditor;
  public config = {
    toolbar: [
      'undo', 'redo', '|',
      'heading', '|', 'bold', 'italic', '|',
      'link', 'insertTable', 'mediaEmbed', '|',
      'bulletedList', 'numberedList', 'indent', 'outdent'
    ],
    plugins: [
      Bold,
      Essentials,
      Heading,
      Indent,
      IndentBlock,
      Italic,
      Link,
      List,
      MediaEmbed,
      Paragraph,
      Table,
      Undo,
    ]
  }

  posts: PostModel[] = [];

  createModel: PostModel = new PostModel();
  updateModel: PostModel = new PostModel();
  previewModel: PostModel = new PostModel();

  p: number = 1;

  constructor(private http: HttpService<any>, private swal: SwalService) {
    this.getAll();
  }

  getAll() {
    this.http.getAll('Posts').subscribe({
      next: res => {
        this.posts = res;
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
      }
    })
  }

  editCreatedPostUrl() {
    this.createModel.postUrl = this.createModel.title
      .toLowerCase()
      .replace(new RegExp(' ', 'g'), '-');
  }

  editUpdatedPostUrl() {
    this.updateModel.postUrl = this.updateModel.title
      .toLowerCase()
      .replace(new RegExp(' ', 'g'), '-');
  }

  setCreateImage(event: any) {
    this.createModel.image = event.target.files[0];
  }

  setUpdateImage(event: any) {
    this.updateModel.image = event.target.files[0];
  }

  create(form: NgForm) {
    if (form.valid) {
      const formData = new FormData();
      formData.append('title', this.createModel.title);
      formData.append('postUrl', this.createModel.postUrl);
      formData.append('description', this.createModel.description);
      formData.append('content', this.createModel.content);
      formData.append('image', this.createModel.image, this.createModel.image.name);

      this.http.create('Posts', formData).subscribe({
        next: (res) => {
          this.createModalCloseBtn?.nativeElement.click();
          this.getAll();
          this.swal.callToast(res.message);
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);
        }
      })
    }
  }

  delete(post: PostModel) {
    this.swal.callSwal('Delete Post',
      'Are you sure you want to delete this post?', () => {
        this.http.delete('Posts', post.id).subscribe({
          next: (res) => {
            this.getAll();
            this.swal.callToast(res.message);
          },
          error: (err: HttpErrorResponse) => {
            console.log(err);
          }
        })
      }
    )
  }

  preview(post: PostModel) {
    this.previewModel = { ...post };
  }

  get(post: PostModel) {
    this.updateModel = { ...post };
  }

  update(form: NgForm) {
    if (form.valid) {
      const formData = new FormData();
      formData.append('id', this.updateModel.id.toString());
      formData.append('title', this.updateModel.title);
      formData.append('postUrl', this.updateModel.postUrl);
      formData.append('description', this.updateModel.description);
      formData.append('content', this.updateModel.content);
      formData.append('image', this.updateModel.image, this.updateModel.image.name);

      this.http.update('Posts', formData).subscribe({
        next: res => {
          this.getAll();
          this.updateModalCloseBtn?.nativeElement.click();
          this.swal.callToast(res.message)
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);
        }
      })
    }
  }
}
