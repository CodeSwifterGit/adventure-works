import { IProductUpdateModel } from 'app/models/data/entities/production/product/product-update-model';

export interface IProductReviewUpdateModel {
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

export class ProductReviewUpdateModel implements IProductReviewUpdateModel {
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

  constructor(init?: Partial<ProductReviewUpdateModel>) {
    if (!!init) {
      Object.assign<ProductReviewUpdateModel, Partial<ProductReviewUpdateModel>>(this, init);
    }
  }
}
