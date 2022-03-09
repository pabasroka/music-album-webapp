export class Track {

  constructor(id: number, title: string, author: string, releaseYear: number | null, duration: number | null) {
    this.id = id;
    this.title = title;
    this.author = author;
    this.releaseYear = releaseYear;
    this.duration = duration;
  }

  id: number;
  title: string;
  author: string;
  releaseYear: number | null;
  duration: number | null;
}
