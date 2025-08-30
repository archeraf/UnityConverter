import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ConversorService } from '../services/ConversorService';


@Component({
  selector: 'app-distance',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './distance.component.html'
})
export class DistanceComponent {
  
  value: number = 0;
  fromUnit: string = 'meter (m)';
  toUnit: string = 'kilometer (km)';
  result: string = '';

  units: { [key: string]: number } = {
    'meter (m)': 1,
    'kilometer (km)': 1000,
    'mile (mi)': 1609.34,
    'yard (yd)': 0.9144
  };

  constructor(private ConversorService: ConversorService) {}

  get unitKeys(): string[] {
    return Object.keys(this.units);
  }

  convert() {
    debugger
    if (isNaN(this.value)) {
      this.result = 'Please enter a valid number';
      return;
    }
    const inMeters = this.value * this.units[this.fromUnit];
    const out = inMeters / this.units[this.toUnit];
    this.ConversorService.convert(1, this.units[this.fromUnit], this.units[this.toUnit]).subscribe({
      next: (value:any) => {
        this.result = `${this.value} ${this.fromUnit} = ${value} ${this.toUnit}`;
      },
      error: (err:any) => {
        this.result = 'Error occurred during conversion';
      }
    });
  }
}
