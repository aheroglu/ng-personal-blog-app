import { CommonModule } from '@angular/common';
import { Component, ElementRef, ViewChild } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { AboutModel } from '../../../models/about.model';
import { HttpService } from '../../../services/http.service';
import { SwalService } from '../../../services/swal.service';
import { HttpErrorResponse } from '@angular/common/http';
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

@Component({
  selector: 'app-about',
  standalone: true,
  imports: [FormsModule, CommonModule, CKEditorModule],
  templateUrl: './about.component.html',
  styleUrl: './about.component.css'
})
export class AdminAboutComponent {
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

  about: AboutModel | undefined;

  updateModel: AboutModel = new AboutModel();

  constructor(private http: HttpService<any>, private swal: SwalService) {
    this.getAll();
  }

  getAll() {
    this.http.getAll('Abouts').subscribe({
      next: res => {
        this.about = res[0];
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
      }
    })
  }

  get(about: AboutModel) {
    this.updateModel = { ...about };
  }

  update(form: NgForm) {
    if (form.valid) {
      const formData = new FormData();
      formData.append('id', this.updateModel.id.toString());
      formData.append('content', this.updateModel.content);

      this.http.update('Abouts', formData).subscribe({
        next: res => {
          this.getAll();
          this.updateModalCloseBtn?.nativeElement.click();
          this.swal.callToast(res.message);
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);
        }
      })
    }
  }
}
