import { Component, EventEmitter, Output } from '@angular/core';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'file-upload',
  templateUrl: './file-upload.component.html',
})
export class FileUploadComponent {

  uploadedFile: any;
  @Output() uploadedFileEvent = new EventEmitter();

  constructor(private messageService: MessageService) { }

  onUpload(event: any) {
    this.uploadedFile = event.files[0];

    this.messageService.add({ severity: 'success', summary: 'File Uploaded', detail: '' });
    this.uploadedFileEvent.emit(null)
  }

  onError(event: any) {
    this.uploadedFile = null;
    this.messageService.add({ severity: 'error', summary: 'Error uploading the file.', detail: '' });
  }

}
