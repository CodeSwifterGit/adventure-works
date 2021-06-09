
export interface IBillOfMaterialsLookupModel {
  billOfMaterialsID: number;
  productAssemblyID: number | null;
  componentID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  unitMeasureCode: string;
  bOMLevel: number;
  perAssemblyQty: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class BillOfMaterialsLookupModel implements IBillOfMaterialsLookupModel {
  billOfMaterialsID: number;
  productAssemblyID: number | null;
  componentID: number;
  startDate: Date | string;
  endDate: Date | string | null;
  unitMeasureCode: string;
  bOMLevel: number;
  perAssemblyQty: number;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<BillOfMaterialsLookupModel>) {
    if (!!init) {
      Object.assign<BillOfMaterialsLookupModel, Partial<BillOfMaterialsLookupModel>>(this, init);
    }
  }
}
