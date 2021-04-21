export interface IContactType {
  contactTypeID: number;
  name: string;
  modifiedDate: Date | string;
}

export class ContactType implements IContactType {
  contactTypeID: number;
  name: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<ContactType>) {
    if (!!init) {
      Object.assign<ContactType, Partial<ContactType>>(this, init);
    }
  }
}
