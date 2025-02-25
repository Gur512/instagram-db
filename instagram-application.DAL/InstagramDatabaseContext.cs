using System;
using System.Collections.Generic;
using instagram_application.Models;
using Microsoft.EntityFrameworkCore;

namespace instagram_application.DAL;

public partial class InstagramDatabaseContext : DbContext
{
    public InstagramDatabaseContext()
    {
    }

    public InstagramDatabaseContext(DbContextOptions<InstagramDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<DirectMessage> DirectMessages { get; set; }

    public virtual DbSet<Follow> Follows { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Story> Stories { get; set; }

    public virtual DbSet<Storyview> Storyviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-MT5SGMN\\SQLEXPRESS;Database=InstagramDatabase;Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comment__C3B4DFAAAA96D215");

            entity.ToTable("Comment");

            entity.Property(e => e.CommentId)
                .ValueGeneratedNever()
                .HasColumnName("CommentID");
            entity.Property(e => e.CommentText).HasColumnType("text");
            entity.Property(e => e.PostId)
                .HasMaxLength(50)
                .HasColumnName("PostID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__Comment__PostID__45F365D3");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Comment__UserID__44FF419A");
        });

        modelBuilder.Entity<DirectMessage>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__DirectMe__C87C037C91BB24C4");

            entity.ToTable("DirectMessage");

            entity.Property(e => e.MessageId)
                .ValueGeneratedNever()
                .HasColumnName("MessageID");
            entity.Property(e => e.ReceiverUserId).HasColumnName("ReceiverUserID");
            entity.Property(e => e.SenderUserId).HasColumnName("SenderUserID");
            entity.Property(e => e.SentAt)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.TextMessage).HasColumnType("text");

            entity.HasOne(d => d.ReceiverUser).WithMany(p => p.DirectMessageReceiverUsers)
                .HasForeignKey(d => d.ReceiverUserId)
                .HasConstraintName("FK__DirectMes__Recei__49C3F6B7");

            entity.HasOne(d => d.SenderUser).WithMany(p => p.DirectMessageSenderUsers)
                .HasForeignKey(d => d.SenderUserId)
                .HasConstraintName("FK__DirectMes__Sende__48CFD27E");
        });

        modelBuilder.Entity<Follow>(entity =>
        {
            entity.HasKey(e => e.FollowId).HasName("PK__Follow__2CE8108E9567DF39");

            entity.ToTable("Follow");

            entity.Property(e => e.FollowId)
                .ValueGeneratedNever()
                .HasColumnName("FollowID");
            entity.Property(e => e.FollowerUserId).HasColumnName("FollowerUserID");
            entity.Property(e => e.FollowingUserId).HasColumnName("FollowingUserID");

            entity.HasOne(d => d.FollowerUser).WithMany(p => p.FollowFollowerUsers)
                .HasForeignKey(d => d.FollowerUserId)
                .HasConstraintName("FK__Follow__Follower__3A81B327");

            entity.HasOne(d => d.FollowingUser).WithMany(p => p.FollowFollowingUsers)
                .HasForeignKey(d => d.FollowingUserId)
                .HasConstraintName("FK__Follow__Followin__3B75D760");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__Image__7516F4ECD509C1DF");

            entity.ToTable("Image");

            entity.Property(e => e.ImageId)
                .ValueGeneratedNever()
                .HasColumnName("ImageID");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("ImageURL");
            entity.Property(e => e.PostId)
                .HasMaxLength(50)
                .HasColumnName("PostID");
            entity.Property(e => e.UploadedAt)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Post).WithMany(p => p.Images)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__Image__PostID__5441852A");

            entity.HasOne(d => d.User).WithMany(p => p.Images)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Image__UserID__534D60F1");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.LikeId).HasName("PK___Like__A2922CF49E64C573");

            entity.ToTable("_Like");

            entity.Property(e => e.LikeId)
                .ValueGeneratedNever()
                .HasColumnName("LikeID");
            entity.Property(e => e.PostId)
                .HasMaxLength(50)
                .HasColumnName("PostID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Post).WithMany(p => p.Likes)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK___Like__PostID__412EB0B6");

            entity.HasOne(d => d.User).WithMany(p => p.Likes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK___Like__UserID__4222D4EF");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Post__AA12603809A1C1E3");

            entity.ToTable("Post");

            entity.Property(e => e.PostId)
                .HasMaxLength(50)
                .HasColumnName("PostID");
            entity.Property(e => e.Caption).HasColumnType("text");
            entity.Property(e => e.Createdat)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Post__UserID__3E52440B");
        });

        modelBuilder.Entity<Story>(entity =>
        {
            entity.HasKey(e => e.StoryId).HasName("PK__Story__3E82C0285217D49D");

            entity.ToTable("Story", tb => tb.HasTrigger("Story_Expiration"));

            entity.Property(e => e.StoryId)
                .ValueGeneratedNever()
                .HasColumnName("StoryID");
            entity.Property(e => e.Caption).HasColumnType("text");
            entity.Property(e => e.ExpirationTime).HasColumnType("datetime");
            entity.Property(e => e.UploadedAt)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Stories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Story__UserID__4CA06362");
        });

        modelBuilder.Entity<Storyview>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Storyview");

            entity.Property(e => e.StoryId).HasColumnName("StoryID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.ViewedAt)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Story).WithMany()
                .HasForeignKey(d => d.StoryId)
                .HasConstraintName("FK__Storyview__Story__5070F446");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Storyview__UserI__4F7CD00D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User___1788CCACFC69C04D");

            entity.ToTable("User_");

            entity.HasIndex(e => e.Email, "UQ__User___A9D10534AB6B9A9B").IsUnique();

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Bio).HasColumnType("text");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.ProfilePicture).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
