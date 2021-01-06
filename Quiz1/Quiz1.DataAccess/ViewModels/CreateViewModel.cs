using System;
using System.Collections.Generic;
using System.Text;
using Quiz1.DataAccess.Models;

namespace Quiz1.DataAccess.ViewModels
{
    public class CreateViewModel
    {
        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
