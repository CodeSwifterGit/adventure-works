
export interface IStateProvinceLookupModel {
  stateProvinceID: number;
  stateProvinceCode: string;
  countryRegionCode: string;
  isOnlyStateProvinceFlag: boolean;
  name: string;
  territoryID: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class StateProvinceLookupModel implements IStateProvinceLookupModel {
  stateProvinceID: number;
  stateProvinceCode: string;
  countryRegionCode: string;
  isOnlyStateProvinceFlag: boolean;
  name: string;
  territoryID: number;
  rowguid: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<StateProvinceLookupModel>) {
    if (!!init) {
      Object.assign<StateProvinceLookupModel, Partial<StateProvinceLookupModel>>(this, init);
    }
  }
}
