using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Library_System.Models;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<StocksBalance> StocksBalances { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionType> TransactionTypes { get; set; }

    public virtual DbSet<TransactionsItem> TransactionsItems { get; set; }

    public virtual DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<UsersRole> UsersRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Library;User ID=sa;Password=12345;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2B7113663B");

            entity.HasIndex(e => e.CategoryName, "UQ__Categori__8517B2E047CE84E2").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .HasColumnName("Category_Name");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ParentCategoryId).HasColumnName("Parent_Category_ID");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8358DA613");

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D1053443FF419A").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CommercialRegister)
                .HasMaxLength(50)
                .HasColumnName("commercial_register");
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .HasColumnName("Customer_Name");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.IdNo)
                .HasMaxLength(50)
                .HasColumnName("ID_No");
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.TaxCard)
                .HasMaxLength(50)
                .HasColumnName("tax_card");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");
            entity.Property(e => e.ZipCode).HasMaxLength(10);
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("PK__Inventor__F5FDE6D3DD314ACC");

            entity.ToTable("Inventory");

            entity.Property(e => e.InventoryId).HasColumnName("Inventory_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.ItemId)
                .HasMaxLength(50)
                .HasColumnName("Item_ID");
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Last_Updated");
            entity.Property(e => e.StockId).HasColumnName("Stock_ID");
            entity.Property(e => e.StockLocation)
                .HasMaxLength(100)
                .HasColumnName("Stock_Location");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ItemImage)
                .HasMaxLength(50)
                .HasColumnName("item_image");
            entity.Property(e => e.ItemName)
                .HasMaxLength(100)
                .HasColumnName("Item_Name");
            entity.Property(e => e.ItemPrice).HasColumnName("item_price");
            entity.Property(e => e.MaxItemQuantity).HasColumnName("max_item_quantity");
            entity.Property(e => e.MinItemQuantity).HasColumnName("min_item_quantity");
            entity.Property(e => e.UomId).HasColumnName("uom_ID");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");

            entity.HasOne(d => d.Uom).WithMany(p => p.Items)
                .HasForeignKey(d => d.UomId)
                .HasConstraintName("FK_Items_UOM");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A524E4516");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B6160BBD0E2B8").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("Role_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("Role_Name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PK__StockTyp__391E41DCE5EBF11B");

            entity.HasIndex(e => e.StockName, "UQ__StockTyp__D4E7DFA8E79B1F9E").IsUnique();

            entity.Property(e => e.StockId).HasColumnName("Stock_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.StockName)
                .HasMaxLength(50)
                .HasColumnName("Stock_Name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");
        });

        modelBuilder.Entity<StocksBalance>(entity =>
        {
            entity.HasKey(e => new { e.StockId, e.ItemId });

            entity.ToTable("Stocks_Balance");

            entity.HasIndex(e => new { e.StockId, e.BalanceDate }, "UQ__Stocks_B__30BAF13F6D5EE0C1").IsUnique();

            entity.Property(e => e.StockId).HasColumnName("Stock_ID");
            entity.Property(e => e.ItemId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("item_id");
            entity.Property(e => e.BalanceDate)
                .HasColumnType("datetime")
                .HasColumnName("Balance_Date");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE666945AE51139");

            entity.HasIndex(e => e.Email, "UQ__Supplier__A9D1053471916C3B").IsUnique();

            entity.Property(e => e.SupplierId).HasColumnName("Supplier_ID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CommercialRegister)
                .HasMaxLength(50)
                .HasColumnName("commercial_register");
            entity.Property(e => e.ContactName)
                .HasMaxLength(50)
                .HasColumnName("Contact_Name");
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.IdNo)
                .HasMaxLength(50)
                .HasColumnName("ID_No");
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.SupplierName)
                .HasMaxLength(100)
                .HasColumnName("Supplier_Name");
            entity.Property(e => e.TaxCard)
                .HasMaxLength(50)
                .HasColumnName("tax_card");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");
            entity.Property(e => e.ZipCode).HasMaxLength(10);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("transaction_date");
            entity.Property(e => e.TransactionTypeId).HasColumnName("transaction_type_id");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_transaction_Users");

            entity.HasOne(d => d.Customer).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_transaction_customer");

            entity.HasOne(d => d.TransactionType).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.TransactionTypeId)
                .HasConstraintName("FK_transaction_transactiontype");
        });

        modelBuilder.Entity<TransactionType>(entity =>
        {
            entity.HasKey(e => e.TransactionTypeId).HasName("PK__Transact__20266CEB6599393C");

            entity.ToTable("Transaction_Types");

            entity.HasIndex(e => e.TypeName, "UQ__Transact__D4E7DFA8C94E6B55").IsUnique();

            entity.Property(e => e.TransactionTypeId).HasColumnName("Transaction_Type_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .HasColumnName("Type_Name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");
        });

        modelBuilder.Entity<TransactionsItem>(entity =>
        {
            entity.HasKey(e => new { e.TransactionId, e.ItemId });

            entity.ToTable("Transactions_items");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.ItemPrice).HasColumnName("item_price");
            entity.Property(e => e.ItemQuantity).HasColumnName("item_quantity");
            entity.Property(e => e.Notes)
                .HasMaxLength(100)
                .HasColumnName("notes");

            entity.HasOne(d => d.Transaction).WithMany(p => p.TransactionsItems)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transactions_items_Transactions");
        });

        modelBuilder.Entity<UnitOfMeasure>(entity =>
        {
            entity.HasKey(e => e.UomId).HasName("PK__UnitOfMe__44F5EC9559E09A5D");

            entity.ToTable("Unit_Of_Measure");

            entity.HasIndex(e => e.UomName, "UQ__UnitOfMe__B5EE6678DB695E79").IsUnique();

            entity.Property(e => e.UomId).HasColumnName("uom_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.UomName)
                .HasMaxLength(50)
                .HasColumnName("uom_Name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACEFE79E6A");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4C4BBD088").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053452C5DFB5").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_Name");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("Is_Active");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last_Name");
            entity.Property(e => e.Locked).HasColumnName("locked");
            entity.Property(e => e.LoginFailedTries).HasColumnName("login_failed_tries");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(256)
                .HasColumnName("Password_Hash");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.UserLoginId).HasName("PK__UserLogi__B293ACA50562E0B3");

            entity.ToTable("User_Logins");

            entity.Property(e => e.UserLoginId).HasColumnName("user_Login_ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_date");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(45)
                .HasColumnName("IP_Address");
            entity.Property(e => e.IsSuccess).HasColumnName("Is_Success");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.User).WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userLogin_users");
        });

        modelBuilder.Entity<UsersRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId }).HasName("PK__Users_Ro__AF27604F161A6061");

            entity.ToTable("Users_Roles");

            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.RoleId).HasColumnName("Role_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");

            entity.HasOne(d => d.Role).WithMany(p => p.UsersRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users_Rol__RoleI__45F365D3");

            entity.HasOne(d => d.User).WithMany(p => p.UsersRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Users_Rol__UserI__44FF419A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
