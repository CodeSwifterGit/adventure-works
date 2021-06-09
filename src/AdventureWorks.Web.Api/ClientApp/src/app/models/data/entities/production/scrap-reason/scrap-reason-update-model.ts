
export interface IScrapReasonUpdateModel {
  scrapReasonID: number;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ScrapReasonUpdateModel implements IScrapReasonUpdateModel {
  scrapReasonID: number;
  name: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ScrapReasonUpdateModel>) {
    if (!!init) {
      Object.assign<ScrapReasonUpdateModel, Partial<ScrapReasonUpdateModel>>(this, init);
    }
  }
}
