
export interface IIllustrationUpdateModel {
  illustrationID: number;
  diagram: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class IllustrationUpdateModel implements IIllustrationUpdateModel {
  illustrationID: number;
  diagram: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<IllustrationUpdateModel>) {
    if (!!init) {
      Object.assign<IllustrationUpdateModel, Partial<IllustrationUpdateModel>>(this, init);
    }
  }
}
