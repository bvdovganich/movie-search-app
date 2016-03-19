using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieService.Classes.Models;

namespace MovieService
{
    public interface IMovieService
    {
        MovieData UseWebClient(string title);
    }
}
