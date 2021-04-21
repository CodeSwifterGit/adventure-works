export interface ITransactionHistory {
  transactionID: number;
  productID: number;
  referenceOrderID: number;
  referenceOrderLineID: number;
  transactionDate: Date | string;
  transactionType: string;
  quantity: number;
  actualCost: number;
  modifiedDate: Date | string;
}

export class TransactionHistory implements ITransactionHistory {
  transactionID: number;
  productID: number;
  referenceOrderID: number;
  referenceOrderLineID: number;
  transactionDate: Date | string;
  transactionType: string;
  quantity: number;
  actualCost: number;
  modifiedDate: Date | string;

  constructor(init?: Partial<TransactionHistory>) {
    if (!!init) {
      Object.assign<TransactionHistory, Partial<TransactionHistory>>(this, init);
    }
  }
}
