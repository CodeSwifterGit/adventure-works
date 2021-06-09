
export interface ILocationLookupModel {
  locationID: number;
  name: string;
  costRate: number;
  availability: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class LocationLookupModel implements ILocationLookupModel {
  locationID: number;
  name: string;
  costRate: number;
  availability: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<LocationLookupModel>) {
    if (!!init) {
      Object.assign<LocationLookupModel, Partial<LocationLookupModel>>(this, init);
    }
  }
}
