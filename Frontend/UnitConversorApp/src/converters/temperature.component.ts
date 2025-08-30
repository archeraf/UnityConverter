import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-temperature',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './temperature.component.html'
})
export class TemperatureComponent {
  value: number = 0;
  fromUnit: string = 'Celsius (C)';
  toUnit: string = 'Fahrenheit (F)';
  result: string = '';

  units: string[] = ['Celsius (C)', 'Fahrenheit (F)', 'Kelvin (K)'];

  convert() {
    let val = this.value;

    let inCelsius: number;
    if (this.fromUnit.includes('C')) inCelsius = val;
    else if (this.fromUnit.includes('F')) inCelsius = (val - 32) * 5/9;
    else inCelsius = val - 273.15;

    let out: number;
    if (this.toUnit.includes('C')) out = inCelsius;
    else if (this.toUnit.includes('F')) out = (inCelsius * 9/5) + 32;
    else out = inCelsius + 273.15;

    this.result = `${this.value} ${this.fromUnit} = ${out.toFixed(2)} ${this.toUnit}`;
  }
}
