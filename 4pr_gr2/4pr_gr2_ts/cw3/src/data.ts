export const colors = ["white", "red", "green", "blue", "yellow", "orange", "purple"];

export type Movie = {
    title: string;
    year: number;
    genre: string;
    director: string;
}
export const movies: Movie[] = [
    {
        title: "Inception",
        year: 2010,
        genre: "Sci-Fi",
        director: "Christopher Nolan"
    },
    {
        title: "The Shawshank Redemption",
        year: 1994,
        genre: "Drama",
        director: "Frank Darabont"
    },
    {
        title: "Pulp Fiction",
        year: 1994,
        genre: "Crime",
        director: "Quentin Tarantino"
    },
    {
        title: "The Dark Knight",
        year: 2008,
        genre: "Action",
        director: "Christopher Nolan"
    },
    {
        title: "Forrest Gump",
        year: 1994,
        genre: "Drama",
        director: "Robert Zemeckis"
    },
    {
        title: "The Matrix",
        year: 1999,
        genre: "Sci-Fi",
        director: "Lana and Lilly Wachowski"
    },
    {
        title: "Interstellar",
        year: 2014,
        genre: "Sci-Fi",
        director: "Christopher Nolan"
    },
    {
        title: "The Godfather",
        year: 1972,
        genre: "Crime",
        director: "Francis Ford Coppola"
    },
    {
        title: "Fight Club",
        year: 1999,
        genre: "Drama",
        director: "David Fincher"
    },
    {
        title: "Spirited Away",
        year: 2001,
        genre: "Animation",
        director: "Hayao Miyazaki"
    }
]