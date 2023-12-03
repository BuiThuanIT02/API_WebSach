using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API_WebSach.Models
{
    public partial class NxbKimDongContext : DbContext
    {
        public NxbKimDongContext()
        {
        }

        public NxbKimDongContext(DbContextOptions<NxbKimDongContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<DanhMucSp> DanhMucSps { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<Silde> Sildes { get; set; }
        public virtual DbSet<TacGium> TacGia { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThamGium> ThamGia { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q71BODV\\THUAN;Initial Catalog=NxbKimDong;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.HasKey(e => new { e.MaDonHang, e.MaSach });

                entity.ToTable("ChiTietDonHang");

                entity.HasOne(d => d.MaDonHangNavigation)
                    .WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.MaDonHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietDonHang_DonHang");

                entity.HasOne(d => d.MaSachNavigation)
                    .WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.MaSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietDonHang_Sach");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Credential>(entity =>
            {
                entity.HasKey(e => new { e.UserGroupId, e.RoleId })
                    .HasName("PK_Credential");

                entity.Property(e => e.UserGroupId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UserGroupID");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RoleID");
            });

            modelBuilder.Entity<DanhMucSp>(entity =>
            {
                entity.ToTable("DanhMucSP");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(80);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.ToTable("DonHang");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.Moblie)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NgayDat).HasColumnType("datetime");

                entity.Property(e => e.NgayGiao).HasColumnType("datetime");

                entity.Property(e => e.TenKh)
                    .HasMaxLength(50)
                    .HasColumnName("TenKH");

                entity.Property(e => e.TongTien).HasColumnType("money");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("FK_DonHang_TaiKhoan");
            });

            modelBuilder.Entity<FeedBack>(entity =>
            {
                entity.ToTable("FeedBack");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Content).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.ToTable("NhaCungCap");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<NhaXuatBan>(entity =>
            {
                entity.ToTable("NhaXuatBan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenNxb)
                    .HasMaxLength(50)
                    .HasColumnName("TenNXB");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.ToTable("Sach");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DanhMucId).HasColumnName("DanhMucID");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.KichThuoc).HasMaxLength(50);

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MoreImages).HasColumnType("xml");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");

                entity.Property(e => e.NhaCungCapId).HasColumnName("NhaCungCapID");

                entity.Property(e => e.NhaXuatBanId).HasColumnName("NhaXuatBanID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TopHot).HasColumnType("datetime");

                entity.Property(e => e.TrongLuong).HasMaxLength(10);

                entity.Property(e => e.ViewCount).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.DanhMuc)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.DanhMucId)
                    .HasConstraintName("FK_Sach_DanhMucSP");

                entity.HasOne(d => d.NhaCungCap)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.NhaCungCapId)
                    .HasConstraintName("FK_Sach_NhaCungCap");

                entity.HasOne(d => d.NhaXuatBan)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.NhaXuatBanId)
                    .HasConstraintName("FK_Sach_NhaXuatBan");
            });

            modelBuilder.Entity<Silde>(entity =>
            {
                entity.ToTable("Silde");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Link).HasMaxLength(250);
            });

            modelBuilder.Entity<TacGium>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenTacGia).HasMaxLength(50);
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.ToTable("TaiKhoan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.GioiTinh).HasMaxLength(3);

                entity.Property(e => e.GroupId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GroupID")
                    .HasDefaultValueSql("('MEMBER')");

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaiKhoan1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TaiKhoan");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_TaiKhoan_UserGroup");
            });

            modelBuilder.Entity<ThamGium>(entity =>
            {
                entity.HasKey(e => new { e.MaSach, e.MaTacGia });

                entity.Property(e => e.VaiTro).HasMaxLength(50);

                entity.Property(e => e.Vitri).HasMaxLength(50);

                entity.HasOne(d => d.MaSachNavigation)
                    .WithMany(p => p.ThamGia)
                    .HasForeignKey(d => d.MaSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThamGia_Sach");

                entity.HasOne(d => d.MaTacGiaNavigation)
                    .WithMany(p => p.ThamGia)
                    .HasForeignKey(d => d.MaTacGia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThamGia_TacGia");
            });

            modelBuilder.Entity<TinTuc>(entity =>
            {
                entity.ToTable("Tin_Tuc");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.ToTable("UserGroup");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
