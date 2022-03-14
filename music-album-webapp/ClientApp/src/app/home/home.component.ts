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
  currentPage: number = 1;
  paginationSize: number = 50;
  queryBody: string = `&CurrentPage=${this.currentPage}&PaginationSize=${this.paginationSize}`;
  totalPages: number = 1;
  totalItems: number = 0;
  allowedPaginationSize: Array<number> = [5, 10, 20, 50]
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
      .subscribe((data: any) => {
        data = JSON.parse(data);
        this.totalPages = data.totalPages;
        this.totalItems = data.totalItems;

        const parsedData: Array<Album> = data.items;
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

          this.albums.push(
            new Album(
            album.id,
            album.title,
            album.author,
            album.version,
            album.releaseYear,
            album.distributionName,
            this.tracks
          ));

          this.albumsWithoutFilters.push(...this.albums);

          this.tracks = [];

          if (album.releaseYear != null) {
            this.releaseYears.add(album.releaseYear);
          }

        })
      })
  }

  searchWithFilters(): void {
    this.queryBody = `searchPhrase=${this.searchPhrase}&sortBy=${this.sortBy}&SortDirection=${this.sortDirection}
    &ReleaseYear=${this.releaseYear == -1 ? '' : this.releaseYear}
    &CurrentPage=${this.currentPage}&PaginationSize=${this.paginationSize}`;
    this.albums = [];
    this.getAlbums();
  }

  changePagination(i: number) {
    this.paginationSize = i;
    this.searchWithFilters();
  }

  changePage(i: number) {
      if (i > 0 && i <= this.totalPages) {
        this.currentPage = i;
        this.albums = [];
        this.searchWithFilters();
      }
  }

}
