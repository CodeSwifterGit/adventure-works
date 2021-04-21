export interface ISalesReason {
  salesReasonID: number;
  name: string;
  reasonType: string;
  modifiedDate: Date | string;
}

export class SalesReason implements ISalesReason {
  salesReasonID: number;
  name: string;
  reasonType: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<SalesReason>) {
    if (!!init) {
      Object.assign<SalesReason, Partial<SalesReason>>(this, init);
    }
  }
}
