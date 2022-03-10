import { Component, OnInit } from '@angular/core';
import {Album} from "../models/Album";
import {Track} from "../models/Track";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  albums: Array<Album> = [];
  tracks: Array<Track> = [];

  constructor(
    private http: HttpClient,
  ) { }

  ngOnInit(): void {
    this.getAlbums();
  }

  getAlbums(): void {
    this.http.get("https://localhost:5003/api/albums", {
      responseType: "text",
      headers: {'Content-Type': 'application/json', 'charset': 'utf-8'}
    })
      .subscribe((data) => {
        const parsedData: Array<Album> = JSON.parse(data);
        parsedData.forEach(album => {

          album.tracks?.forEach(track => {
            this.tracks.push(
              new Track(
                track.id,
                track.title,
                track.author,
                track.releaseYear,
                track.duration,
              )
            );
          })

          const newAlbum = new Album(
            album.id,
            album.title,
            album.author,
            album.version,
            album.releaseYear,
            album.distributionName,
            this.tracks
          )

          this.albums.push(
            newAlbum,
            newAlbum,
            newAlbum,
            newAlbum,
            newAlbum,
            newAlbum,
            newAlbum,
            newAlbum,
            newAlbum,
          );

          this.tracks = [];
        })
      })
  }

}
