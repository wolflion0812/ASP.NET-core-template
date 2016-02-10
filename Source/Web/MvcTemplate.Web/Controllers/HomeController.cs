﻿namespace MvcTemplate.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using MvcTemplate.Data;
    using MvcTemplate.Data.Models;
    using Data.Common;
    using ViewModels.Home;
    using Infrastructure.Mapping;
    public class HomeController : Controller
    {
        private IDbRepository<Joke> jokes;
        private IDbRepository<JokeCategory> jokeCategories;

        public HomeController(
            IDbRepository<Joke> jokes,
            IDbRepository<JokeCategory> jokeCategories)
        {
            this.jokes = jokes;
            this.jokeCategories = jokeCategories;
        }

        public ActionResult Index()
        {
            var jokes = this.jokes.All()
                .OrderBy(x => Guid.NewGuid()).Take(3)
                .To<JokeViewModel>().ToList();
            return this.View(jokes);
        }
    }
}
