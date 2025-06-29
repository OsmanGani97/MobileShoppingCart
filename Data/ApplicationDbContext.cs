using DMobileSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DMobileSite.Data
{

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Mobile> Mobiles {  get; set; }
        public DbSet<Battery> Batterys {  get; set; }
        public DbSet<Brand> Brands {  get; set; }
        public DbSet<Camera> Cameras {  get; set; }
        public DbSet<CartDetail> CartDetails {  get; set; }
        public DbSet<Design> Designs {  get; set; }
        public DbSet<Display> Displays {  get; set; }
        public DbSet<General> Generals {  get; set; }
        //public DbSet<Hardware_SoftWare> Hardware_SoftWares {  get; set; }
        public DbSet<Memory> Memory {  get; set; }
        public DbSet<More> Mores {  get; set; }
        public DbSet<Multimedia> Multimedias {  get; set; }
        public DbSet<Network_Connectivity> Network_Connectivitys {  get; set; }
        public DbSet<Order> Orders {  get; set; }
        public DbSet<OrderDetail> OrderDetails {  get; set; }
        public DbSet<OrderStatus> OrderStatuss {  get; set; }
        public DbSet<Sensors_security> Sensors_securitys {  get; set; }
        public DbSet<ShoppingCart> ShoppingCarts {  get; set; }
        public DbSet<Stock> Stocks {  get; set; }
    }
}
