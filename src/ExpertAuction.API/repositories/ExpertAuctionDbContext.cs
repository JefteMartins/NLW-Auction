using ExpertAuction.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpertAuction.API.repositories
{
    public class ExpertAuctionDbContext : DbContext
    {
        public ExpertAuctionDbContext(DbContextOptions<ExpertAuctionDbContext> options) : base(options) { }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}
