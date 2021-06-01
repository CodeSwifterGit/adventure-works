using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
  public partial class SalesOrderHeaderConfiguration : IEntityTypeConfiguration<SalesOrderHeader>
  {
    public void Configure(EntityTypeBuilder<SalesOrderHeader> builder)
    {
      // Name and Schema
      builder.ToTable("SalesOrderHeader", "Sales");
      
      // Primary Key
      builder.HasKey(e => new { e.SalesOrderID });
      
      // Ignored Properties
      
      // Properties Configuration
      builder.Property(p => p.SalesOrderID)
      .HasColumnType("int")
      .UseIdentityColumn(1, 1)
      .ValueGeneratedOnAdd();
      
      builder.Property(p => p.RevisionNumber)
      .HasColumnType("tinyint")
      .HasDefaultValueSql("((0))");
      
      builder.Property(p => p.OrderDate)
      .HasColumnType("datetime")
      .HasDefaultValueSql("(getdate())");
      
      builder.Property(p => p.DueDate)
      .HasColumnType("datetime");
      
      builder.Property(p => p.ShipDate)
      .HasColumnType("datetime");
      
      builder.Property(p => p.Status)
      .HasColumnType("tinyint")
      .HasDefaultValueSql("((1))");
      
      builder.Property(p => p.OnlineOrderFlag)
      .HasColumnType("bit")
      .HasDefaultValueSql("((1))");
      
      builder.Property(p => p.SalesOrderNumber)
      .HasColumnType("nvarchar(25)")
      .HasComputedColumnSql("(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID]),N'*** ERROR ***'))", false)
      .IsRequired();
      
      builder.Property(p => p.PurchaseOrderNumber)
      .HasColumnType("nvarchar(25)");
      
      builder.Property(p => p.AccountNumber)
      .HasColumnType("nvarchar(15)");
      
      builder.Property(p => p.CustomerID)
      .HasColumnType("int");
      
      builder.Property(p => p.ContactID)
      .HasColumnType("int");
      
      builder.Property(p => p.SalesPersonID)
      .HasColumnType("int");
      
      builder.Property(p => p.TerritoryID)
      .HasColumnType("int");
      
      builder.Property(p => p.BillToAddressID)
      .HasColumnType("int");
      
      builder.Property(p => p.ShipToAddressID)
      .HasColumnType("int");
      
      builder.Property(p => p.ShipMethodID)
      .HasColumnType("int");
      
      builder.Property(p => p.CreditCardID)
      .HasColumnType("int");
      
      builder.Property(p => p.CreditCardApprovalCode)
      .HasColumnType("varchar(15)");
      
      builder.Property(p => p.CurrencyRateID)
      .HasColumnType("int");
      
      builder.Property(p => p.SubTotal)
      .HasColumnType("money")
      .HasDefaultValueSql("((0.00))");
      
      builder.Property(p => p.TaxAmt)
      .HasColumnType("money")
      .HasDefaultValueSql("((0.00))");
      
      builder.Property(p => p.Freight)
      .HasColumnType("money")
      .HasDefaultValueSql("((0.00))");
      
      builder.Property(p => p.TotalDue)
      .HasColumnType("money")
      .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", false);
      
      builder.Property(p => p.Comment)
      .HasColumnType("nvarchar(128)");
      
      builder.Property(p => p.Rowguid)
      .HasColumnName("rowguid")
      .HasColumnType("uniqueidentifier")
      .HasDefaultValueSql("(newid())");
      
      builder.Property(p => p.ModifiedDate)
      .HasColumnType("datetime")
      .HasDefaultValueSql("(getdate())");
      
      // Indexes and Foreign Keys
      builder.HasIndex(e => new { e.Rowguid })
      .IsUnique()
      .HasDatabaseName("AK_SalesOrderHeader_rowguid");
      
      builder.HasIndex(e => new { e.SalesOrderNumber })
      .IsUnique()
      .HasDatabaseName("AK_SalesOrderHeader_SalesOrderNumber");
      
      builder.HasIndex(e => new { e.CustomerID })
      .HasDatabaseName("IX_SalesOrderHeader_CustomerID");
      
      builder.HasIndex(e => new { e.SalesPersonID })
      .HasDatabaseName("IX_SalesOrderHeader_SalesPersonID");
      
      builder.HasIndex(e => new { e.BillToAddressID })
      .HasDatabaseName("FK_SalesOrderHeader_BillToAddress_Address");
      
      builder.HasIndex(e => new { e.ShipToAddressID })
      .HasDatabaseName("FK_SalesOrderHeader_ShipToAddress_Address");
      
      builder.HasIndex(e => new { e.ContactID })
      .HasDatabaseName("FK_SalesOrderHeader_Contact_Contact");
      
      builder.HasIndex(e => new { e.CreditCardID })
      .HasDatabaseName("FK_SalesOrderHeader_CreditCard_CreditCard");
      
      builder.HasIndex(e => new { e.CurrencyRateID })
      .HasDatabaseName("FK_SalesOrderHeader_CurrencyRate_CurrencyRate");
      
      builder.HasIndex(e => new { e.CustomerID })
      .HasDatabaseName("FK_SalesOrderHeader_Customer_Customer");
      
      builder.HasIndex(e => new { e.SalesPersonID })
      .HasDatabaseName("FK_SalesOrderHeader_SalesPerson_SalesPerson");
      
      builder.HasIndex(e => new { e.TerritoryID })
      .HasDatabaseName("FK_SalesOrderHeader_SalesTerritory_SalesTerritory");
      
      builder.HasIndex(e => new { e.ShipMethodID })
      .HasDatabaseName("FK_SalesOrderHeader_ShipMethod_ShipMethod");
      
      builder.HasOne(e => e.BillToAddress)
      .WithMany(p => p.SalesOrderBillToHeaders)
      .HasForeignKey(e => new { e.BillToAddressID })
      .OnDelete(DeleteBehavior.Cascade)
      .HasConstraintName("FK_SalesOrderHeader_Address_BillToAddress_Constraint");
      
      builder.HasOne(e => e.ShipToAddress)
      .WithMany(p => p.SalesOrderShipToHeaders)
      .HasForeignKey(e => new { e.ShipToAddressID })
      .OnDelete(DeleteBehavior.Cascade)
      .HasConstraintName("FK_SalesOrderHeader_Address_ShipToAddress_Constraint");
      
      builder.HasOne(e => e.Contact)
      .WithMany(p => p.SalesOrderHeaders)
      .HasForeignKey(e => new { e.ContactID })
      .OnDelete(DeleteBehavior.Cascade)
      .HasConstraintName("FK_SalesOrderHeader_Contact_Contact_Constraint");
      
      builder.HasOne(e => e.CreditCard)
      .WithMany()
      .HasForeignKey(e => new { e.CreditCardID })
      .OnDelete(DeleteBehavior.Cascade)
      .HasConstraintName("FK_SalesOrderHeader_CreditCard_CreditCard_Constraint");
      
      builder.HasOne(e => e.CurrencyRate)
      .WithMany()
      .HasForeignKey(e => new { e.CurrencyRateID })
      .OnDelete(DeleteBehavior.Cascade)
      .HasConstraintName("FK_SalesOrderHeader_CurrencyRate_CurrencyRate_Constraint");
      
      builder.HasOne(e => e.Customer)
      .WithMany(p => p.SalesOrderHeaders)
      .HasForeignKey(e => new { e.CustomerID })
      .OnDelete(DeleteBehavior.Cascade)
      .HasConstraintName("FK_SalesOrderHeader_Customer_Customer_Constraint");
      
      builder.HasOne(e => e.SalesPerson)
      .WithMany()
      .HasForeignKey(e => new { e.SalesPersonID })
      .OnDelete(DeleteBehavior.Cascade)
      .HasConstraintName("FK_SalesOrderHeader_SalesPerson_SalesPerson_Constraint");
      
      builder.HasOne(e => e.SalesTerritory)
      .WithMany()
      .HasForeignKey(e => new { e.TerritoryID })
      .OnDelete(DeleteBehavior.Cascade)
      .HasConstraintName("FK_SalesOrderHeader_SalesTerritory_SalesTerritory_Constraint");
      
      builder.HasOne(e => e.ShipMethod)
      .WithMany(p => p.SalesOrderHeaders)
      .HasForeignKey(e => new { e.ShipMethodID })
      .OnDelete(DeleteBehavior.Cascade)
      .HasConstraintName("FK_SalesOrderHeader_ShipMethod_ShipMethod_Constraint");
      
      // Complex Types (Owned properties as tables)
      
    }
  }
}