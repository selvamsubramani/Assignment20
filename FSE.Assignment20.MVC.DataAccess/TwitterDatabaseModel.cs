namespace FSE.Assignment20.MVC.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TwitterDatabaseModel : DbContext
    {
        public TwitterDatabaseModel()
            : base("name=TwitterDatabaseModel")
        {
        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Tweet> Tweets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Tweets)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Followers)
                .WithMany(e => e.Following)
                .Map(m => m.ToTable("Following").MapLeftKey("UserId").MapRightKey("FollowingId"));

            modelBuilder.Entity<Tweet>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<Tweet>()
                .Property(e => e.Message)
                .IsUnicode(false);
        }
    }
}
