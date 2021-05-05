using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductPhoto.Commands.UpdateProductPhoto;
using AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.GetProductPhotos;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using AdventureWorks.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.QueryManager
{
    public partial class ProductPhotosQueryManager : DynamicQueryManager<Entities.ProductPhoto, ProductPhotoLookupModel, ProductPhotoSummary, UpdateProductPhotoCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<ProductPhotosQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;
        private readonly IDateTime _machineDateTime;
        private readonly INotificationService _notificationService;

        public ProductPhotosQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<ProductPhotosQueryManager> logger, INotificationService notificationService, IDateTime machineDateTime) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
            _machineDateTime = machineDateTime;
            _notificationService = notificationService;
        }

        public override async Task<List<ProductPhotoLookupModel>> RequestData(
            IQueryable<Entities.ProductPhoto> query,
            DataTableInfo<ProductPhotoSummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new ProductPhotoSummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}