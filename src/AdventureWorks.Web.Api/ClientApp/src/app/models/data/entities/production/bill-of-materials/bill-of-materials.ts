export interface IBillOfMaterials {
  billOfMaterialsID: number;
  productAssemblyID: number | null;
  componentID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  unitMeasureCode: string;
  bOMLevel: number;
  perAssemblyQty: number;
  modifiedDate: Date | string;
}

export class BillOfMaterials implements IBillOfMaterials {
  billOfMaterialsID: number;
  productAssemblyID: number | null;
  componentID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  unitMeasureCode: string;
  bOMLevel: number;
  perAssemblyQty: number;
  modifiedDate: Date | string;

  constructor(init?: Partial<BillOfMaterials>) {
    if (!!init) {
      Object.assign<BillOfMaterials, Partial<BillOfMaterials>>(this, init);
    }
  }
}
