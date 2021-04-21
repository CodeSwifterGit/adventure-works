export interface IIllustration {
  illustrationID: number;
  diagram: string;
  modifiedDate: Date | string;
}

export class Illustration implements IIllustration {
  illustrationID: number;
  diagram: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<Illustration>) {
    if (!!init) {
      Object.assign<Illustration, Partial<Illustration>>(this, init);
    }
  }
}
