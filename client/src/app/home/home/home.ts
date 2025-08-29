import { Component} from '@angular/core';

@Component({
  selector: 'app-home',
  template: `
    <input type="text" #myInput placeholder="Type something" (input)="onInput(myInput.value)" />
    <button (click)="submitInput()">Submit</button>
    <p>You typed: {{ value }}</p>
  `,
  // Inline styles
  styles: []
})
export class Home {
    value: string = '';

  // Updates value as the user types
  onInput(val: string) {
    this.value = val;
  }

  // Called when button is clicked
  submitInput() {
    console.log('User typed:', this.value);
    alert(`You typed: ${this.value}`);
  }
}
