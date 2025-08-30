import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DistanceComponent } from '../converters/distance.component';
import { WeightComponent } from '../converters/weight.component';
import { TemperatureComponent } from '../converters/temperature.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,CommonModule, DistanceComponent, WeightComponent, TemperatureComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('UnitConversorApp');
  selectedTab: string = 'distance';
}
