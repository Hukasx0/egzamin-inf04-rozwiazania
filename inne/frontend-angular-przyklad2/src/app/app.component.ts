import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  kursy: string[] = [
    "Programowanie w C#",
    "Angular dla początkujących",
    "Kurs Django"
  ];

  formularz = {
    imieNazwisko: '',
    numerKursu: null
  };

  pokazPodziekowanie = false;

  onSubmit() {
    if (this.formularz.numerKursu && this.formularz.numerKursu > 0 && this.formularz.numerKursu <= this.kursy.length) {
      console.log(this.formularz.imieNazwisko);
      console.log(this.kursy[this.formularz.numerKursu - 1]);
      this.pokazPodziekowanie = true;
    }
    else {
      console.log(this.formularz.imieNazwisko);
      console.log("Nieprawidłowy numer kursu");
      this.pokazPodziekowanie = false;
    }
  }
}
