export interface IScrapReason {
  scrapReasonID: number;
  name: string;
  modifiedDate: Date | string;
}

export class ScrapReason implements IScrapReason {
  scrapReasonID: number;
  name: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<ScrapReason>) {
    if (!!init) {
      Object.assign<ScrapReason, Partial<ScrapReason>>(this, init);
    }
  }
}
