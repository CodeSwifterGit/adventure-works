
export interface IShiftLookupModel {
  shiftID: number;
  name: string;
  startTime: Date | string;
  endTime: Date | string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ShiftLookupModel implements IShiftLookupModel {
  shiftID: number;
  name: string;
  startTime: Date | string;
  endTime: Date | string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ShiftLookupModel>) {
    if (!!init) {
      Object.assign<ShiftLookupModel, Partial<ShiftLookupModel>>(this, init);
    }
  }
}
