import { IBillOfMaterialsLookupModel } from 'app/models/data/entities/production/bill-of-materials/bill-of-materials-lookup-model';
import { IProductCostHistoryLookupModel } from 'app/models/data/entities/production/product-cost-history/product-cost-history-lookup-model';
import { IProductDocumentLookupModel } from 'app/models/data/entities/production/product-document/product-document-lookup-model';
import { IProductInventoryLookupModel } from 'app/models/data/entities/production/product-inventory/product-inventory-lookup-model';
import { IProductListPriceHistoryLookupModel } from 'app/models/data/entities/production/product-list-price-history/product-list-price-history-lookup-model';
import { IProductModelLookupModel } from 'app/models/data/entities/production/product-model/product-model-lookup-model';
import { IProductProductPhotoLookupModel } from 'app/models/data/entities/production/product-product-photo/product-product-photo-lookup-model';
import { IProductReviewLookupModel } from 'app/models/data/entities/production/product-review/product-review-lookup-model';
import { IProductSubcategoryLookupModel } from 'app/models/data/entities/production/product-subcategory/product-subcategory-lookup-model';
import { IProductVendorLookupModel } from 'app/models/data/entities/purchasing/product-vendor/product-vendor-lookup-model';
import { IPurchaseOrderDetailLookupModel } from 'app/models/data/entities/purchasing/purchase-order-detail/purchase-order-detail-lookup-model';
import { IShoppingCartItemLookupModel } from 'app/models/data/entities/sales/shopping-cart-item/shopping-cart-item-lookup-model';
import { ISpecialOfferProductLookupModel } from 'app/models/data/entities/sales/special-offer-product/special-offer-product-lookup-model';
import { ITransactionHistoryLookupModel } from 'app/models/data/entities/production/transaction-history/transaction-history-lookup-model';
import { IUnitMeasureLookupModel } from 'app/models/data/entities/production/unit-measure/unit-measure-lookup-model';
import { IWorkOrderLookupModel } from 'app/models/data/entities/production/work-order/work-order-lookup-model';

export interface IProductLookupModel {
  productID: number;
  name: string;
  productNumber: string;
  makeFlag: boolean;
  finishedGoodsFlag: boolean;
  color: string;
  safetyStockLevel: number;
  reorderPoint: number;
  standardCost: number;
  listPrice: number;
  size: string;
  sizeUnitMeasureCode: string;
  weightUnitMeasureCode: string;
  weight: number | null;
  daysToManufacture: number;
  productLine: string;
  class: string;
  style: string;
  productSubcategoryID: number | null;
  productModelID: number | null;
  sellStartDate: Date | string;
  sellEndDate: Date | string | null;
  discontinuedDate: Date | string | null;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductLookupModel implements IProductLookupModel {
  productID: number;
  name: string;
  productNumber: string;
  makeFlag: boolean;
  finishedGoodsFlag: boolean;
  color: string;
  safetyStockLevel: number;
  reorderPoint: number;
  standardCost: number;
  listPrice: number;
  size: string;
  sizeUnitMeasureCode: string;
  weightUnitMeasureCode: string;
  weight: number | null;
  daysToManufacture: number;
  productLine: string;
  class: string;
  style: string;
  productSubcategoryID: number | null;
  productModelID: number | null;
  sellStartDate: Date | string;
  sellEndDate: Date | string | null;
  discontinuedDate: Date | string | null;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductLookupModel>) {
    if (!!init) {
      Object.assign<ProductLookupModel, Partial<ProductLookupModel>>(this, init);
    }
  }
}
