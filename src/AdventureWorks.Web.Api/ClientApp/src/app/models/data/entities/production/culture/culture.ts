export interface ICulture {
  cultureID: string;
  name: string;
  modifiedDate: Date | string;
}

export class Culture implements ICulture {
  cultureID: string;
  name: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<Culture>) {
    if (!!init) {
      Object.assign<Culture, Partial<Culture>>(this, init);
    }
  }
}
