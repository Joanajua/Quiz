using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Quiz1.DataAccess.Models;
using Quiz1.DataAccess.ViewModels;

namespace Quiz1.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            // Conditional to migrate database when is not in testing
            //if (Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            //{
                Database.Migrate();
            //}
        }

        // For unit test a need to set these methods a virtual to overridethem
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    //    //seed authors
        //    //    modelBuilder.Entity<Author>().HasData(new Author { AuthorId = 1, AuthorName = "Shakespeare"});
        //    //    modelBuilder.Entity<Author>().HasData(new Author { AuthorId = 2, AuthorName = "Unamuno"});
        //    //    modelBuilder.Entity<Author>().HasData(new Author { AuthorId = 3, AuthorName = "Pier Lecarre"});

        //    //    //seed books

        //    //    modelBuilder.Entity<Book>().HasData(new Book
        //    //    {
        //    //        BookId = 1,
        //    //        Title = "The first book",
        //    //        ISBN = "1111111111",
        //    //        Genre = "Novel",
        //    //        TotalCopies = 2,
        //    //        AvailableCopies = 0,
        //    //        AuthorId = 1
        //    //    });

        //    //    modelBuilder.Entity<Book>().HasData(new Book
        //    //    {
        //    //        BookId = 2,
        //    //        Title = "The second book",
        //    //        ISBN = "2-222222-22-2",
        //    //        Genre = "History",
        //    //        TotalCopies = 1,
        //    //        AvailableCopies = 0,
        //    //        AuthorId = 2
        //    //    });

        //    //    modelBuilder.Entity<Book>().HasData(new Book
        //    //    {
        //    //        BookId = 3,
        //    //        Title = "The third book",
        //    //        ISBN = "9783161484100",
        //    //        Genre = "Drama",
        //    //        TotalCopies = 4,
        //    //        AvailableCopies = 0,
        //    //        AuthorId = 3
        //    //    });

        //    //    modelBuilder.Entity<Book>().HasData(new Book
        //    //    {
        //    //        BookId = 4,
        //    //        Title = "The first book",
        //    //        ISBN = "978-3-16-148410-0",
        //    //        Genre = "Novel",
        //    //        TotalCopies = 2,
        //    //        AvailableCopies = 0,
        //    //        AuthorId = 1
        //    //    });

        //    //    modelBuilder.Entity<Book>().HasData(new Book
        //    //    {
        //    //        BookId = 5,
        //    //        Title = "The fifth book",
        //    //        ISBN = "1888799972",
        //    //        Genre = "History",
        //    //        TotalCopies = 2,
        //    //        AvailableCopies = 0,
        //    //        AuthorId = 3
        //    //    });

        //    //    modelBuilder.Entity<Book>().HasData(new Book
        //    //    {
        //    //        BookId = 6,
        //    //        Title = "The fifth book",
        //    //        ISBN = "9793161484100",
        //    //        Genre = "History",
        //    //        TotalCopies = 2,
        //    //        AvailableCopies = 0,
        //    //        AuthorId = 3
        //    //    });

        //    //    modelBuilder.Entity<Book>().HasData(new Book
        //    //    {
        //    //        BookId = 7,
        //    //        Title = "The seventh book",
        //    //        ISBN = "978-3-16-148410-0",
        //    //        Genre = "Drama",
        //    //        TotalCopies = 4,
        //    //        AvailableCopies = 0,
        //    //        AuthorId = 3
        //    //    });

        //    //    modelBuilder.Entity<Book>().HasData(new Book
        //    //    {
        //    //        BookId = 8,
        //    //        Title = "The seventh book",
        //    //        ISBN = "978-3-16-148410-0",
        //    //        Genre = "Drama",
        //    //        TotalCopies = 4,
        //    //        AvailableCopies = 0,
        //    //        AuthorId = 3
        //    //    });

        //    //    modelBuilder.Entity<Book>().HasData(new Book
        //    //    {
        //    //        BookId = 9,
        //    //        Title = "The seventh book",
        //    //        ISBN = "979-3-16-148410-0",
        //    //        Genre = "Drama",
        //    //        TotalCopies = 4,
        //    //        AvailableCopies = 0,
        //    //        AuthorId = 3
        //    //    });

        //    //    modelBuilder.Entity<Book>().HasData(new Book
        //    //    {
        //    //        BookId = 10,
        //    //        Title = "The seventh book",
        //    //        ISBN = "979-3-16-148410-0",
        //    //        Genre = "Drama",
        //    //        TotalCopies = 4,
        //    //        AvailableCopies = 0,
        //    //        AuthorId = 3
        //    //    });
        //}
    }
}
