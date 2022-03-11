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
  albumsWithoutFilters: Array<Album> = [];
  tracks: Array<Track> = [];
  releaseYears: Set<number> = new Set<number>();
  searchPhrase: string = "";
  queryBody: string = "";
  sortBy: string = "ReleaseYear";
  sortDirection: number | null = 0;
  releaseYear: number | null = -1;

  constructor(
    private http: HttpClient,
  ) { }

  ngOnInit(): void {
    this.getAlbums();
  }

  getAlbums(): void {
    this.http.get(`https://localhost:5003/api/albums?${this.queryBody}`, {
      responseType: "text",
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

          this.albumsWithoutFilters.push(...this.albums);

          this.tracks = [];

          if (album.releaseYear != null) {
            this.releaseYears.add(album.releaseYear);
          }

        })
      })
  }

  search(): void {
    this.queryBody = `searchPhrase=${this.searchPhrase}&sortBy=${this.sortBy}&SortDirection=${this.sortDirection}&ReleaseYear=${this.releaseYear == -1 ? '' : this.releaseYear}`;
    this.albums = [];
    this.getAlbums();
  }

}
