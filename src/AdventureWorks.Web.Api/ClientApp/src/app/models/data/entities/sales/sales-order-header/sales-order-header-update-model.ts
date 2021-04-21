import { IAddressUpdateModel } from 'app/models/data/entities/person/address/address-update-model';
import { IContactUpdateModel } from 'app/models/data/entities/person/contact/contact-update-model';
import { ICreditCardUpdateModel } from 'app/models/data/entities/sales/credit-card/credit-card-update-model';
import { ICurrencyRateUpdateModel } from 'app/models/data/entities/sales/currency-rate/currency-rate-update-model';
import { ICustomerUpdateModel } from 'app/models/data/entities/sales/customer/customer-update-model';
import { ISalesOrderDetailUpdateModel } from 'app/models/data/entities/sales/sales-order-detail/sales-order-detail-update-model';
import { ISalesOrderHeaderSalesReasonUpdateModel } from 'app/models/data/entities/sales/sales-order-header-sales-reason/sales-order-header-sales-reason-update-model';
import { ISalesPersonUpdateModel } from 'app/models/data/entities/sales/sales-person/sales-person-update-model';
import { ISalesTerritoryUpdateModel } from 'app/models/data/entities/sales/sales-territory/sales-territory-update-model';
import { IShipMethodUpdateModel } from 'app/models/data/entities/purchasing/ship-method/ship-method-update-model';

export interface ISalesOrderHeaderUpdateModel {
  salesOrderID: number;
  revisionNumber: number;
  orderDate: Date | string;
  dueDate: Date | string;
  shipDate: Date | string | null;
  status: number;
  onlineOrderFlag: boolean;
  salesOrderNumber: string;
  purchaseOrderNumber: string;
  accountNumber: string;
  customerID: number;
  contactID: number;
  salesPersonID: number | null;
  territoryID: number | null;
  billToAddressID: number;
  shipToAddressID: number;
  shipMethodID: number;
  creditCardID: number | null;
  creditCardApprovalCode: string;
  currencyRateID: number | null;
  subTotal: number;
  taxAmt: number;
  freight: number;
  totalDue: number;
  comment: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class SalesOrderHeaderUpdateModel implements ISalesOrderHeaderUpdateModel {
  salesOrderID: number;
  revisionNumber: number;
  orderDate: Date | string;
  dueDate: Date | string;
  shipDate: Date | string | null;
  status: number;
  onlineOrderFlag: boolean;
  salesOrderNumber: string;
  purchaseOrderNumber: string;
  accountNumber: string;
  customerID: number;
  contactID: number;
  salesPersonID: number | null;
  territoryID: number | null;
  billToAddressID: number;
  shipToAddressID: number;
  shipMethodID: number;
  creditCardID: number | null;
  creditCardApprovalCode: string;
  currencyRateID: number | null;
  subTotal: number;
  taxAmt: number;
  freight: number;
  totalDue: number;
  comment: string;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<SalesOrderHeaderUpdateModel>) {
    if (!!init) {
      Object.assign<SalesOrderHeaderUpdateModel, Partial<SalesOrderHeaderUpdateModel>>(this, init);
    }
  }
}
