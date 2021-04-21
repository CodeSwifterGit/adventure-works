export interface IShift {
  shiftID: number;
  name: string;
  startTime: Date | string;
  endTime: Date | string;
  modifiedDate: Date | string;
}

export class Shift implements IShift {
  shiftID: number;
  name: string;
  startTime: Date | string;
  endTime: Date | string;
  modifiedDate: Date | string;

  constructor(init?: Partial<Shift>) {
    if (!!init) {
      Object.assign<Shift, Partial<Shift>>(this, init);
    }
  }
}
