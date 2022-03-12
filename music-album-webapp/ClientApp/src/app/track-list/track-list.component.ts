import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {Track} from "../models/Track";
import {TrackService} from "../services/track.service";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-track-list',
  templateUrl: './track-list.component.html',
  styleUrls: ['./track-list.component.scss']
})
export class TrackListComponent implements OnInit {

  tracks: Array<Track> = [];
  id: number;

  constructor(
    private router: Router,
    private trackService: TrackService,
    private http: HttpClient,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    })

    this.tracks = this.trackService.getTracks();

    if (this.tracks.length <= 0) {
      this.getTracks();
    }

    this.tracks.forEach((element, index) => {
      let duration = this.tracks[index].duration !== null ? this.tracks[index].duration.toString() : '0';

      this.tracks[index].duration = this.secondsToTime(duration);
    });

    console.log(this.tracks);
  }

  secondsToTime(seconds: string): string {
    const sec = parseInt(seconds)

    const h = Math.floor(sec / 3600).toString().padStart(2,'0'),
      m = Math.floor(sec % 3600 / 60).toString().padStart(2,'0'),
      s = Math.floor(sec % 60).toString().padStart(2,'0');

    return h + ':' + m + ':' + s;
  }

  getTracks(): void {
    this.http.get(`https://localhost:5003/api/albums/tracks/${this.id}`, {
      responseType: "text",
      headers: {'Content-Type': 'application/json', 'charset': 'utf-8'}
    })
      .subscribe((data) => {
        const parsedData: Array<Track> = JSON.parse(data);
        parsedData.forEach(track => {

          const newTrack = new Track(
            track.id,
            track.author,
            track.title,
            track.releaseYear,
            track.duration
          );

          this.tracks.push(
            newTrack,
            newTrack,
            newTrack,
            newTrack,
          );
        })
      })
  }


}
