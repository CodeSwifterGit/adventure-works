using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using AdventureWorks.Domain.Entities.Dbo;
using AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Domain.Entities.Person;
using AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Domain
{
    public interface IAdventureWorksContext
    {
        #region Entity Declarations
        DbSet<AWBuildVersion> AWBuildVersions { get; set; }
        DbSet<DatabaseLog> DatabaseLogs { get; set; }
        DbSet<ErrorLog> ErrorLogs { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
        DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }
        DbSet<EmployeePayHistory> EmployeePayHistories { get; set; }
        DbSet<JobCandidate> JobCandidates { get; set; }
        DbSet<Shift> Shifts { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<AddressType> AddressTypes { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<ContactType> ContactTypes { get; set; }
        DbSet<CountryRegion> CountryRegions { get; set; }
        DbSet<StateProvince> StateProvinces { get; set; }
        DbSet<BillOfMaterials> BillOfMaterials { get; set; }
        DbSet<Culture> Cultures { get; set; }
        DbSet<Document> Documents { get; set; }
        DbSet<Illustration> Illustrations { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductCategory> ProductCategories { get; set; }
        DbSet<ProductCostHistory> ProductCostHistories { get; set; }
        DbSet<ProductDescription> ProductDescriptions { get; set; }
        DbSet<ProductDocument> ProductDocuments { get; set; }
        DbSet<ProductInventory> ProductInventories { get; set; }
        DbSet<ProductListPriceHistory> ProductListPriceHistories { get; set; }
        DbSet<ProductModel> ProductModels { get; set; }
        DbSet<ProductModelIllustration> ProductModelIllustrations { get; set; }
        DbSet<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; }
        DbSet<ProductPhoto> ProductPhotos { get; set; }
        DbSet<ProductProductPhoto> ProductProductPhotos { get; set; }
        DbSet<ProductReview> ProductReviews { get; set; }
        DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        DbSet<ScrapReason> ScrapReasons { get; set; }
        DbSet<TransactionHistory> TransactionHistories { get; set; }
        DbSet<TransactionHistoryArchive> TransactionHistoryArchives { get; set; }
        DbSet<UnitMeasure> UnitMeasures { get; set; }
        DbSet<WorkOrder> WorkOrders { get; set; }
        DbSet<WorkOrderRouting> WorkOrderRoutings { get; set; }
        DbSet<ProductVendor> ProductVendors { get; set; }
        DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        DbSet<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }
        DbSet<ShipMethod> ShipMethods { get; set; }
        DbSet<Vendor> Vendors { get; set; }
        DbSet<VendorAddress> VendorAddresses { get; set; }
        DbSet<VendorContact> VendorContacts { get; set; }
        DbSet<ContactCreditCard> ContactCreditCards { get; set; }
        DbSet<CountryRegionCurrency> CountryRegionCurrencies { get; set; }
        DbSet<CreditCard> CreditCards { get; set; }
        DbSet<Currency> Currencies { get; set; }
        DbSet<CurrencyRate> CurrencyRates { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<CustomerAddress> CustomerAddresses { get; set; }
        DbSet<Individual> Individuals { get; set; }
        DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        DbSet<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; }
        DbSet<SalesPerson> SalesPeople { get; set; }
        DbSet<SalesPersonQuotaHistory> SalesPersonQuotaHistories { get; set; }
        DbSet<SalesReason> SalesReasons { get; set; }
        DbSet<SalesTaxRate> SalesTaxRates { get; set; }
        DbSet<SalesTerritory> SalesTerritories { get; set; }
        DbSet<SalesTerritoryHistory> SalesTerritoryHistories { get; set; }
        DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        DbSet<SpecialOffer> SpecialOffers { get; set; }
        DbSet<SpecialOfferProduct> SpecialOfferProducts { get; set; }
        DbSet<Store> Stores { get; set; }
        DbSet<StoreContact> StoreContacts { get; set; }
        #endregion

        #region Supporting Methods
        DatabaseFacade Database { get; }
        ChangeTracker ChangeTracker { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken);
        int SaveChanges();
        int SaveChanges(bool saveChanges);
        EntityEntry Attach(object entity);
        EntityEntry Update(object entity);
        EntityEntry Remove(object entity);
        void AddRange(params object[] entities);
        Task AddRangeAsync(params object[] entities);
        void AttachRange(params object[] entities);
        void UpdateRange(params object[] entities);
        void RemoveRange(params object[] entities);
        void AddRange(IEnumerable<object> entities);
        Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken);
        void AttachRange(IEnumerable<object> entities);
        EntityEntry<TEntity> Entry<TEntity>([NotNull] TEntity entity) where TEntity : class;
        EntityEntry Entry([NotNull] object entity);
        void UpdateRange(IEnumerable<object> entities);
        void RemoveRange(IEnumerable<object> entities);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        void SetAutoDetectChanges(bool enabled);
        #endregion

        #region Upgrade Database

        void UpgradeDatabase();

        #endregion
    }
}