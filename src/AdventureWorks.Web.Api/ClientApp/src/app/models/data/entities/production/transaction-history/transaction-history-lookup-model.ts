import { IProductLookupModel } from 'app/models/data/entities/production/product/product-lookup-model';

export interface ITransactionHistoryLookupModel {
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

export class TransactionHistoryLookupModel implements ITransactionHistoryLookupModel {
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

  constructor(init?: Partial<TransactionHistoryLookupModel>) {
    if (!!init) {
      Object.assign<TransactionHistoryLookupModel, Partial<TransactionHistoryLookupModel>>(this, init);
    }
  }
}
