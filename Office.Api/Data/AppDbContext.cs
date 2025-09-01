using Microsoft.EntityFrameworkCore;
using Office.Api.Entities;

namespace Office.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // DbSets
    public DbSet<User> Users => Set<User>();
    public DbSet<ClientProfile> ClientProfiles => Set<ClientProfile>();
    public DbSet<LawyerProfile> LawyerProfiles => Set<LawyerProfile>();
    public DbSet<OfficeEntity> Offices => Set<OfficeEntity>();
    public DbSet<LegalRequest> LegalRequests => Set<LegalRequest>();
    public DbSet<RequestFile> RequestFiles => Set<RequestFile>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<AIChat> AIChats => Set<AIChat>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<Commission> Commissions => Set<Commission>();
    public DbSet<ActivityLog> ActivityLogs => Set<ActivityLog>();

    public override Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        var now = DateTime.UtcNow;
        foreach (var e in ChangeTracker.Entries<BaseEntity>())
        {
            if (e.State == EntityState.Added)
            {
                e.Entity.CreatedAt = now;
                e.Entity.UpdatedAt = now;
            }
            else if (e.State == EntityState.Modified)
            {
                e.Entity.UpdatedAt = now;
            }
        }
        return base.SaveChangesAsync(ct);
    }

    protected override void OnModelCreating(ModelBuilder b)
    {
        // Users
        b.Entity<User>()
            .HasIndex(u => u.Email).IsUnique();

        // One-to-one profiles
        b.Entity<ClientProfile>()
            .HasOne(cp => cp.User)
            .WithOne(u => u.ClientProfile)
            .HasForeignKey<ClientProfile>(cp => cp.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        b.Entity<LawyerProfile>()
            .HasOne(lp => lp.User)
            .WithOne(u => u.LawyerProfile)
            .HasForeignKey<LawyerProfile>(lp => lp.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Office owner
        b.Entity<OfficeEntity>()
            .HasOne(o => o.Owner)
            .WithOne(u => u.Office)
            .HasForeignKey<OfficeEntity>(o => o.OwnerUserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Lawyer belongs to office (optional)
        b.Entity<LawyerProfile>()
            .HasOne(lp => lp.Office)
            .WithMany(o => o.Lawyers)
            .HasForeignKey(lp => lp.OfficeId)
            .OnDelete(DeleteBehavior.SetNull);

        // Requests relations
        b.Entity<LegalRequest>()
            .HasOne(lr => lr.Client)
            .WithMany(u => u.ClientRequests)
            .HasForeignKey(lr => lr.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        b.Entity<LegalRequest>()
            .HasOne(lr => lr.Lawyer)
            .WithMany(u => u.LawyerRequests)
            .HasForeignKey(lr => lr.LawyerId)
            .OnDelete(DeleteBehavior.SetNull);

        b.Entity<LegalRequest>()
            .HasOne(lr => lr.Office)
            .WithMany(o => o.Requests)
            .HasForeignKey(lr => lr.OfficeId)
            .OnDelete(DeleteBehavior.SetNull);

        // Files, Chats, Payments cascade to request
        b.Entity<RequestFile>()
            .HasOne(rf => rf.Request)
            .WithMany(r => r.Files)
            .HasForeignKey(rf => rf.RequestId)
            .OnDelete(DeleteBehavior.Cascade);

        b.Entity<AIChat>()
            .HasOne(c => c.Request)
            .WithMany(r => r.Chats)
            .HasForeignKey(c => c.RequestId)
            .OnDelete(DeleteBehavior.Cascade);

        b.Entity<Payment>()
            .HasOne(p => p.Request)
            .WithMany(r => r.Payments)
            .HasForeignKey(p => p.RequestId)
            .OnDelete(DeleteBehavior.Cascade);

        // Commissions
        b.Entity<Commission>()
            .HasOne(c => c.Office)
            .WithMany(o => o.Commissions)
            .HasForeignKey(c => c.OfficeId)
            .OnDelete(DeleteBehavior.Cascade);

        b.Entity<Commission>()
            .HasOne(c => c.Lawyer)
            .WithMany(u => u.Commissions)
            .HasForeignKey(c => c.LawyerId)
            .OnDelete(DeleteBehavior.Restrict);

        b.Entity<Commission>()
            .HasOne(c => c.Request)
            .WithMany(r => r.Commissions)
            .HasForeignKey(c => c.RequestId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
