import { Tools } from './../tools';
import { ThumbnailData } from './../thumbnail-data';
import { AppService } from './../app.service';
import { Component, OnInit } from '@angular/core';
import { Message } from '../message';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  public message = new Message();
  public imageStr: string;

  constructor(private appService: AppService, private router: Router) { }

  ngOnInit(): void {
  }

  submit(): void {
    if (this.message.content === undefined) { return; }
    if (this.message.title === undefined) { return; }
    if (this.message.url === undefined) { return; }
    this.appService.postMessage(this.message).subscribe(res => {
      this.router.navigateByUrl('/');
    });
  }

  change(event: any): void {
    if (this.message.url === undefined) { return; }
    if (this.message.url === null) { return; }
    if (!this.message.url.startsWith('http')) { return; }
    this.appService.getThumbnail(this.message.url).subscribe((thumbnail: ThumbnailData) => {
      this.message.title = Tools.decode(thumbnail.title);
      this.message.content = Tools.decode(thumbnail.description);
      this.imageStr = thumbnail.thumbnail;
    });
  }


}
