import { AppService } from './../app.service';
import { Component, OnInit } from '@angular/core';
import { Message } from '../message';

@Component({
  selector: 'app-browse',
  templateUrl: './browse.component.html',
  styleUrls: ['./browse.component.css']
})
export class BrowseComponent implements OnInit {

  public messages: Message[];

  constructor(private appService: AppService) { }

  ngOnInit(): void {
    this.refresh();
  }

  refresh(): void {
    this.appService.getMessages().subscribe((messages: Message[]) => { this.messages = messages; console.log(messages); });
  }

  goTo(message: Message): void {
    if (message.url == null) { return; }
    if (message.url === undefined) { return; }
    window.location.href = message.url;
  }

}
