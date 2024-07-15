import { Component, ElementRef, ViewChild } from '@angular/core';
import { HttpService } from '../../../services/http.service';
import { SwalService } from '../../../services/swal.service';
import { SocialModel } from '../../../models/social.model';
import { HttpErrorResponse } from '@angular/common/http';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgxPaginationModule } from 'ngx-pagination';

@Component({
  selector: 'app-socials',
  standalone: true,
  imports: [FormsModule, CommonModule, NgxPaginationModule],
  templateUrl: './socials.component.html',
  styleUrl: './socials.component.css'
})
export class SocialsComponent {
  @ViewChild('createModalCloseBtn') createModalCloseBtn: | ElementRef<HTMLButtonElement> | undefined;
  @ViewChild('updateModalCloseBtn') updateModalCloseBtn: | ElementRef<HTMLButtonElement> | undefined;

  socials: SocialModel[] = [];

  createModel: SocialModel = new SocialModel();
  updateModel: SocialModel = new SocialModel();

  p: number = 1;

  constructor(private http: HttpService<any>, private swal: SwalService) {
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

  create(form: NgForm) {
    if (form.valid) {
      this.http.create('Socials', this.createModel).subscribe({
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

  delete(social: SocialModel) {
    this.swal.callSwal('Delete Social',
      'Are you sure you want to delete this social?', () => {
        this.http.delete('Socials', social.id).subscribe({
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

  get(social: SocialModel) {
    this.updateModel = { ...social };
  }

  update(form: NgForm) {
    if (form.valid) {
      this.http.update('Socials', this.updateModel).subscribe({
        next: res => {
          this.updateModalCloseBtn?.nativeElement.click();
          this.getAll();
          this.swal.callToast(res.message);
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);
        }
      })
    }
  }
}
