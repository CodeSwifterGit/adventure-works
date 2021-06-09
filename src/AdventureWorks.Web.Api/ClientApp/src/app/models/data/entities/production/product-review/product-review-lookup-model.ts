
export interface IProductReviewLookupModel {
  productReviewID: number;
  productID: number;
  reviewerName: string;
  reviewDate: Date | string;
  emailAddress: string;
  rating: number;
  comments: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ProductReviewLookupModel implements IProductReviewLookupModel {
  productReviewID: number;
  productID: number;
  reviewerName: string;
  reviewDate: Date | string;
  emailAddress: string;
  rating: number;
  comments: string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ProductReviewLookupModel>) {
    if (!!init) {
      Object.assign<ProductReviewLookupModel, Partial<ProductReviewLookupModel>>(this, init);
    }
  }
}
