using Quiz1.Models;

namespace Quiz1.ViewModels
{
    public class CreateViewModel
    {
        public Quiz Quiz { get; set; }
        public Question Question { get; set; }
        public Answer Author { get; set; }
    }
}
