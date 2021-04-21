import { IProductVendorLookupModel } from 'app/models/data/entities/purchasing/product-vendor/product-vendor-lookup-model';
import { IPurchaseOrderHeaderLookupModel } from 'app/models/data/entities/purchasing/purchase-order-header/purchase-order-header-lookup-model';
import { IVendorAddressLookupModel } from 'app/models/data/entities/purchasing/vendor-address/vendor-address-lookup-model';
import { IVendorContactLookupModel } from 'app/models/data/entities/purchasing/vendor-contact/vendor-contact-lookup-model';

export interface IVendorLookupModel {
  vendorID: number;
  accountNumber: string;
  name: string;
  creditRating: number;
  preferredVendorStatus: boolean;
  activeFlag: boolean;
  purchasingWebServiceURL: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class VendorLookupModel implements IVendorLookupModel {
  vendorID: number;
  accountNumber: string;
  name: string;
  creditRating: number;
  preferredVendorStatus: boolean;
  activeFlag: boolean;
  purchasingWebServiceURL: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<VendorLookupModel>) {
    if (!!init) {
      Object.assign<VendorLookupModel, Partial<VendorLookupModel>>(this, init);
    }
  }
}
