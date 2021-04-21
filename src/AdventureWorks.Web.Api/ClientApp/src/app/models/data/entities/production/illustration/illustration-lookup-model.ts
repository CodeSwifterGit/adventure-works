import { IProductModelIllustrationLookupModel } from 'app/models/data/entities/production/product-model-illustration/product-model-illustration-lookup-model';

export interface IIllustrationLookupModel {
  illustrationID: number;
  diagram: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class IllustrationLookupModel implements IIllustrationLookupModel {
  illustrationID: number;
  diagram: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<IllustrationLookupModel>) {
    if (!!init) {
      Object.assign<IllustrationLookupModel, Partial<IllustrationLookupModel>>(this, init);
    }
  }
}
