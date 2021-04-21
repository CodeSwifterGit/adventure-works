import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IShoppingCartItemSummary } from 'app/models/data/entities/sales/shopping-cart-item/shopping-cart-item-summary';
import { IShoppingCartItemLookupModel } from 'app/models/data/entities/sales/shopping-cart-item/shopping-cart-item-lookup-model';

export interface IShoppingCartItemsListViewModel {
  shoppingCartItems?: Array<IShoppingCartItemLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IShoppingCartItemSummary;
  };
}
