export interface IStateProvince {
  stateProvinceID: number;
  stateProvinceCode: string;
  countryRegionCode: string;
  isOnlyStateProvinceFlag: boolean;
  name: string;
  territoryID: number;
  rowguid: string;
  modifiedDate: Date | string;
}

export class StateProvince implements IStateProvince {
  stateProvinceID: number;
  stateProvinceCode: string;
  countryRegionCode: string;
  isOnlyStateProvinceFlag: boolean;
  name: string;
  territoryID: number;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<StateProvince>) {
    if (!!init) {
      Object.assign<StateProvince, Partial<StateProvince>>(this, init);
    }
  }
}
