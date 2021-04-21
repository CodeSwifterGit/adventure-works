import { ICustomerAddressLookupModel } from 'app/models/data/entities/sales/customer-address/customer-address-lookup-model';
import { IIndividualLookupModel } from 'app/models/data/entities/sales/individual/individual-lookup-model';
import { ISalesOrderHeaderLookupModel } from 'app/models/data/entities/sales/sales-order-header/sales-order-header-lookup-model';
import { ISalesTerritoryLookupModel } from 'app/models/data/entities/sales/sales-territory/sales-territory-lookup-model';
import { IStoreLookupModel } from 'app/models/data/entities/sales/store/store-lookup-model';

export interface ICustomerLookupModel {
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

export class CustomerLookupModel implements ICustomerLookupModel {
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

  constructor(init?: Partial<CustomerLookupModel>) {
    if (!!init) {
      Object.assign<CustomerLookupModel, Partial<CustomerLookupModel>>(this, init);
    }
  }
}
