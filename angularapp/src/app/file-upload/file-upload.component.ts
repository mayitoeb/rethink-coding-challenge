import { Component } from '@angular/core';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'file-upload',
  templateUrl: './file-upload.component.html',
})
export class FileUploadComponent {

  uploadedFiles: any[] = [];

  constructor(private messageService: MessageService) { }

  onUpload(event: any) {
    for (let file of event.files) {
      this.uploadedFiles.push(file);
    }

    this.messageService.add({ severity: 'success', summary: 'File Uploaded', detail: '' });
  }

}
