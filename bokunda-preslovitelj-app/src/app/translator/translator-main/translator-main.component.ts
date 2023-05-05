import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-translator-main',
  templateUrl: './translator-main.component.html',
  styleUrls: ['./translator-main.component.scss']
})
export class TranslatorMainComponent {
  translatedText: string | undefined;

  onSubmitForm(event: FormGroup): void {
    console.log(event);
  }
}
