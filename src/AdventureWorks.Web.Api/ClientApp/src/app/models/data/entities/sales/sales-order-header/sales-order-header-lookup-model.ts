import { IAddressLookupModel } from 'app/models/data/entities/person/address/address-lookup-model';
import { IContactLookupModel } from 'app/models/data/entities/person/contact/contact-lookup-model';
import { ICreditCardLookupModel } from 'app/models/data/entities/sales/credit-card/credit-card-lookup-model';
import { ICurrencyRateLookupModel } from 'app/models/data/entities/sales/currency-rate/currency-rate-lookup-model';
import { ICustomerLookupModel } from 'app/models/data/entities/sales/customer/customer-lookup-model';
import { ISalesOrderDetailLookupModel } from 'app/models/data/entities/sales/sales-order-detail/sales-order-detail-lookup-model';
import { ISalesOrderHeaderSalesReasonLookupModel } from 'app/models/data/entities/sales/sales-order-header-sales-reason/sales-order-header-sales-reason-lookup-model';
import { ISalesPersonLookupModel } from 'app/models/data/entities/sales/sales-person/sales-person-lookup-model';
import { ISalesTerritoryLookupModel } from 'app/models/data/entities/sales/sales-territory/sales-territory-lookup-model';
import { IShipMethodLookupModel } from 'app/models/data/entities/purchasing/ship-method/ship-method-lookup-model';

export interface ISalesOrderHeaderLookupModel {
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

export class SalesOrderHeaderLookupModel implements ISalesOrderHeaderLookupModel {
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

  constructor(init?: Partial<SalesOrderHeaderLookupModel>) {
    if (!!init) {
      Object.assign<SalesOrderHeaderLookupModel, Partial<SalesOrderHeaderLookupModel>>(this, init);
    }
  }
}
