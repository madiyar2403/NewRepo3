﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecondDotNetApp.Models.Movies;

namespace SecondDotNetApp.Controllers
{
    public class MoviesController : Controller
    {
        static List<Movie> movies = new List<Movie>
    {
        new Movie { Author = "Todd Phillips", Genre = "Crime , Drama , Thriller", Name = "Joker",
            Poster = "https://www.kinopoisk.ru/images/film_big/1048334.jpg",
            CreatedAt = new DateTime(2019,10,3)
        },
        new Movie { Author = "David Leitch", Genre = "Action , Adventure", Name = "Fast & Furious Presents: Hobbs & Shaw",
            Poster = "https://www.eventsonglobe.com/wp-content/uploads/2019/11/Fast-Furious-Presents-Hobbs-and-Shaw-HD-1080p-Download.jpg",
            CreatedAt = new DateTime(2019,8,2)
        },
        new Movie { Author = "Jon Favreau", Genre = "Adventure , Animation , Drama , Family , Musical", Name = "The Lion King",
            Poster = "https://i0.wp.com/itc.ua/wp-content/uploads/2019/07/oblozhka-4.jpg?fit=1280%2C800&quality=100&strip=all&ssl=1",
            CreatedAt = new DateTime(2019,7,19)
        },
        new Movie { Author = "Joachim Rønning", Genre = "Adventure , Family , Fantasy", Name = "Maleficent: Mistress of Evil",
            Poster = "https://is1-ssl.mzstatic.com/image/thumb/Video123/v4/bb/82/fd/bb82fd41-0c5b-2380-7757-7246c9e48600/DIS_MAL2UAE_CENS_WW_WW_ARTWORK_EN_0x0_1YRWNX000000GS.lsr/268x0w.jpg",
            CreatedAt = new DateTime(2019,10,18)
        },
    };


        public IActionResult Index()
        {

            return View(movies);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Movie movie)
        {
            movies.Add(movie);

            return View("Index", movies);
        }
        public IActionResult Search(string text)
        {
            text = text.ToLower();
            var searchedMovies = movies.Where(movie => movie.Name.ToLower().Contains(text)
                                            || movie.Genre.ToLower().Contains(text)
                                            || movie.Author.ToLower().Contains(text))
                                        .ToList();
            return View("Index", searchedMovies);
        }
    }
}