import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConversorService {

  private baseUrl = 'https://localhost:44361';

  constructor(private http: HttpClient) {}


  //Unity converter
  public convert(unitType:number, fromUnit:number,toUnit:number): Observable<any> {
    return this.http.get(`${this.baseUrl}/api/Conversion/v1/convert/${unitType}/${fromUnit}/${toUnit}`);
  }
  

}
