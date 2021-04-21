import { IProductLookupModel } from 'app/models/data/entities/production/product/product-lookup-model';

export interface IShoppingCartItemLookupModel {
  shoppingCartItemID: number;
  shoppingCartID: string;
  quantity: number;
  productID: number;
  dateCreated: Date | string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ShoppingCartItemLookupModel implements IShoppingCartItemLookupModel {
  shoppingCartItemID: number;
  shoppingCartID: string;
  quantity: number;
  productID: number;
  dateCreated: Date | string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ShoppingCartItemLookupModel>) {
    if (!!init) {
      Object.assign<ShoppingCartItemLookupModel, Partial<ShoppingCartItemLookupModel>>(this, init);
    }
  }
}
