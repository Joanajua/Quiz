using Quiz1.DataAccess.Models;

namespace Quiz1.DataAccess.ViewModels
{
    public class CreateViewModel
    {
        public Quiz Quiz { get; set; }
        public Question Question { get; set; }
        public Answer Author { get; set; }
    }
}
