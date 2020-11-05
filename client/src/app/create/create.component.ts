import { AppService } from './../app.service';
import { Component, OnInit } from '@angular/core';
import { Message } from '../message';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  public title = 'client';
  public content: string;

  constructor(private appService: AppService) { }

  ngOnInit(): void {
  }

  submit(): void {
    if (this.content === undefined) { return; }
    const message = new Message();
    message.content = this.content;
    this.appService.postMessage(message).subscribe(res => { });
  }

}
