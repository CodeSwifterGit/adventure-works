import { IEmployeeUpdateModel } from 'app/models/data/entities/human-resources/employee/employee-update-model';
import { IPurchaseOrderDetailUpdateModel } from 'app/models/data/entities/purchasing/purchase-order-detail/purchase-order-detail-update-model';
import { IShipMethodUpdateModel } from 'app/models/data/entities/purchasing/ship-method/ship-method-update-model';
import { IVendorUpdateModel } from 'app/models/data/entities/purchasing/vendor/vendor-update-model';

export interface IPurchaseOrderHeaderUpdateModel {
  purchaseOrderID: number;
  revisionNumber: number;
  status: number;
  employeeID: number;
  vendorID: number;
  shipMethodID: number;
  orderDate: Date | string;
  shipDate: Date | string | null;
  subTotal: number;
  taxAmt: number;
  freight: number;
  totalDue: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class PurchaseOrderHeaderUpdateModel implements IPurchaseOrderHeaderUpdateModel {
  purchaseOrderID: number;
  revisionNumber: number;
  status: number;
  employeeID: number;
  vendorID: number;
  shipMethodID: number;
  orderDate: Date | string;
  shipDate: Date | string | null;
  subTotal: number;
  taxAmt: number;
  freight: number;
  totalDue: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<PurchaseOrderHeaderUpdateModel>) {
    if (!!init) {
      Object.assign<PurchaseOrderHeaderUpdateModel, Partial<PurchaseOrderHeaderUpdateModel>>(this, init);
    }
  }
}
