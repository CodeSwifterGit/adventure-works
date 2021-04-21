export interface IUnitMeasure {
  unitMeasureCode: string;
  name: string;
  modifiedDate: Date | string;
}

export class UnitMeasure implements IUnitMeasure {
  unitMeasureCode: string;
  name: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<UnitMeasure>) {
    if (!!init) {
      Object.assign<UnitMeasure, Partial<UnitMeasure>>(this, init);
    }
  }
}
