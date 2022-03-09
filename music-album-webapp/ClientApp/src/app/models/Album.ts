import {Track} from "./Track";

export class Album {

  constructor(id: number, title: string, author: string, version: string | null, releaseYear: number | null, distributionName: string | null, tracks: Array<Track> | null) {
    this.id = id;
    this.title = title;
    this.author = author;
    this.version = version;
    this.releaseYear = releaseYear;
    this.distributionName = distributionName;
    this.tracks = tracks;
  }

  id: number;
  title: string;
  author: string;
  version: string | null;
  releaseYear: number | null;
  distributionName: string | null;
  tracks: Array<Track> | null;
}
