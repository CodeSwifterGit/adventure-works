export interface ISalesTerritory {
  territoryID: number;
  name: string;
  countryRegionCode: string;
  group: string;
  salesYTD: number;
  salesLastYear: number;
  costYTD: number;
  costLastYear: number;
  rowguid: string;
  modifiedDate: Date | string;
}

export class SalesTerritory implements ISalesTerritory {
  territoryID: number;
  name: string;
  countryRegionCode: string;
  group: string;
  salesYTD: number;
  salesLastYear: number;
  costYTD: number;
  costLastYear: number;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<SalesTerritory>) {
    if (!!init) {
      Object.assign<SalesTerritory, Partial<SalesTerritory>>(this, init);
    }
  }
}
