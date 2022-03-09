import {Component, Input, OnInit} from '@angular/core';
import {Album} from "../models/Album";

@Component({
  selector: 'app-album-card',
  templateUrl: './album-card.component.html',
  styleUrls: ['./album-card.component.scss']
})
export class AlbumCardComponent implements OnInit {

  @Input()
  albums: Array<Album> = [];

  constructor() { }

  ngOnInit(): void {
  }

}
