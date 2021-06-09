
export interface IShiftUpdateModel {
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

export class ShiftUpdateModel implements IShiftUpdateModel {
  shiftID: number;
  name: string;
  startTime: Date | string;
  endTime: Date | string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ShiftUpdateModel>) {
    if (!!init) {
      Object.assign<ShiftUpdateModel, Partial<ShiftUpdateModel>>(this, init);
    }
  }
}
