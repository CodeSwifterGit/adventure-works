using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdventureWorks.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Person");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "Production");

            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.EnsureSchema(
                name: "HumanResources");

            migrationBuilder.EnsureSchema(
                name: "Purchasing");

            migrationBuilder.CreateTable(
                name: "AddressType",
                schema: "Person",
                columns: table => new
                {
                    AddressTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.AddressTypeID);
                });

            migrationBuilder.CreateTable(
                name: "AWBuildVersion",
                schema: "dbo",
                columns: table => new
                {
                    SystemInformationID = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    DatabaseVersion = table.Column<string>(name: "Database Version", type: "nvarchar(25)", nullable: false),
                    VersionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AWBuildVersion", x => x.SystemInformationID);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                schema: "Person",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    NameStyle = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    Title = table.Column<string>(type: "varchar(255)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Suffix = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    EmailPromotion = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    Phone = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    PasswordHash = table.Column<string>(type: "varchar(255)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "varchar(10)", nullable: false),
                    AdditionalContactInfo = table.Column<string>(type: "xml", nullable: true),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactID);
                });

            migrationBuilder.CreateTable(
                name: "ContactType",
                schema: "Person",
                columns: table => new
                {
                    ContactTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.ContactTypeID);
                });

            migrationBuilder.CreateTable(
                name: "CountryRegion",
                schema: "Person",
                columns: table => new
                {
                    CountryRegionCode = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryRegion", x => x.CountryRegionCode);
                });

            migrationBuilder.CreateTable(
                name: "CreditCard",
                schema: "Sales",
                columns: table => new
                {
                    CreditCardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CardType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    ExpMonth = table.Column<byte>(type: "tinyint", nullable: false),
                    ExpYear = table.Column<short>(type: "smallint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.CreditCardID);
                });

            migrationBuilder.CreateTable(
                name: "Culture",
                schema: "Production",
                columns: table => new
                {
                    CultureID = table.Column<string>(type: "nchar", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Culture", x => x.CultureID);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "Sales",
                columns: table => new
                {
                    CurrencyCode = table.Column<string>(type: "nchar", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurrencyCode);
                });

            migrationBuilder.CreateTable(
                name: "DatabaseLog",
                schema: "dbo",
                columns: table => new
                {
                    DatabaseLogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    PostTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    DatabaseUser = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Event = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Schema = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    Object = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    TSQL = table.Column<string>(type: "nvarchar(-1)", nullable: false),
                    XmlEvent = table.Column<string>(type: "xml", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseLog", x => x.DatabaseLogID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "HumanResources",
                columns: table => new
                {
                    DepartmentID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                schema: "Production",
                columns: table => new
                {
                    DocumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(8)", nullable: false),
                    Revision = table.Column<string>(type: "nchar", nullable: false),
                    ChangeNumber = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    DocumentSummary = table.Column<string>(type: "nvarchar(-1)", nullable: true),
                    Document = table.Column<byte[]>(type: "varbinary", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.DocumentID);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLog",
                schema: "dbo",
                columns: table => new
                {
                    ErrorLogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ErrorTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UserName = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    ErrorNumber = table.Column<int>(type: "int", nullable: false),
                    ErrorSeverity = table.Column<int>(type: "int", nullable: true),
                    ErrorState = table.Column<int>(type: "int", nullable: true),
                    ErrorProcedure = table.Column<string>(type: "nvarchar(126)", nullable: true),
                    ErrorLine = table.Column<int>(type: "int", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(4000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLog", x => x.ErrorLogID);
                });

            migrationBuilder.CreateTable(
                name: "Illustration",
                schema: "Production",
                columns: table => new
                {
                    IllustrationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Diagram = table.Column<string>(type: "xml", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illustration", x => x.IllustrationID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "Production",
                columns: table => new
                {
                    LocationID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CostRate = table.Column<decimal>(type: "smallmoney", nullable: false, defaultValueSql: "((0.00))"),
                    Availability = table.Column<decimal>(type: "decimal(8,2)", nullable: false, defaultValueSql: "((0.00))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "Production",
                columns: table => new
                {
                    ProductCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ProductCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "ProductDescription",
                schema: "Production",
                columns: table => new
                {
                    ProductDescriptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDescription", x => x.ProductDescriptionID);
                });

            migrationBuilder.CreateTable(
                name: "ProductModel",
                schema: "Production",
                columns: table => new
                {
                    ProductModelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CatalogDescription = table.Column<string>(type: "xml", nullable: true),
                    Instructions = table.Column<string>(type: "xml", nullable: true),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModel", x => x.ProductModelID);
                });

            migrationBuilder.CreateTable(
                name: "ProductPhoto",
                schema: "Production",
                columns: table => new
                {
                    ProductPhotoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ThumbNailPhoto = table.Column<byte[]>(type: "varbinary", nullable: true),
                    ThumbnailPhotoFileName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LargePhoto = table.Column<byte[]>(type: "varbinary", nullable: true),
                    LargePhotoFileName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPhoto", x => x.ProductPhotoID);
                });

            migrationBuilder.CreateTable(
                name: "SalesReason",
                schema: "Sales",
                columns: table => new
                {
                    SalesReasonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ReasonType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReason", x => x.SalesReasonID);
                });

            migrationBuilder.CreateTable(
                name: "SalesTerritory",
                schema: "Sales",
                columns: table => new
                {
                    TerritoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CountryRegionCode = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SalesYTD = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    SalesLastYear = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    CostYTD = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    CostLastYear = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTerritory", x => x.TerritoryID);
                });

            migrationBuilder.CreateTable(
                name: "ScrapReason",
                schema: "Production",
                columns: table => new
                {
                    ScrapReasonID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrapReason", x => x.ScrapReasonID);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                schema: "HumanResources",
                columns: table => new
                {
                    ShiftID = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.ShiftID);
                });

            migrationBuilder.CreateTable(
                name: "ShipMethod",
                schema: "Purchasing",
                columns: table => new
                {
                    ShipMethodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ShipBase = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    ShipRate = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipMethod", x => x.ShipMethodID);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOffer",
                schema: "Sales",
                columns: table => new
                {
                    SpecialOfferID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPct = table.Column<decimal>(type: "smallmoney", nullable: false, defaultValueSql: "((0.00))"),
                    Type = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    MinQty = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    MaxQty = table.Column<int>(type: "int", nullable: true),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOffer", x => x.SpecialOfferID);
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistoryArchive",
                schema: "Production",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ReferenceOrderID = table.Column<int>(type: "int", nullable: false),
                    ReferenceOrderLineID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    TransactionType = table.Column<string>(type: "nchar", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ActualCost = table.Column<decimal>(type: "money", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistoryArchive", x => x.TransactionID);
                });

            migrationBuilder.CreateTable(
                name: "UnitMeasure",
                schema: "Production",
                columns: table => new
                {
                    UnitMeasureCode = table.Column<string>(type: "nchar", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitMeasure", x => x.UnitMeasureCode);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                schema: "Purchasing",
                columns: table => new
                {
                    VendorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreditRating = table.Column<byte>(type: "tinyint", nullable: false),
                    PreferredVendorStatus = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ActiveFlag = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    PurchasingWebServiceURL = table.Column<string>(type: "nvarchar(1024)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.VendorID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "HumanResources",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    EmployeeID1 = table.Column<int>(type: "int", nullable: true),
                    NationalIDNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    ContactID = table.Column<int>(type: "int", nullable: false),
                    LoginID = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    ManagerID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nchar", nullable: false),
                    Gender = table.Column<string>(type: "nchar", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SalariedFlag = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    VacationHours = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "((0))"),
                    SickLeaveHours = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "((0))"),
                    CurrentFlag = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employee_Contact_Contact_Constraint",
                        column: x => x.ContactID,
                        principalSchema: "Person",
                        principalTable: "Contact",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Employee_EmployeeID1",
                        column: x => x.EmployeeID1,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Manager_Employee_Constraint",
                        column: x => x.ManagerID,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactCreditCard",
                schema: "Sales",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false),
                    CreditCardID = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactCreditCard", x => new { x.ContactID, x.CreditCardID });
                    table.ForeignKey(
                        name: "FK_ContactCreditCard_Contact_Contact_Constraint",
                        column: x => x.ContactID,
                        principalSchema: "Person",
                        principalTable: "Contact",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactCreditCard_CreditCard_CreditCard_Constraint",
                        column: x => x.CreditCardID,
                        principalSchema: "Sales",
                        principalTable: "CreditCard",
                        principalColumn: "CreditCardID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryRegionCurrency",
                schema: "Sales",
                columns: table => new
                {
                    CountryRegionCode = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nchar", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryRegionCurrency", x => new { x.CountryRegionCode, x.CurrencyCode });
                    table.ForeignKey(
                        name: "FK_CountryRegionCurrency_CountryRegion_CountryRegion_Constraint",
                        column: x => x.CountryRegionCode,
                        principalSchema: "Person",
                        principalTable: "CountryRegion",
                        principalColumn: "CountryRegionCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryRegionCurrency_Currency_Currency_Constraint",
                        column: x => x.CurrencyCode,
                        principalSchema: "Sales",
                        principalTable: "Currency",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyRate",
                schema: "Sales",
                columns: table => new
                {
                    CurrencyRateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CurrencyRateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FromCurrencyCode = table.Column<string>(type: "nchar", nullable: false),
                    ToCurrencyCode = table.Column<string>(type: "nchar", nullable: false),
                    AverageRate = table.Column<decimal>(type: "money", nullable: false),
                    EndOfDayRate = table.Column<decimal>(type: "money", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyRate", x => x.CurrencyRateID);
                    table.ForeignKey(
                        name: "FK_CurrencyRate_Currency_CurrencyFrom_Constraint",
                        column: x => x.FromCurrencyCode,
                        principalSchema: "Sales",
                        principalTable: "Currency",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrencyRate_Currency_CurrencyTo_Constraint",
                        column: x => x.ToCurrencyCode,
                        principalSchema: "Sales",
                        principalTable: "Currency",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSubcategory",
                schema: "Production",
                columns: table => new
                {
                    ProductSubcategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductCategoryID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSubcategory", x => x.ProductSubcategoryID);
                    table.ForeignKey(
                        name: "FK_ProductSubcategory_ProductCategory_ProductCategory_Constraint",
                        column: x => x.ProductCategoryID,
                        principalSchema: "Production",
                        principalTable: "ProductCategory",
                        principalColumn: "ProductCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductModelIllustration",
                schema: "Production",
                columns: table => new
                {
                    ProductModelID = table.Column<int>(type: "int", nullable: false),
                    IllustrationID = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModelIllustration", x => new { x.ProductModelID, x.IllustrationID });
                    table.ForeignKey(
                        name: "FK_ProductModelIllustration_Illustration_Illustration_Constraint",
                        column: x => x.IllustrationID,
                        principalSchema: "Production",
                        principalTable: "Illustration",
                        principalColumn: "IllustrationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductModelIllustration_ProductModel_ProductModel_Constraint",
                        column: x => x.ProductModelID,
                        principalSchema: "Production",
                        principalTable: "ProductModel",
                        principalColumn: "ProductModelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductModelProductDescriptionCulture",
                schema: "Production",
                columns: table => new
                {
                    ProductModelID = table.Column<int>(type: "int", nullable: false),
                    ProductDescriptionID = table.Column<int>(type: "int", nullable: false),
                    CultureID = table.Column<string>(type: "nchar", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModelProductDescriptionCulture", x => new { x.ProductModelID, x.ProductDescriptionID, x.CultureID });
                    table.ForeignKey(
                        name: "FK_ProductModelProductDescriptionCulture_Culture_Culture_Constraint",
                        column: x => x.CultureID,
                        principalSchema: "Production",
                        principalTable: "Culture",
                        principalColumn: "CultureID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescription_Constraint",
                        column: x => x.ProductDescriptionID,
                        principalSchema: "Production",
                        principalTable: "ProductDescription",
                        principalColumn: "ProductDescriptionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductModelProductDescriptionCulture_ProductModel_ProductModel_Constraint",
                        column: x => x.ProductModelID,
                        principalSchema: "Production",
                        principalTable: "ProductModel",
                        principalColumn: "ProductModelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Sales",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    SalesTerritoryTerritoryID = table.Column<int>(type: "int", nullable: true),
                    TerritoryID = table.Column<int>(type: "int", nullable: true),
                    AccountNumber = table.Column<string>(type: "varchar(10)", nullable: false, computedColumnSql: "(isnull('AW'+[dbo].[ufnLeadingZeros]([CustomerID]),''))", stored: false),
                    CustomerType = table.Column<string>(type: "nchar", nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customer_SalesTerritory_SalesTerritory_Constraint",
                        column: x => x.TerritoryID,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_SalesTerritory_SalesTerritoryTerritoryID",
                        column: x => x.SalesTerritoryTerritoryID,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StateProvince",
                schema: "Person",
                columns: table => new
                {
                    StateProvinceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    StateProvinceCode = table.Column<string>(type: "nchar", nullable: false),
                    CountryRegionCode = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    IsOnlyStateProvinceFlag = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    TerritoryID = table.Column<int>(type: "int", nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateProvince", x => x.StateProvinceID);
                    table.ForeignKey(
                        name: "FK_StateProvince_CountryRegion_CountryRegion_Constraint",
                        column: x => x.CountryRegionCode,
                        principalSchema: "Person",
                        principalTable: "CountryRegion",
                        principalColumn: "CountryRegionCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StateProvince_SalesTerritory_SalesTerritory_Constraint",
                        column: x => x.TerritoryID,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorContact",
                schema: "Purchasing",
                columns: table => new
                {
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    ContactID = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ContactTypeID = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorContact", x => new { x.VendorID, x.ContactID });
                    table.ForeignKey(
                        name: "FK_VendorContact_Contact_Contact_Constraint",
                        column: x => x.ContactID,
                        principalSchema: "Person",
                        principalTable: "Contact",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendorContact_ContactType_ContactType_Constraint",
                        column: x => x.ContactTypeID,
                        principalSchema: "Person",
                        principalTable: "ContactType",
                        principalColumn: "ContactTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendorContact_Vendor_Vendor_Constraint",
                        column: x => x.VendorID,
                        principalSchema: "Purchasing",
                        principalTable: "Vendor",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDepartmentHistory",
                schema: "HumanResources",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<short>(type: "smallint", nullable: false),
                    ShiftID = table.Column<byte>(type: "tinyint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDepartmentHistory", x => new { x.EmployeeID, x.DepartmentID, x.ShiftID, x.StartDate });
                    table.ForeignKey(
                        name: "FK_EmployeeDepartmentHistory_Department_Department_Constraint",
                        column: x => x.DepartmentID,
                        principalSchema: "HumanResources",
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartmentHistory_Employee_Employee_Constraint",
                        column: x => x.EmployeeID,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartmentHistory_Shift_Shift_Constraint",
                        column: x => x.ShiftID,
                        principalSchema: "HumanResources",
                        principalTable: "Shift",
                        principalColumn: "ShiftID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePayHistory",
                schema: "HumanResources",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    RateChangeDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Rate = table.Column<decimal>(type: "money", nullable: false),
                    PayFrequency = table.Column<byte>(type: "tinyint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePayHistory", x => new { x.EmployeeID, x.RateChangeDate });
                    table.ForeignKey(
                        name: "FK_EmployeePayHistory_Employee_Employee_Constraint",
                        column: x => x.EmployeeID,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobCandidate",
                schema: "HumanResources",
                columns: table => new
                {
                    JobCandidateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    EmployeeID1 = table.Column<int>(type: "int", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    Resume = table.Column<string>(type: "xml", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCandidate", x => x.JobCandidateID);
                    table.ForeignKey(
                        name: "FK_JobCandidate_Employee_Employee_Constraint",
                        column: x => x.EmployeeID,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCandidate_Employee_EmployeeID1",
                        column: x => x.EmployeeID1,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderHeader",
                schema: "Purchasing",
                columns: table => new
                {
                    PurchaseOrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    RevisionNumber = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "((1))"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    ShipMethodID = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SubTotal = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    TaxAmt = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    Freight = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    TotalDue = table.Column<decimal>(type: "money", nullable: false, computedColumnSql: "(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", stored: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderHeader", x => x.PurchaseOrderID);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderHeader_Employee_Employee_Constraint",
                        column: x => x.EmployeeID,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderHeader_ShipMethod_ShipMethod_Constraint",
                        column: x => x.ShipMethodID,
                        principalSchema: "Purchasing",
                        principalTable: "ShipMethod",
                        principalColumn: "ShipMethodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderHeader_Vendor_Vendor_Constraint",
                        column: x => x.VendorID,
                        principalSchema: "Purchasing",
                        principalTable: "Vendor",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesPerson",
                schema: "Sales",
                columns: table => new
                {
                    SalesPersonID = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    SalesTerritoryTerritoryID = table.Column<int>(type: "int", nullable: true),
                    TerritoryID = table.Column<int>(type: "int", nullable: true),
                    SalesQuota = table.Column<decimal>(type: "money", nullable: true),
                    Bonus = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    CommissionPct = table.Column<decimal>(type: "smallmoney", nullable: false, defaultValueSql: "((0.00))"),
                    SalesYTD = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    SalesLastYear = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPerson", x => x.SalesPersonID);
                    table.ForeignKey(
                        name: "FK_SalesPerson_Employee_Employee_Constraint",
                        column: x => x.SalesPersonID,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesPerson_SalesTerritory_SalesTerritory_Constraint",
                        column: x => x.TerritoryID,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesPerson_SalesTerritory_SalesTerritoryTerritoryID",
                        column: x => x.SalesTerritoryTerritoryID,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Production",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductModelID1 = table.Column<int>(type: "int", nullable: true),
                    ProductSubcategoryID1 = table.Column<int>(type: "int", nullable: true),
                    UnitMeasureCode = table.Column<string>(type: "nchar", nullable: true),
                    UnitMeasureCode1 = table.Column<string>(type: "nchar", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ProductNumber = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    MakeFlag = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    FinishedGoodsFlag = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Color = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    SafetyStockLevel = table.Column<short>(type: "smallint", nullable: false),
                    ReorderPoint = table.Column<short>(type: "smallint", nullable: false),
                    StandardCost = table.Column<decimal>(type: "money", nullable: false),
                    ListPrice = table.Column<decimal>(type: "money", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    SizeUnitMeasureCode = table.Column<string>(type: "nchar", nullable: true),
                    WeightUnitMeasureCode = table.Column<string>(type: "nchar", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    DaysToManufacture = table.Column<int>(type: "int", nullable: false),
                    ProductLine = table.Column<string>(type: "nchar", nullable: true),
                    Class = table.Column<string>(type: "nchar", nullable: true),
                    Style = table.Column<string>(type: "nchar", nullable: true),
                    ProductSubcategoryID = table.Column<int>(type: "int", nullable: true),
                    ProductModelID = table.Column<int>(type: "int", nullable: true),
                    SellStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SellEndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiscontinuedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_ProductModel_ProductModel_Constraint",
                        column: x => x.ProductModelID,
                        principalSchema: "Production",
                        principalTable: "ProductModel",
                        principalColumn: "ProductModelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductModel_ProductModelID1",
                        column: x => x.ProductModelID1,
                        principalSchema: "Production",
                        principalTable: "ProductModel",
                        principalColumn: "ProductModelID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ProductSubcategory_ProductSubcategory_Constraint",
                        column: x => x.ProductSubcategoryID,
                        principalSchema: "Production",
                        principalTable: "ProductSubcategory",
                        principalColumn: "ProductSubcategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductSubcategory_ProductSubcategoryID1",
                        column: x => x.ProductSubcategoryID1,
                        principalSchema: "Production",
                        principalTable: "ProductSubcategory",
                        principalColumn: "ProductSubcategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_UnitMeasure_UnitMeasureCode",
                        column: x => x.UnitMeasureCode,
                        principalSchema: "Production",
                        principalTable: "UnitMeasure",
                        principalColumn: "UnitMeasureCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_UnitMeasure_UnitMeasureCode1",
                        column: x => x.UnitMeasureCode1,
                        principalSchema: "Production",
                        principalTable: "UnitMeasure",
                        principalColumn: "UnitMeasureCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_UnitMeasureSize_UnitMeasure_Constraint",
                        column: x => x.SizeUnitMeasureCode,
                        principalSchema: "Production",
                        principalTable: "UnitMeasure",
                        principalColumn: "UnitMeasureCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_UnitMeasureWeight_UnitMeasure_Constraint",
                        column: x => x.WeightUnitMeasureCode,
                        principalSchema: "Production",
                        principalTable: "UnitMeasure",
                        principalColumn: "UnitMeasureCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Individual",
                schema: "Sales",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ContactID = table.Column<int>(type: "int", nullable: false),
                    Demographics = table.Column<string>(type: "xml", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individual", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Individual_Contact_Contact_Constraint",
                        column: x => x.ContactID,
                        principalSchema: "Person",
                        principalTable: "Contact",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Individual_Customer_Customer_Constraint",
                        column: x => x.CustomerID,
                        principalSchema: "Sales",
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Person",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    StateProvinceID = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Address_StateProvince_StateProvince_Constraint",
                        column: x => x.StateProvinceID,
                        principalSchema: "Person",
                        principalTable: "StateProvince",
                        principalColumn: "StateProvinceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesTaxRate",
                schema: "Sales",
                columns: table => new
                {
                    SalesTaxRateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    StateProvinceID = table.Column<int>(type: "int", nullable: false),
                    TaxType = table.Column<byte>(type: "tinyint", nullable: false),
                    TaxRate = table.Column<decimal>(type: "smallmoney", nullable: false, defaultValueSql: "((0.00))"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTaxRate", x => x.SalesTaxRateID);
                    table.ForeignKey(
                        name: "FK_SalesTaxRate_StateProvince_StateProvince_Constraint",
                        column: x => x.StateProvinceID,
                        principalSchema: "Person",
                        principalTable: "StateProvince",
                        principalColumn: "StateProvinceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesPersonQuotaHistory",
                schema: "Sales",
                columns: table => new
                {
                    SalesPersonID = table.Column<int>(type: "int", nullable: false),
                    QuotaDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    SalesQuota = table.Column<decimal>(type: "money", nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPersonQuotaHistory", x => new { x.SalesPersonID, x.QuotaDate });
                    table.ForeignKey(
                        name: "FK_SalesPersonQuotaHistory_SalesPerson_SalesPerson_Constraint",
                        column: x => x.SalesPersonID,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "SalesPersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesTerritoryHistory",
                schema: "Sales",
                columns: table => new
                {
                    SalesPersonID = table.Column<int>(type: "int", nullable: false),
                    TerritoryID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTerritoryHistory", x => new { x.SalesPersonID, x.TerritoryID, x.StartDate });
                    table.ForeignKey(
                        name: "FK_SalesTerritoryHistory_SalesPerson_SalesPerson_Constraint",
                        column: x => x.SalesPersonID,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "SalesPersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesTerritoryHistory_SalesTerritory_SalesTerritory_Constraint",
                        column: x => x.TerritoryID,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                schema: "Sales",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    SalesPersonID1 = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SalesPersonID = table.Column<int>(type: "int", nullable: true),
                    Demographics = table.Column<string>(type: "xml", nullable: true),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Store_Customer_Customer_Constraint",
                        column: x => x.CustomerID,
                        principalSchema: "Sales",
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Store_SalesPerson_SalesPerson_Constraint",
                        column: x => x.SalesPersonID,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "SalesPersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Store_SalesPerson_SalesPersonID1",
                        column: x => x.SalesPersonID1,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "SalesPersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillOfMaterials",
                schema: "Production",
                columns: table => new
                {
                    BillOfMaterialsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    ProductAssemblyID = table.Column<int>(type: "int", nullable: true),
                    ComponentID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UnitMeasureCode = table.Column<string>(type: "nchar", nullable: false),
                    BOMLevel = table.Column<short>(type: "smallint", nullable: false),
                    PerAssemblyQty = table.Column<decimal>(type: "decimal(8,2)", nullable: false, defaultValueSql: "((1.00))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillOfMaterials", x => x.BillOfMaterialsID);
                    table.ForeignKey(
                        name: "FK_BillOfMaterials_Product_AssemblyProduct_Constraint",
                        column: x => x.ProductAssemblyID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillOfMaterials_Product_ComponentProduct_Constraint",
                        column: x => x.ComponentID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillOfMaterials_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillOfMaterials_UnitMeasure_UnitMeasure_Constraint",
                        column: x => x.UnitMeasureCode,
                        principalSchema: "Production",
                        principalTable: "UnitMeasure",
                        principalColumn: "UnitMeasureCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCostHistory",
                schema: "Production",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StandardCost = table.Column<decimal>(type: "money", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCostHistory", x => new { x.ProductID, x.StartDate });
                    table.ForeignKey(
                        name: "FK_ProductCostHistory_Product_Product_Constraint",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDocument",
                schema: "Production",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    DocumentID = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDocument", x => new { x.ProductID, x.DocumentID });
                    table.ForeignKey(
                        name: "FK_ProductDocument_Document_Document_Constraint",
                        column: x => x.DocumentID,
                        principalSchema: "Production",
                        principalTable: "Document",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDocument_Product_Product_Constraint",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInventory",
                schema: "Production",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    LocationID = table.Column<short>(type: "smallint", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Shelf = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Bin = table.Column<byte>(type: "tinyint", nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "((0))"),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventory", x => new { x.ProductID, x.LocationID });
                    table.ForeignKey(
                        name: "FK_ProductInventory_Location_Location_Constraint",
                        column: x => x.LocationID,
                        principalSchema: "Production",
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInventory_Product_Product_Constraint",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductListPriceHistory",
                schema: "Production",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ListPrice = table.Column<decimal>(type: "money", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductListPriceHistory", x => new { x.ProductID, x.StartDate });
                    table.ForeignKey(
                        name: "FK_ProductListPriceHistory_Product_Product_Constraint",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductPhoto",
                schema: "Production",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ProductPhotoID = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Primary = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductPhoto", x => new { x.ProductID, x.ProductPhotoID });
                    table.ForeignKey(
                        name: "FK_ProductProductPhoto_Product_Product_Constraint",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductPhoto_ProductPhoto_ProductPhoto_Constraint",
                        column: x => x.ProductPhotoID,
                        principalSchema: "Production",
                        principalTable: "ProductPhoto",
                        principalColumn: "ProductPhotoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReview",
                schema: "Production",
                columns: table => new
                {
                    ProductReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ReviewerName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    EmailAddress = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(3850)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReview", x => x.ProductReviewID);
                    table.ForeignKey(
                        name: "FK_ProductReview_Product_Product_Constraint",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVendor",
                schema: "Purchasing",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    AverageLeadTime = table.Column<int>(type: "int", nullable: false),
                    StandardPrice = table.Column<decimal>(type: "money", nullable: false),
                    LastReceiptCost = table.Column<decimal>(type: "money", nullable: true),
                    LastReceiptDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    MinOrderQty = table.Column<int>(type: "int", nullable: false),
                    MaxOrderQty = table.Column<int>(type: "int", nullable: false),
                    OnOrderQty = table.Column<int>(type: "int", nullable: true),
                    UnitMeasureCode = table.Column<string>(type: "nchar", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVendor", x => new { x.ProductID, x.VendorID });
                    table.ForeignKey(
                        name: "FK_ProductVendor_Product_Product_Constraint",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVendor_UnitMeasure_UnitMeasure_Constraint",
                        column: x => x.UnitMeasureCode,
                        principalSchema: "Production",
                        principalTable: "UnitMeasure",
                        principalColumn: "UnitMeasureCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVendor_Vendor_Vendor_Constraint",
                        column: x => x.VendorID,
                        principalSchema: "Purchasing",
                        principalTable: "Vendor",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderDetail",
                schema: "Purchasing",
                columns: table => new
                {
                    PurchaseOrderID = table.Column<int>(type: "int", nullable: false),
                    PurchaseOrderDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    OrderQty = table.Column<short>(type: "smallint", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    LineTotal = table.Column<decimal>(type: "money", nullable: false, computedColumnSql: "(isnull([OrderQty]*[UnitPrice],(0.00)))", stored: false),
                    ReceivedQty = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    RejectedQty = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    StockedQty = table.Column<decimal>(type: "decimal(9,2)", nullable: false, computedColumnSql: "(isnull([ReceivedQty]-[RejectedQty],(0.00)))", stored: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderDetail", x => new { x.PurchaseOrderID, x.PurchaseOrderDetailID });
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetail_Product_Product_Constraint",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderHeader_Constraint",
                        column: x => x.PurchaseOrderID,
                        principalSchema: "Purchasing",
                        principalTable: "PurchaseOrderHeader",
                        principalColumn: "PurchaseOrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                schema: "Sales",
                columns: table => new
                {
                    ShoppingCartItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ShoppingCartID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.ShoppingCartItemID);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Product_Product_Constraint",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOfferProduct",
                schema: "Sales",
                columns: table => new
                {
                    SpecialOfferID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOfferProduct", x => new { x.SpecialOfferID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_SpecialOfferProduct_Product_Product_Constraint",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialOfferProduct_SpecialOffer_SpecialOffer_Constraint",
                        column: x => x.SpecialOfferID,
                        principalSchema: "Sales",
                        principalTable: "SpecialOffer",
                        principalColumn: "SpecialOfferID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistory",
                schema: "Production",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100000, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ReferenceOrderID = table.Column<int>(type: "int", nullable: false),
                    ReferenceOrderLineID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    TransactionType = table.Column<string>(type: "nchar", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ActualCost = table.Column<decimal>(type: "money", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistory", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_Product_Product_Constraint",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrder",
                schema: "Production",
                columns: table => new
                {
                    WorkOrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ScrapReasonID1 = table.Column<short>(type: "smallint", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    OrderQty = table.Column<int>(type: "int", nullable: false),
                    StockedQty = table.Column<int>(type: "int", nullable: false, computedColumnSql: "(isnull([OrderQty]-[ScrappedQty],(0)))", stored: false),
                    ScrappedQty = table.Column<short>(type: "smallint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ScrapReasonID = table.Column<short>(type: "smallint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrder", x => x.WorkOrderID);
                    table.ForeignKey(
                        name: "FK_WorkOrder_Product_Product_Constraint",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrder_ScrapReason_ScrapReason_Constraint",
                        column: x => x.ScrapReasonID,
                        principalSchema: "Production",
                        principalTable: "ScrapReason",
                        principalColumn: "ScrapReasonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrder_ScrapReason_ScrapReasonID1",
                        column: x => x.ScrapReasonID1,
                        principalSchema: "Production",
                        principalTable: "ScrapReason",
                        principalColumn: "ScrapReasonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddress",
                schema: "Sales",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    AddressTypeID = table.Column<int>(type: "int", nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddress", x => new { x.CustomerID, x.AddressID });
                    table.ForeignKey(
                        name: "FK_CustomerAddress_Address_Address_Constraint",
                        column: x => x.AddressID,
                        principalSchema: "Person",
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_AddressType_AddressType_Constraint",
                        column: x => x.AddressTypeID,
                        principalSchema: "Person",
                        principalTable: "AddressType",
                        principalColumn: "AddressTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_Customer_Customer_Constraint",
                        column: x => x.CustomerID,
                        principalSchema: "Sales",
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAddress",
                schema: "HumanResources",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAddress", x => new { x.EmployeeID, x.AddressID });
                    table.ForeignKey(
                        name: "FK_EmployeeAddress_Address_Address_Constraint",
                        column: x => x.AddressID,
                        principalSchema: "Person",
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeAddress_Employee_Employee_Constraint",
                        column: x => x.EmployeeID,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderHeader",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreditCardID1 = table.Column<int>(type: "int", nullable: true),
                    CurrencyRateID1 = table.Column<int>(type: "int", nullable: true),
                    SalesPersonID1 = table.Column<int>(type: "int", nullable: true),
                    SalesTerritoryTerritoryID = table.Column<int>(type: "int", nullable: true),
                    RevisionNumber = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "((0))"),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "((1))"),
                    OnlineOrderFlag = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    SalesOrderNumber = table.Column<string>(type: "nvarchar(25)", nullable: false, computedColumnSql: "(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID]),N'*** ERROR ***'))", stored: false),
                    PurchaseOrderNumber = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    ContactID = table.Column<int>(type: "int", nullable: false),
                    SalesPersonID = table.Column<int>(type: "int", nullable: true),
                    TerritoryID = table.Column<int>(type: "int", nullable: true),
                    BillToAddressID = table.Column<int>(type: "int", nullable: false),
                    ShipToAddressID = table.Column<int>(type: "int", nullable: false),
                    ShipMethodID = table.Column<int>(type: "int", nullable: false),
                    CreditCardID = table.Column<int>(type: "int", nullable: true),
                    CreditCardApprovalCode = table.Column<string>(type: "varchar(15)", nullable: true),
                    CurrencyRateID = table.Column<int>(type: "int", nullable: true),
                    SubTotal = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    TaxAmt = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    Freight = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    TotalDue = table.Column<decimal>(type: "money", nullable: false, computedColumnSql: "(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", stored: false),
                    Comment = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderHeader", x => x.SalesOrderID);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_Address_BillToAddress_Constraint",
                        column: x => x.BillToAddressID,
                        principalSchema: "Person",
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_Address_ShipToAddress_Constraint",
                        column: x => x.ShipToAddressID,
                        principalSchema: "Person",
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_Contact_Contact_Constraint",
                        column: x => x.ContactID,
                        principalSchema: "Person",
                        principalTable: "Contact",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_CreditCard_CreditCard_Constraint",
                        column: x => x.CreditCardID,
                        principalSchema: "Sales",
                        principalTable: "CreditCard",
                        principalColumn: "CreditCardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_CreditCard_CreditCardID1",
                        column: x => x.CreditCardID1,
                        principalSchema: "Sales",
                        principalTable: "CreditCard",
                        principalColumn: "CreditCardID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_CurrencyRate_CurrencyRate_Constraint",
                        column: x => x.CurrencyRateID,
                        principalSchema: "Sales",
                        principalTable: "CurrencyRate",
                        principalColumn: "CurrencyRateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_CurrencyRate_CurrencyRateID1",
                        column: x => x.CurrencyRateID1,
                        principalSchema: "Sales",
                        principalTable: "CurrencyRate",
                        principalColumn: "CurrencyRateID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_Customer_Customer_Constraint",
                        column: x => x.CustomerID,
                        principalSchema: "Sales",
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_SalesPerson_SalesPerson_Constraint",
                        column: x => x.SalesPersonID,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "SalesPersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_SalesPerson_SalesPersonID1",
                        column: x => x.SalesPersonID1,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "SalesPersonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_SalesTerritory_SalesTerritory_Constraint",
                        column: x => x.TerritoryID,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_SalesTerritory_SalesTerritoryTerritoryID",
                        column: x => x.SalesTerritoryTerritoryID,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_ShipMethod_ShipMethod_Constraint",
                        column: x => x.ShipMethodID,
                        principalSchema: "Purchasing",
                        principalTable: "ShipMethod",
                        principalColumn: "ShipMethodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorAddress",
                schema: "Purchasing",
                columns: table => new
                {
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    AddressTypeID = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorAddress", x => new { x.VendorID, x.AddressID });
                    table.ForeignKey(
                        name: "FK_VendorAddress_Address_Address_Constraint",
                        column: x => x.AddressID,
                        principalSchema: "Person",
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendorAddress_AddressType_AddressType_Constraint",
                        column: x => x.AddressTypeID,
                        principalSchema: "Person",
                        principalTable: "AddressType",
                        principalColumn: "AddressTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendorAddress_Vendor_Vendor_Constraint",
                        column: x => x.VendorID,
                        principalSchema: "Purchasing",
                        principalTable: "Vendor",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreContact",
                schema: "Sales",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    ContactID = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ContactTypeID = table.Column<int>(type: "int", nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreContact", x => new { x.CustomerID, x.ContactID });
                    table.ForeignKey(
                        name: "FK_StoreContact_Contact_Contact_Constraint",
                        column: x => x.ContactID,
                        principalSchema: "Person",
                        principalTable: "Contact",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreContact_ContactType_ContactType_Constraint",
                        column: x => x.ContactTypeID,
                        principalSchema: "Person",
                        principalTable: "ContactType",
                        principalColumn: "ContactTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreContact_Store_Store_Constraint",
                        column: x => x.CustomerID,
                        principalSchema: "Sales",
                        principalTable: "Store",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderRouting",
                schema: "Production",
                columns: table => new
                {
                    WorkOrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    OperationSequence = table.Column<short>(type: "smallint", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LocationID = table.Column<short>(type: "smallint", nullable: false),
                    ScheduledStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ScheduledEndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ActualStartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ActualEndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ActualResourceHrs = table.Column<decimal>(type: "decimal(9,4)", nullable: true),
                    PlannedCost = table.Column<decimal>(type: "money", nullable: false),
                    ActualCost = table.Column<decimal>(type: "money", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderRouting", x => new { x.WorkOrderID, x.ProductID, x.OperationSequence });
                    table.ForeignKey(
                        name: "FK_WorkOrderRouting_Location_Location_Constraint",
                        column: x => x.LocationID,
                        principalSchema: "Production",
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrderRouting_WorkOrder_WorkOrder_Constraint",
                        column: x => x.WorkOrderID,
                        principalSchema: "Production",
                        principalTable: "WorkOrder",
                        principalColumn: "WorkOrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderDetail",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(type: "int", nullable: false),
                    SalesOrderDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CarrierTrackingNumber = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    OrderQty = table.Column<short>(type: "smallint", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    SpecialOfferID = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    UnitPriceDiscount = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.0))"),
                    LineTotal = table.Column<decimal>(type: "numeric", nullable: false, computedColumnSql: "(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))", stored: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderDetail", x => new { x.SalesOrderID, x.SalesOrderDetailID });
                    table.ForeignKey(
                        name: "FK_SalesOrderDetail_SalesOrderHeader_SalesOrderHeader_Constraint",
                        column: x => x.SalesOrderID,
                        principalSchema: "Sales",
                        principalTable: "SalesOrderHeader",
                        principalColumn: "SalesOrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferProduct_Constraint",
                        columns: x => new { x.ProductID, x.SpecialOfferID },
                        principalSchema: "Sales",
                        principalTable: "SpecialOfferProduct",
                        principalColumns: new[] { "SpecialOfferID", "ProductID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderHeaderSalesReason",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(type: "int", nullable: false),
                    SalesReasonID = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderHeaderSalesReason", x => new { x.SalesOrderID, x.SalesReasonID });
                    table.ForeignKey(
                        name: "FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderHeader_Constraint",
                        column: x => x.SalesOrderID,
                        principalSchema: "Sales",
                        principalTable: "SalesOrderHeader",
                        principalColumn: "SalesOrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeaderSalesReason_SalesReason_SalesReason_Constraint",
                        column: x => x.SalesReasonID,
                        principalSchema: "Sales",
                        principalTable: "SalesReason",
                        principalColumn: "SalesReasonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "AK_Address_rowguid",
                schema: "Person",
                table: "Address",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Address_StateProvince_StateProvince",
                schema: "Person",
                table: "Address",
                column: "StateProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode",
                schema: "Person",
                table: "Address",
                columns: new[] { "AddressLine1", "AddressLine2", "City", "PostalCode", "StateProvinceID" },
                unique: true,
                filter: "[AddressLine2] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "AK_AddressType_Name",
                schema: "Person",
                table: "AddressType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_AddressType_rowguid",
                schema: "Person",
                table: "AddressType",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_BillOfMaterials_ProductAssemblyID_ComponentID_StartDate",
                schema: "Production",
                table: "BillOfMaterials",
                columns: new[] { "ComponentID", "ProductAssemblyID", "StartDate" },
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "FK_BillOfMaterials_AssemblyProduct_Product",
                schema: "Production",
                table: "BillOfMaterials",
                column: "ProductAssemblyID");

            migrationBuilder.CreateIndex(
                name: "FK_BillOfMaterials_ComponentProduct_Product",
                schema: "Production",
                table: "BillOfMaterials",
                column: "ComponentID");

            migrationBuilder.CreateIndex(
                name: "FK_BillOfMaterials_UnitMeasure_UnitMeasure",
                schema: "Production",
                table: "BillOfMaterials",
                column: "UnitMeasureCode");

            migrationBuilder.CreateIndex(
                name: "IX_BillOfMaterials_ProductID",
                schema: "Production",
                table: "BillOfMaterials",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "AK_Contact_rowguid",
                schema: "Person",
                table: "Contact",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_EmailAddress",
                schema: "Person",
                table: "Contact",
                column: "EmailAddress");

            migrationBuilder.CreateIndex(
                name: "PXML_Contact_AddContact",
                schema: "Person",
                table: "Contact",
                column: "AdditionalContactInfo");

            migrationBuilder.CreateIndex(
                name: "FK_ContactCreditCard_Contact_Contact",
                schema: "Sales",
                table: "ContactCreditCard",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "FK_ContactCreditCard_CreditCard_CreditCard",
                schema: "Sales",
                table: "ContactCreditCard",
                column: "CreditCardID");

            migrationBuilder.CreateIndex(
                name: "AK_ContactType_Name",
                schema: "Person",
                table: "ContactType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_CountryRegion_Name",
                schema: "Person",
                table: "CountryRegion",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_CountryRegionCurrency_CountryRegion_CountryRegion",
                schema: "Sales",
                table: "CountryRegionCurrency",
                column: "CountryRegionCode");

            migrationBuilder.CreateIndex(
                name: "FK_CountryRegionCurrency_Currency_Currency",
                schema: "Sales",
                table: "CountryRegionCurrency",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "AK_CreditCard_CardNumber",
                schema: "Sales",
                table: "CreditCard",
                column: "CardNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Culture_Name",
                schema: "Production",
                table: "Culture",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Currency_Name",
                schema: "Sales",
                table: "Currency",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode",
                schema: "Sales",
                table: "CurrencyRate",
                columns: new[] { "CurrencyRateDate", "FromCurrencyCode", "ToCurrencyCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_CurrencyRate_CurrencyFrom_Currency",
                schema: "Sales",
                table: "CurrencyRate",
                column: "FromCurrencyCode");

            migrationBuilder.CreateIndex(
                name: "FK_CurrencyRate_CurrencyTo_Currency",
                schema: "Sales",
                table: "CurrencyRate",
                column: "ToCurrencyCode");

            migrationBuilder.CreateIndex(
                name: "AK_Customer_AccountNumber",
                schema: "Sales",
                table: "Customer",
                column: "AccountNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Customer_rowguid",
                schema: "Sales",
                table: "Customer",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Customer_SalesTerritory_SalesTerritory",
                schema: "Sales",
                table: "Customer",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_SalesTerritoryTerritoryID",
                schema: "Sales",
                table: "Customer",
                column: "SalesTerritoryTerritoryID");

            migrationBuilder.CreateIndex(
                name: "AK_CustomerAddress_rowguid",
                schema: "Sales",
                table: "CustomerAddress",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_CustomerAddress_Address_Address",
                schema: "Sales",
                table: "CustomerAddress",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "FK_CustomerAddress_AddressType_AddressType",
                schema: "Sales",
                table: "CustomerAddress",
                column: "AddressTypeID");

            migrationBuilder.CreateIndex(
                name: "FK_CustomerAddress_Customer_Customer",
                schema: "Sales",
                table: "CustomerAddress",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "AK_Department_Name",
                schema: "HumanResources",
                table: "Department",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Document_FileName_Revision",
                schema: "Production",
                table: "Document",
                columns: new[] { "FileName", "Revision" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Employee_LoginID",
                schema: "HumanResources",
                table: "Employee",
                column: "LoginID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Employee_NationalIDNumber",
                schema: "HumanResources",
                table: "Employee",
                column: "NationalIDNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Employee_rowguid",
                schema: "HumanResources",
                table: "Employee",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Employee_Contact_Contact",
                schema: "HumanResources",
                table: "Employee",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "FK_Employee_Manager_Employee",
                schema: "HumanResources",
                table: "Employee",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeID1",
                schema: "HumanResources",
                table: "Employee",
                column: "EmployeeID1");

            migrationBuilder.CreateIndex(
                name: "AK_EmployeeAddress_rowguid",
                schema: "HumanResources",
                table: "EmployeeAddress",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_EmployeeAddress_Address_Address",
                schema: "HumanResources",
                table: "EmployeeAddress",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "FK_EmployeeAddress_Employee_Employee",
                schema: "HumanResources",
                table: "EmployeeAddress",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "FK_EmployeeDepartmentHistory_Department_Department",
                schema: "HumanResources",
                table: "EmployeeDepartmentHistory",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "FK_EmployeeDepartmentHistory_Employee_Employee",
                schema: "HumanResources",
                table: "EmployeeDepartmentHistory",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "FK_EmployeeDepartmentHistory_Shift_Shift",
                schema: "HumanResources",
                table: "EmployeeDepartmentHistory",
                column: "ShiftID");

            migrationBuilder.CreateIndex(
                name: "FK_EmployeePayHistory_Employee_Employee",
                schema: "HumanResources",
                table: "EmployeePayHistory",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "FK_Individual_Contact_Contact",
                schema: "Sales",
                table: "Individual",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "FK_Individual_Customer_Customer",
                schema: "Sales",
                table: "Individual",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "XMLVALUE_Individual_Demographics",
                schema: "Sales",
                table: "Individual",
                column: "Demographics");

            migrationBuilder.CreateIndex(
                name: "FK_JobCandidate_Employee_Employee",
                schema: "HumanResources",
                table: "JobCandidate",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_JobCandidate_EmployeeID1",
                schema: "HumanResources",
                table: "JobCandidate",
                column: "EmployeeID1");

            migrationBuilder.CreateIndex(
                name: "AK_Location_Name",
                schema: "Production",
                table: "Location",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Product_Name",
                schema: "Production",
                table: "Product",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Product_ProductNumber",
                schema: "Production",
                table: "Product",
                column: "ProductNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Product_rowguid",
                schema: "Production",
                table: "Product",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Product_ProductModel_ProductModel",
                schema: "Production",
                table: "Product",
                column: "ProductModelID");

            migrationBuilder.CreateIndex(
                name: "FK_Product_ProductSubcategory_ProductSubcategory",
                schema: "Production",
                table: "Product",
                column: "ProductSubcategoryID");

            migrationBuilder.CreateIndex(
                name: "FK_Product_UnitMeasureSize_UnitMeasure",
                schema: "Production",
                table: "Product",
                column: "SizeUnitMeasureCode");

            migrationBuilder.CreateIndex(
                name: "FK_Product_UnitMeasureWeight_UnitMeasure",
                schema: "Production",
                table: "Product",
                column: "WeightUnitMeasureCode");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductModelID1",
                schema: "Production",
                table: "Product",
                column: "ProductModelID1");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductSubcategoryID1",
                schema: "Production",
                table: "Product",
                column: "ProductSubcategoryID1");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UnitMeasureCode",
                schema: "Production",
                table: "Product",
                column: "UnitMeasureCode");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UnitMeasureCode1",
                schema: "Production",
                table: "Product",
                column: "UnitMeasureCode1");

            migrationBuilder.CreateIndex(
                name: "AK_ProductCategory_Name",
                schema: "Production",
                table: "ProductCategory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ProductCategory_rowguid",
                schema: "Production",
                table: "ProductCategory",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_ProductCostHistory_Product_Product",
                schema: "Production",
                table: "ProductCostHistory",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "AK_ProductDescription_rowguid",
                schema: "Production",
                table: "ProductDescription",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_ProductDocument_Document_Document",
                schema: "Production",
                table: "ProductDocument",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "FK_ProductDocument_Product_Product",
                schema: "Production",
                table: "ProductDocument",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "FK_ProductInventory_Location_Location",
                schema: "Production",
                table: "ProductInventory",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "FK_ProductInventory_Product_Product",
                schema: "Production",
                table: "ProductInventory",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "FK_ProductListPriceHistory_Product_Product",
                schema: "Production",
                table: "ProductListPriceHistory",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "AK_ProductModel_Name",
                schema: "Production",
                table: "ProductModel",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ProductModel_rowguid",
                schema: "Production",
                table: "ProductModel",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PXML_ProductModel_CatalogDescription",
                schema: "Production",
                table: "ProductModel",
                column: "CatalogDescription");

            migrationBuilder.CreateIndex(
                name: "PXML_ProductModel_Instructions",
                schema: "Production",
                table: "ProductModel",
                column: "Instructions");

            migrationBuilder.CreateIndex(
                name: "FK_ProductModelIllustration_Illustration_Illustration",
                schema: "Production",
                table: "ProductModelIllustration",
                column: "IllustrationID");

            migrationBuilder.CreateIndex(
                name: "FK_ProductModelIllustration_ProductModel_ProductModel",
                schema: "Production",
                table: "ProductModelIllustration",
                column: "ProductModelID");

            migrationBuilder.CreateIndex(
                name: "FK_ProductModelProductDescriptionCulture_Culture_Culture",
                schema: "Production",
                table: "ProductModelProductDescriptionCulture",
                column: "CultureID");

            migrationBuilder.CreateIndex(
                name: "FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescription",
                schema: "Production",
                table: "ProductModelProductDescriptionCulture",
                column: "ProductDescriptionID");

            migrationBuilder.CreateIndex(
                name: "FK_ProductModelProductDescriptionCulture_ProductModel_ProductModel",
                schema: "Production",
                table: "ProductModelProductDescriptionCulture",
                column: "ProductModelID");

            migrationBuilder.CreateIndex(
                name: "FK_ProductProductPhoto_Product_Product",
                schema: "Production",
                table: "ProductProductPhoto",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "FK_ProductProductPhoto_ProductPhoto_ProductPhoto",
                schema: "Production",
                table: "ProductProductPhoto",
                column: "ProductPhotoID");

            migrationBuilder.CreateIndex(
                name: "FK_ProductReview_Product_Product",
                schema: "Production",
                table: "ProductReview",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_ProductID_Name",
                schema: "Production",
                table: "ProductReview",
                columns: new[] { "ProductID", "ReviewerName" })
                .Annotation("SqlServer:Include", new[] { "Comments" });

            migrationBuilder.CreateIndex(
                name: "AK_ProductSubcategory_Name",
                schema: "Production",
                table: "ProductSubcategory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ProductSubcategory_rowguid",
                schema: "Production",
                table: "ProductSubcategory",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_ProductSubcategory_ProductCategory_ProductCategory",
                schema: "Production",
                table: "ProductSubcategory",
                column: "ProductCategoryID");

            migrationBuilder.CreateIndex(
                name: "FK_ProductVendor_Product_Product",
                schema: "Purchasing",
                table: "ProductVendor",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "FK_ProductVendor_UnitMeasure_UnitMeasure",
                schema: "Purchasing",
                table: "ProductVendor",
                column: "UnitMeasureCode");

            migrationBuilder.CreateIndex(
                name: "FK_ProductVendor_Vendor_Vendor",
                schema: "Purchasing",
                table: "ProductVendor",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "FK_PurchaseOrderDetail_Product_Product",
                schema: "Purchasing",
                table: "PurchaseOrderDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderHeader",
                schema: "Purchasing",
                table: "PurchaseOrderDetail",
                column: "PurchaseOrderID");

            migrationBuilder.CreateIndex(
                name: "FK_PurchaseOrderHeader_Employee_Employee",
                schema: "Purchasing",
                table: "PurchaseOrderHeader",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "FK_PurchaseOrderHeader_ShipMethod_ShipMethod",
                schema: "Purchasing",
                table: "PurchaseOrderHeader",
                column: "ShipMethodID");

            migrationBuilder.CreateIndex(
                name: "FK_PurchaseOrderHeader_Vendor_Vendor",
                schema: "Purchasing",
                table: "PurchaseOrderHeader",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "AK_SalesOrderDetail_rowguid",
                schema: "Sales",
                table: "SalesOrderDetail",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_SalesOrderDetail_SalesOrderHeader_SalesOrderHeader",
                schema: "Sales",
                table: "SalesOrderDetail",
                column: "SalesOrderID");

            migrationBuilder.CreateIndex(
                name: "FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferProduct",
                schema: "Sales",
                table: "SalesOrderDetail",
                columns: new[] { "ProductID", "SpecialOfferID" });

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetail_ProductID",
                schema: "Sales",
                table: "SalesOrderDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "AK_SalesOrderHeader_rowguid",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_SalesOrderHeader_SalesOrderNumber",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "SalesOrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_SalesOrderHeader_BillToAddress_Address",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "BillToAddressID");

            migrationBuilder.CreateIndex(
                name: "FK_SalesOrderHeader_Contact_Contact",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "FK_SalesOrderHeader_CreditCard_CreditCard",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "CreditCardID");

            migrationBuilder.CreateIndex(
                name: "FK_SalesOrderHeader_CurrencyRate_CurrencyRate",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "CurrencyRateID");

            migrationBuilder.CreateIndex(
                name: "FK_SalesOrderHeader_Customer_Customer",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "FK_SalesOrderHeader_SalesPerson_SalesPerson",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "SalesPersonID");

            migrationBuilder.CreateIndex(
                name: "FK_SalesOrderHeader_SalesTerritory_SalesTerritory",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "FK_SalesOrderHeader_ShipMethod_ShipMethod",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "ShipMethodID");

            migrationBuilder.CreateIndex(
                name: "FK_SalesOrderHeader_ShipToAddress_Address",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "ShipToAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_CreditCardID1",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "CreditCardID1");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_CurrencyRateID1",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "CurrencyRateID1");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_SalesPersonID1",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "SalesPersonID1");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_SalesTerritoryTerritoryID",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "SalesTerritoryTerritoryID");

            migrationBuilder.CreateIndex(
                name: "FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderHeader",
                schema: "Sales",
                table: "SalesOrderHeaderSalesReason",
                column: "SalesOrderID");

            migrationBuilder.CreateIndex(
                name: "FK_SalesOrderHeaderSalesReason_SalesReason_SalesReason",
                schema: "Sales",
                table: "SalesOrderHeaderSalesReason",
                column: "SalesReasonID");

            migrationBuilder.CreateIndex(
                name: "AK_SalesPerson_rowguid",
                schema: "Sales",
                table: "SalesPerson",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_SalesPerson_Employee_Employee",
                schema: "Sales",
                table: "SalesPerson",
                column: "SalesPersonID");

            migrationBuilder.CreateIndex(
                name: "FK_SalesPerson_SalesTerritory_SalesTerritory",
                schema: "Sales",
                table: "SalesPerson",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPerson_SalesTerritoryTerritoryID",
                schema: "Sales",
                table: "SalesPerson",
                column: "SalesTerritoryTerritoryID");

            migrationBuilder.CreateIndex(
                name: "AK_SalesPersonQuotaHistory_rowguid",
                schema: "Sales",
                table: "SalesPersonQuotaHistory",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_SalesPersonQuotaHistory_SalesPerson_SalesPerson",
                schema: "Sales",
                table: "SalesPersonQuotaHistory",
                column: "SalesPersonID");

            migrationBuilder.CreateIndex(
                name: "AK_SalesTaxRate_rowguid",
                schema: "Sales",
                table: "SalesTaxRate",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_SalesTaxRate_StateProvinceID_TaxType",
                schema: "Sales",
                table: "SalesTaxRate",
                columns: new[] { "StateProvinceID", "TaxType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_SalesTaxRate_StateProvince_StateProvince",
                schema: "Sales",
                table: "SalesTaxRate",
                column: "StateProvinceID");

            migrationBuilder.CreateIndex(
                name: "AK_SalesTerritory_Name",
                schema: "Sales",
                table: "SalesTerritory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_SalesTerritory_rowguid",
                schema: "Sales",
                table: "SalesTerritory",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_SalesTerritoryHistory_rowguid",
                schema: "Sales",
                table: "SalesTerritoryHistory",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_SalesTerritoryHistory_SalesPerson_SalesPerson",
                schema: "Sales",
                table: "SalesTerritoryHistory",
                column: "SalesPersonID");

            migrationBuilder.CreateIndex(
                name: "FK_SalesTerritoryHistory_SalesTerritory_SalesTerritory",
                schema: "Sales",
                table: "SalesTerritoryHistory",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "AK_ScrapReason_Name",
                schema: "Production",
                table: "ScrapReason",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Shift_Name",
                schema: "HumanResources",
                table: "Shift",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Shift_StartTime_EndTime",
                schema: "HumanResources",
                table: "Shift",
                columns: new[] { "EndTime", "StartTime" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ShipMethod_Name",
                schema: "Purchasing",
                table: "ShipMethod",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ShipMethod_rowguid",
                schema: "Purchasing",
                table: "ShipMethod",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_ShoppingCartItem_Product_Product",
                schema: "Sales",
                table: "ShoppingCartItem",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ShoppingCartID_ProductID",
                schema: "Sales",
                table: "ShoppingCartItem",
                columns: new[] { "ProductID", "ShoppingCartID" });

            migrationBuilder.CreateIndex(
                name: "AK_SpecialOffer_rowguid",
                schema: "Sales",
                table: "SpecialOffer",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_SpecialOfferProduct_rowguid",
                schema: "Sales",
                table: "SpecialOfferProduct",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_SpecialOfferProduct_Product_Product",
                schema: "Sales",
                table: "SpecialOfferProduct",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "FK_SpecialOfferProduct_SpecialOffer_SpecialOffer",
                schema: "Sales",
                table: "SpecialOfferProduct",
                column: "SpecialOfferID");

            migrationBuilder.CreateIndex(
                name: "AK_StateProvince_Name",
                schema: "Person",
                table: "StateProvince",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_StateProvince_rowguid",
                schema: "Person",
                table: "StateProvince",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_StateProvince_StateProvinceCode_CountryRegionCode",
                schema: "Person",
                table: "StateProvince",
                columns: new[] { "CountryRegionCode", "StateProvinceCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_StateProvince_CountryRegion_CountryRegion",
                schema: "Person",
                table: "StateProvince",
                column: "CountryRegionCode");

            migrationBuilder.CreateIndex(
                name: "FK_StateProvince_SalesTerritory_SalesTerritory",
                schema: "Person",
                table: "StateProvince",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "AK_Store_rowguid",
                schema: "Sales",
                table: "Store",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Store_Customer_Customer",
                schema: "Sales",
                table: "Store",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "FK_Store_SalesPerson_SalesPerson",
                schema: "Sales",
                table: "Store",
                column: "SalesPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_SalesPersonID1",
                schema: "Sales",
                table: "Store",
                column: "SalesPersonID1");

            migrationBuilder.CreateIndex(
                name: "PXML_Store_Demographics",
                schema: "Sales",
                table: "Store",
                column: "Demographics");

            migrationBuilder.CreateIndex(
                name: "AK_StoreContact_rowguid",
                schema: "Sales",
                table: "StoreContact",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_StoreContact_Contact_Contact",
                schema: "Sales",
                table: "StoreContact",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "FK_StoreContact_ContactType_ContactType",
                schema: "Sales",
                table: "StoreContact",
                column: "ContactTypeID");

            migrationBuilder.CreateIndex(
                name: "FK_StoreContact_Store_Store",
                schema: "Sales",
                table: "StoreContact",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "FK_TransactionHistory_Product_Product",
                schema: "Production",
                table: "TransactionHistory",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_ReferenceOrderID_ReferenceOrderLineID",
                schema: "Production",
                table: "TransactionHistory",
                columns: new[] { "ReferenceOrderID", "ReferenceOrderLineID" });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistoryArchive_ProductID",
                schema: "Production",
                table: "TransactionHistoryArchive",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistoryArchive_ReferenceOrderID_ReferenceOrderLineID",
                schema: "Production",
                table: "TransactionHistoryArchive",
                columns: new[] { "ReferenceOrderID", "ReferenceOrderLineID" });

            migrationBuilder.CreateIndex(
                name: "AK_UnitMeasure_Name",
                schema: "Production",
                table: "UnitMeasure",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Vendor_AccountNumber",
                schema: "Purchasing",
                table: "Vendor",
                column: "AccountNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_VendorAddress_Address_Address",
                schema: "Purchasing",
                table: "VendorAddress",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "FK_VendorAddress_AddressType_AddressType",
                schema: "Purchasing",
                table: "VendorAddress",
                column: "AddressTypeID");

            migrationBuilder.CreateIndex(
                name: "FK_VendorAddress_Vendor_Vendor",
                schema: "Purchasing",
                table: "VendorAddress",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "FK_VendorContact_Contact_Contact",
                schema: "Purchasing",
                table: "VendorContact",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "FK_VendorContact_ContactType_ContactType",
                schema: "Purchasing",
                table: "VendorContact",
                column: "ContactTypeID");

            migrationBuilder.CreateIndex(
                name: "FK_VendorContact_Vendor_Vendor",
                schema: "Purchasing",
                table: "VendorContact",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "FK_WorkOrder_Product_Product",
                schema: "Production",
                table: "WorkOrder",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "FK_WorkOrder_ScrapReason_ScrapReason",
                schema: "Production",
                table: "WorkOrder",
                column: "ScrapReasonID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_ScrapReasonID1",
                schema: "Production",
                table: "WorkOrder",
                column: "ScrapReasonID1");

            migrationBuilder.CreateIndex(
                name: "FK_WorkOrderRouting_Location_Location",
                schema: "Production",
                table: "WorkOrderRouting",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "FK_WorkOrderRouting_WorkOrder_WorkOrder",
                schema: "Production",
                table: "WorkOrderRouting",
                column: "WorkOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderRouting_ProductID",
                schema: "Production",
                table: "WorkOrderRouting",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AWBuildVersion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BillOfMaterials",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ContactCreditCard",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "CountryRegionCurrency",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "CustomerAddress",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "DatabaseLog",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeAddress",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "EmployeeDepartmentHistory",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "EmployeePayHistory",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "ErrorLog",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Individual",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "JobCandidate",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "ProductCostHistory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductDocument",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductInventory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductListPriceHistory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductModelIllustration",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductModelProductDescriptionCulture",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductProductPhoto",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductReview",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductVendor",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "PurchaseOrderDetail",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "SalesOrderDetail",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesOrderHeaderSalesReason",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesPersonQuotaHistory",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesTaxRate",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesTerritoryHistory",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "ShoppingCartItem",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "StoreContact",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "TransactionHistory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "TransactionHistoryArchive",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "VendorAddress",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "VendorContact",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "WorkOrderRouting",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "Shift",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "Document",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Illustration",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Culture",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductDescription",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductPhoto",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "PurchaseOrderHeader",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "SpecialOfferProduct",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesOrderHeader",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesReason",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Store",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "AddressType",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "ContactType",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "WorkOrder",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Vendor",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "SpecialOffer",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "CreditCard",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "CurrencyRate",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "ShipMethod",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesPerson",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ScrapReason",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "StateProvince",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "Currency",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "ProductModel",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductSubcategory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "UnitMeasure",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "CountryRegion",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "SalesTerritory",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Contact",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "Production");
        }
    }
}
