import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IEmployeeAddressLookupModel } from 'app/models/data/entities/human-resources/employee-address/employee-address-lookup-model';
import { IEmployeeAddressSummary } from 'app/models/data/entities/human-resources/employee-address/employee-address-summary';

export interface IEmployeeAddressesListViewModel {
  employeeAddresses?: Array<IEmployeeAddressLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IEmployeeAddressSummary;
  };
}
