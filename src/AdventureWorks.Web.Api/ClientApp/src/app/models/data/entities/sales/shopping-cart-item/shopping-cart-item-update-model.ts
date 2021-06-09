
export interface IShoppingCartItemUpdateModel {
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

export class ShoppingCartItemUpdateModel implements IShoppingCartItemUpdateModel {
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

  constructor(init?: Partial<ShoppingCartItemUpdateModel>) {
    if (!!init) {
      Object.assign<ShoppingCartItemUpdateModel, Partial<ShoppingCartItemUpdateModel>>(this, init);
    }
  }
}
