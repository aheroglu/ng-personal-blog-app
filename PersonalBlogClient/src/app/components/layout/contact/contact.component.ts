import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { HttpService } from '../../../services/http.service';
import { MessageModel } from '../../../models/message.model';
import { SwalService } from '../../../services/swal.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.css'
})
export class ContactComponent {
  message: MessageModel = new MessageModel();

  constructor(private http: HttpService<MessageModel>, private swal: SwalService, private router: Router) { }

  send(form: NgForm) {
    if (form.valid) {
      this.http.create('Messages', this.message).subscribe({
        next: () => {
          form.resetForm();
          this.router.navigateByUrl('/');
          this.swal.callToast('Message sent');
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);
        }
      })
    }
  }
}
