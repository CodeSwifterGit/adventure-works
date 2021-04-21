export interface ILocation {
  locationID: number;
  name: string;
  costRate: number;
  availability: number;
  modifiedDate: Date | string;
}

export class Location implements ILocation {
  locationID: number;
  name: string;
  costRate: number;
  availability: number;
  modifiedDate: Date | string;

  constructor(init?: Partial<Location>) {
    if (!!init) {
      Object.assign<Location, Partial<Location>>(this, init);
    }
  }
}
