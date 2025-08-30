import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-weight',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './weight.component.html'
})
export class WeightComponent {
  value: number = 0;
  fromUnit: string = 'kilogram (kg)';
  toUnit: string = 'pound (lb)';
  result: string = '';

  units: { [key: string]: number } = {
    'kilogram (kg)': 1,
    'gram (g)': 0.001,
    'pound (lb)': 0.453592,
    'ounce (oz)': 0.0283495
  };

  get unitKeys(): string[] {
    return Object.keys(this.units);
  }

  convert() {
    if (isNaN(this.value)) {
      this.result = 'Please enter a valid number';
      return;
    }
    const inKg = this.value * this.units[this.fromUnit];
    const out = inKg / this.units[this.toUnit];
    this.result = `${this.value} ${this.fromUnit} = ${out.toFixed(4)} ${this.toUnit}`;
  }
}
