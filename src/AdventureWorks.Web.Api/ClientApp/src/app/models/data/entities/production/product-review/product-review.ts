export interface IProductReview {
  productReviewID: number;
  productID: number;
  reviewerName: string;
  reviewDate: Date | string;
  emailAddress: string;
  rating: number;
  comments: string;
  modifiedDate: Date | string;
}

export class ProductReview implements IProductReview {
  productReviewID: number;
  productID: number;
  reviewerName: string;
  reviewDate: Date | string;
  emailAddress: string;
  rating: number;
  comments: string;
  modifiedDate: Date | string;

  constructor(init?: Partial<ProductReview>) {
    if (!!init) {
      Object.assign<ProductReview, Partial<ProductReview>>(this, init);
    }
  }
}
