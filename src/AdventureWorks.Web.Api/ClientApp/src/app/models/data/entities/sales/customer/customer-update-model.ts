import { ICustomerAddressUpdateModel } from 'app/models/data/entities/sales/customer-address/customer-address-update-model';
import { IIndividualUpdateModel } from 'app/models/data/entities/sales/individual/individual-update-model';
import { ISalesOrderHeaderUpdateModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-update-model';
import { ISalesTerritoryUpdateModel } from 'app/models/data/entities/sales/sales-territory/sales-territory-update-model';
import { IStoreUpdateModel } from 'app/models/data/entities/sales/store/store-update-model';

export interface ICustomerUpdateModel {
  customerID: number;
  territoryID: number | null;
  accountNumber: string;
  customerType: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class CustomerUpdateModel implements ICustomerUpdateModel {
  customerID: number;
  territoryID: number | null;
  accountNumber: string;
  customerType: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<CustomerUpdateModel>) {
    if (!!init) {
      Object.assign<CustomerUpdateModel, Partial<CustomerUpdateModel>>(this, init);
    }
  }
}
