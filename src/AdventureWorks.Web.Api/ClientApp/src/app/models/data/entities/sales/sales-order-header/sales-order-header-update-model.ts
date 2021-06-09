
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
