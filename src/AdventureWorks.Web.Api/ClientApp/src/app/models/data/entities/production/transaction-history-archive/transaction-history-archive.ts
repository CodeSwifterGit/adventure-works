export interface ITransactionHistoryArchive {
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

export class TransactionHistoryArchive implements ITransactionHistoryArchive {
  transactionID: number;
  productID: number;
  referenceOrderID: number;
  referenceOrderLineID: number;
  transactionDate: Date | string;
  transactionType: string;
  quantity: number;
  actualCost: number;
  modifiedDate: Date | string;

  constructor(init?: Partial<TransactionHistoryArchive>) {
    if (!!init) {
      Object.assign<TransactionHistoryArchive, Partial<TransactionHistoryArchive>>(this, init);
    }
  }
}
