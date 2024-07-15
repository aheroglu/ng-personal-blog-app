import { Component, ElementRef, ViewChild } from '@angular/core';
import { MessageModel } from '../../../models/message.model';
import { HttpService } from '../../../services/http.service';
import { SwalService } from '../../../services/swal.service';
import { HttpErrorResponse } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';

@Component({
  selector: 'app-messages',
  standalone: true,
  imports: [CommonModule, FormsModule, NgxPaginationModule],
  templateUrl: './messages.component.html',
  styleUrl: './messages.component.css'
})
export class MessagesComponent {
  @ViewChild('getModalCloseBtn') getModalCloseBtn: | ElementRef<HTMLButtonElement> | undefined;

  messages: MessageModel[] = [];

  getMessage: MessageModel = new MessageModel();

  p: number = 1;

  constructor(private http: HttpService<any>, private swal: SwalService) {
    this.getAll();
  }

  getAll() {
    this.http.getAll('Messages').subscribe({
      next: res => {
        this.messages = res;
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
      }
    })
  }

  get(message: MessageModel) {
    this.getMessage = { ...message };
  }

  delete(message: MessageModel) {
    this.swal.callSwal('Delete Message',
      'Are you sure you want to delete this message?', () => {
        this.http.delete('Messages', message.id).subscribe({
          next: (res) => {
            this.getModalCloseBtn?.nativeElement.click();
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

}
