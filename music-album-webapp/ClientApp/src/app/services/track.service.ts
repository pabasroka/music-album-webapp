import { Injectable } from '@angular/core';
import { Track } from "../models/Track";

@Injectable({
  providedIn: 'root'
})
export class TrackService {

  private tracks: Array<Track> = [];

  addTrack(track: Track) {
    this.tracks.push(track);
  }

  getTracks(): Array<Track> {
    return this.tracks;
  }

  deleteTracks(): void {
    this.tracks = [];
  }

  constructor() { }
}
