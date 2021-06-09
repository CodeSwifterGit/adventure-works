
export interface IScrapReasonLookupModel {
  scrapReasonID: number;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ScrapReasonLookupModel implements IScrapReasonLookupModel {
  scrapReasonID: number;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ScrapReasonLookupModel>) {
    if (!!init) {
      Object.assign<ScrapReasonLookupModel, Partial<ScrapReasonLookupModel>>(this, init);
    }
  }
}
