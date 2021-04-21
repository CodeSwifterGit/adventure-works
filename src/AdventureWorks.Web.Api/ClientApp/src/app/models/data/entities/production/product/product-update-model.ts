import { IBillOfMaterialsUpdateModel } from 'app/models/data/entities/production/bill-of-materials/bill-of-materials-update-model';
import { IProductCostHistoryUpdateModel } from 'app/models/data/entities/production/product-cost-history/product-cost-history-update-model';
import { IProductDocumentUpdateModel } from 'app/models/data/entities/production/product-document/product-document-update-model';
import { IProductInventoryUpdateModel } from 'app/models/data/entities/production/product-inventory/product-inventory-update-model';
import { IProductListPriceHistoryUpdateModel } from 'app/models/data/entities/production/product-list-price-history/product-list-price-history-update-model';
import { IProductModelUpdateModel } from 'app/models/data/entities/production/product-model/product-model-update-model';
import { IProductProductPhotoUpdateModel } from 'app/models/data/entities/production/product-product-photo/product-product-photo-update-model';
import { IProductReviewUpdateModel } from 'app/models/data/entities/production/product-review/product-review-update-model';
import { IProductSubcategoryUpdateModel } from 'app/models/data/entities/production/product-subcategory/product-subcategory-update-model';
import { IProductVendorUpdateModel } from 'app/models/data/entities/purchasing/product-vendor/product-vendor-update-model';
import { IPurchaseOrderDetailUpdateModel } from 'app/models/data/entities/purchasing/purchase-order-detail/purchase-order-detail-update-model';
import { IShoppingCartItemUpdateModel } from 'app/models/data/entities/sales/shopping-cart-item/shopping-cart-item-update-model';
import { ISpecialOfferProductUpdateModel } from 'app/models/data/entities/sales/special-offer-product/special-offer-product-update-model';
import { ITransactionHistoryUpdateModel } from 'app/models/data/entities/production/transaction-history/transaction-history-update-model';
import { IUnitMeasureUpdateModel } from 'app/models/data/entities/production/unit-measure/unit-measure-update-model';
import { IWorkOrderUpdateModel } from 'app/models/data/entities/production/work-order/work-order-update-model';

export interface IProductUpdateModel {
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

export class ProductUpdateModel implements IProductUpdateModel {
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

  constructor(init?: Partial<ProductUpdateModel>) {
    if (!!init) {
      Object.assign<ProductUpdateModel, Partial<ProductUpdateModel>>(this, init);
    }
  }
}
