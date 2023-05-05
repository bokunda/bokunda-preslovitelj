import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-translator-edit',
  templateUrl: './translator-edit.component.html',
  styleUrls: ['./translator-edit.component.scss']
})
export class TranslatorEditComponent {

  @Input() translatedText: string | undefined;
  @Output() submitForm: EventEmitter<FormGroup> = new EventEmitter<FormGroup>();

  public form: FormGroup = this.createForm();

  public submit(): void {
    this.submitForm.emit(this.form.value);
  }

  private createForm(): FormGroup {
    return new FormGroup({
      text: new FormControl('', [Validators.required]),
    });
  }

}
