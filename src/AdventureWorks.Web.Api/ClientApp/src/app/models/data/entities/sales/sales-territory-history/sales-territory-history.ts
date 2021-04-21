export interface ISalesTerritoryHistory {
  salesPersonID: number;
  territoryID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  rowguid: string;
  modifiedDate: Date | string;
}

export class SalesTerritoryHistory implements ISalesTerritoryHistory {
  salesPersonID: number;
  territoryID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  rowguid: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<SalesTerritoryHistory>) {
    if (!!init) {
      Object.assign<SalesTerritoryHistory, Partial<SalesTerritoryHistory>>(this, init);
    }
  }
}
