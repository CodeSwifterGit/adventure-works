export interface IShoppingCartItem {
  shoppingCartItemID: number;
  shoppingCartID: string;
  quantity: number;
  productID: number;
  dateCreated: Date | string;
  modifiedDate: Date | string;
}

export class ShoppingCartItem implements IShoppingCartItem {
  shoppingCartItemID: number;
  shoppingCartID: string;
  quantity: number;
  productID: number;
  dateCreated: Date | string;
  modifiedDate: Date | string;

  constructor(init?: Partial<ShoppingCartItem>) {
    if (!!init) {
      Object.assign<ShoppingCartItem, Partial<ShoppingCartItem>>(this, init);
    }
  }
}
