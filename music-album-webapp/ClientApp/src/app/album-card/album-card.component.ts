import {Component, Input, OnInit} from '@angular/core';
import {Album} from "../models/Album";
import {Router} from "@angular/router";
import {TrackService} from "../services/track.service";

@Component({
  selector: 'app-album-card',
  templateUrl: './album-card.component.html',
  styleUrls: ['./album-card.component.scss']
})
export class AlbumCardComponent implements OnInit {

  @Input()
  albums: Array<Album> = [];

  constructor(
    private router: Router,
    private trackService: TrackService,
  ) { }

  ngOnInit(): void {
    this.trackService.deleteTracks();
  }

  navigateToTrackList(id: number): void {
    // this.router.navigate([`tracks/${id}`], { state: { tracks: this.albums[id].tracks } });

    const currentAlbum = this.albums.find(a => a.id == id);
    if (currentAlbum !== null && currentAlbum !== undefined) {
      currentAlbum.tracks?.forEach((track: any) => {
        this.trackService.addTrack(track);
      });
    }

    this.router.navigate([`/tracks/${id}`]);
  }

}
