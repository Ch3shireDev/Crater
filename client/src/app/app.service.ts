import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Message } from './message';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor(private httpClient: HttpClient) { }

  public getMessages(): Observable<Message[]> {
    return this.httpClient.get<Message[]>(`/api/messages`);
  }

  public postMessage(message: Message): Observable<Message> {
    console.log(message);
    return this.httpClient.post<Message>(`/api/messages`, message);
  }
}
