using System;
using System.Collections.Generic;
using System.Text;
using Quiz1.DataAccess.Models;

namespace Quiz1.DataAccess.ViewModels
{
    public class CreateViewModel
    {
        public Quiz Book { get; set; }
        public Question Question { get; set; }
        public Answer Author { get; set; }
    }
}
