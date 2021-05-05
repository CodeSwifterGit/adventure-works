using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Commands.UpdateProductProductPhoto;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.GetProductProductPhotos;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Services;
using AdventureWorks.Domain;
using AdventureWorks.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.QueryManager
{
    public partial class ProductProductPhotosQueryManager : DynamicQueryManager<Entities.ProductProductPhoto, ProductProductPhotoLookupModel, ProductProductPhotoSummary, UpdateProductProductPhotoCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ILogger<ProductProductPhotosQueryManager> _logger;
        private readonly IFileStorageService _fileStorageService;
        private readonly IDateTime _machineDateTime;
        private readonly INotificationService _notificationService;

        public ProductProductPhotosQueryManager(IAdventureWorksContext context, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IFileStorageService fileStorageService,
            ILogger<ProductProductPhotosQueryManager> logger, INotificationService notificationService, IDateTime machineDateTime) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
            _fileStorageService = fileStorageService;
            _logger = logger;
            _machineDateTime = machineDateTime;
            _notificationService = notificationService;
        }

        public override async Task<List<ProductProductPhotoLookupModel>> RequestData(
            IQueryable<Entities.ProductProductPhoto> query,
            DataTableInfo<ProductProductPhotoSummary> dataTable,
            CancellationToken cancellationToken)
        {
            query = FilterData(query, dataTable);
            query = SortData(query, dataTable);

            if (dataTable != null)
                dataTable.SummaryInfo = query
                    .GroupBy(s => 0)
                    .Select(s => new ProductProductPhotoSummary()
                    {

                    }).FirstOrDefault();

            return await GetResult(query, dataTable, cancellationToken);
        }
    }
}