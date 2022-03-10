export class Track {

  constructor(id: number, title: string, author: string, releaseYear: string | null, duration: string | null) {
    this.id = id;
    this.title = title;
    this.author = author;
    this.releaseYear = releaseYear;
    this.duration = duration;
  }

  id: number;
  title: string;
  author: string;
  releaseYear: string | null;
  duration: string | null;
}
