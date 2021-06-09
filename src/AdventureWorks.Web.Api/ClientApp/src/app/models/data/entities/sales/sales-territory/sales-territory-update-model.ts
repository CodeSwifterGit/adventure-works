
export interface ISalesTerritoryUpdateModel {
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

export class SalesTerritoryUpdateModel implements ISalesTerritoryUpdateModel {
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

  constructor(init?: Partial<SalesTerritoryUpdateModel>) {
    if (!!init) {
      Object.assign<SalesTerritoryUpdateModel, Partial<SalesTerritoryUpdateModel>>(this, init);
    }
  }
}
