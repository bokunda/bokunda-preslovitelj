import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { TranslateTextCommand } from 'src/app/api/api-reference';
import { TranslationClient } from 'src/app/api/api-reference';

@Component({
  selector: 'app-translator-main',
  templateUrl: './translator-main.component.html',
  styleUrls: ['./translator-main.component.scss']
})
export class TranslatorMainComponent {
  translatedText: string | undefined;

  constructor(private translationClient: TranslationClient) { }

  onSubmitForm(form: FormGroup): void {
    console.log(form);
    this.translationClient.translate(form as unknown as TranslateTextCommand).subscribe(response => {
      console.log(response);
      this.translatedText = response.translatedText;
    });
  }
}
