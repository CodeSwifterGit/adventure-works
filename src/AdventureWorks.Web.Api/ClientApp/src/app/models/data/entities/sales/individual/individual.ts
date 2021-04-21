export interface IIndividual {
  customerID: number;
  contactID: number;
  demographics: string;
  modifiedDate: Date | string;
}

export class Individual implements IIndividual {
  customerID: number;
  contactID: number;
  demographics: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<Individual>) {
    if (!!init) {
      Object.assign<Individual, Partial<Individual>>(this, init);
    }
  }
}
