export interface ISalesOrderHeader {
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
}

export class SalesOrderHeader implements ISalesOrderHeader {
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

  constructor(init?: Partial<SalesOrderHeader>) {
    if (!!init) {
      Object.assign<SalesOrderHeader, Partial<SalesOrderHeader>>(this, init);
    }
  }
}
