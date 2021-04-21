import { IProductVendorUpdateModel } from 'app/models/data/entities/purchasing/product-vendor/product-vendor-update-model';
import { IPurchaseOrderHeaderUpdateModel } from 'app/models/data/entities/purchasing/purchase-order-header/purchase-order-header-update-model';
import { IVendorAddressUpdateModel } from 'app/models/data/entities/purchasing/vendor-address/vendor-address-update-model';
import { IVendorContactUpdateModel } from 'app/models/data/entities/purchasing/vendor-contact/vendor-contact-update-model';

export interface IVendorUpdateModel {
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

export class VendorUpdateModel implements IVendorUpdateModel {
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

  constructor(init?: Partial<VendorUpdateModel>) {
    if (!!init) {
      Object.assign<VendorUpdateModel, Partial<VendorUpdateModel>>(this, init);
    }
  }
}
