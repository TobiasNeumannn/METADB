﻿using METADB.Areas.Identity.Data;
using METADB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace METADB.Areas.Identity.Data;

public class METAContext : IdentityDbContext<METAUser>
{
    public METAContext(DbContextOptions<METAContext> options)
        : base(options)
    {
    }

    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<Posts> Posts { get; set; }
    public DbSet<Reports> Reports { get; set; }
    public DbSet<Likes> Likes { get; set; }
    public DbSet<Comments> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityUser>()
            .HasMany(u => u.Posts)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserID)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<IdentityUser>()
            .HasMany(u => u.Comments)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserID);

        modelBuilder.Entity<IdentityUser>()
            .HasMany(u => u.Likes)
            .WithOne(l => l.User)
            .HasForeignKey(l => l.UserID);

        modelBuilder.Entity<IdentityUser>()
            .HasMany(u => u.Reports)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserID);

        modelBuilder.Entity<Posts>()
            .HasMany(p => p.Likes)
            .WithOne(l => l.Post)
            .HasForeignKey(l => l.PostsID);

        modelBuilder.Entity<Posts>()
            .HasMany(p => p.Reports)
            .WithOne(r => r.Post)
            .HasForeignKey(r => r.PostsID);

        modelBuilder.Entity<Posts>()
            .HasMany(p => p.Comments)
            .WithOne(c => c.Post)
            .HasForeignKey(c => c.PostsID)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Comments>()
            .HasMany(c => c.Likes)
            .WithOne(l => l.Comment)
            .HasForeignKey(l => l.CommentsID);

        modelBuilder.Entity<Comments>()
            .HasMany(c => c.Reports)
            .WithOne(r => r.Comment)
            .HasForeignKey(r => r.CommentsID);

    }
}
