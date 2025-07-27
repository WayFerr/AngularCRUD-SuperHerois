import { Heroi, Superpoder } from './../models/heroi.model';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpOptionsType} from '../../app/types/HttpOptionsType';

@Injectable({
  providedIn: 'root'
})
export class HeroiService {
  private readonly _baseUrl: string = 'https://localhost:7105/api';
  private readonly _jsonHttpHeaders: HttpHeaders = new HttpHeaders({'Content-Type': 'application/json'})

  constructor(private httpClient: HttpClient) { }

  public obterHerois(): Observable<Array<Heroi>>{
    const url: string = `${this._baseUrl}/Herois`;

    const httpOptions: HttpOptionsType = {
      headers: this._jsonHttpHeaders
    }

    return this.httpClient.get<Array<Heroi>>(url, httpOptions)
  }

  public obterSuperpoderes(): Observable<Array<Superpoder>>{
    const url: string = `${this._baseUrl}/Herois/Superpoderes`;

    const httpOptions: HttpOptionsType = {
      headers: this._jsonHttpHeaders
    }

    return this.httpClient.get<Array<Superpoder>>(url, httpOptions)
  }

  public incluirHeroi(heroi: any): Observable<Heroi>
  {
    const url: string = `${this._baseUrl}/Herois`;

    const httpOptions: HttpOptionsType = {
      headers: this._jsonHttpHeaders
    }

    return this.httpClient.post<Heroi>(url, heroi, httpOptions)
  }

  public deletarHeroi(id: number): Observable<void> {
  const url = `${this._baseUrl}/Herois/${id}`;
  const httpOptions: HttpOptionsType = {
    headers: this._jsonHttpHeaders
  };
  return this.httpClient.delete<void>(url, httpOptions);
}

  public alterarHeroi(id: number, request: any): Observable<Heroi> {
  const url: string = `${this._baseUrl}/Herois/${id}`;
  const httpOptions: HttpOptionsType = {
    headers: this._jsonHttpHeaders
  };

  return this.httpClient.put<Heroi>(url, request, httpOptions);
}

}
