
export interface ISalesTerritoryLookupModel {
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

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class SalesTerritoryLookupModel implements ISalesTerritoryLookupModel {
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

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<SalesTerritoryLookupModel>) {
    if (!!init) {
      Object.assign<SalesTerritoryLookupModel, Partial<SalesTerritoryLookupModel>>(this, init);
    }
  }
}
