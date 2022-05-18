using BackEnd_Travelity.Domain;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Travelity.Environment
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Reminder> Reminder { get; set; }
        public DbSet<Friend> Friend { get; set; }
        public DbSet<FriendRequest> FriendRequest { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Explorer> Explorer { get; set; }
        public DbSet<MostVisited> MostVisited { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<AVBudget> AVBudget { get; set; }
        public DbSet<Budget> Budget { get; set; }
        public DbSet<BudgetReport> BudgetReport { get; set; }
        public DbSet<Coupon> Coupon { get; set; }
        public DbSet<Likes> Likes { get; set; }
    }
}
