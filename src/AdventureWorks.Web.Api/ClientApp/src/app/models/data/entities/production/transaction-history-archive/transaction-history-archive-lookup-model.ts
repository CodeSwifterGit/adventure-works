export interface ITransactionHistoryArchiveLookupModel {
  transactionID: number;
  productID: number;
  referenceOrderID: number;
  referenceOrderLineID: number;
  transactionDate: Date | string;
  transactionType: string;
  quantity: number;
  actualCost: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class TransactionHistoryArchiveLookupModel implements ITransactionHistoryArchiveLookupModel {
  transactionID: number;
  productID: number;
  referenceOrderID: number;
  referenceOrderLineID: number;
  transactionDate: Date | string;
  transactionType: string;
  quantity: number;
  actualCost: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<TransactionHistoryArchiveLookupModel>) {
    if (!!init) {
      Object.assign<TransactionHistoryArchiveLookupModel, Partial<TransactionHistoryArchiveLookupModel>>(this, init);
    }
  }
}
