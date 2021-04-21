import { IPagingInfo } from 'app/models/data/common/paging-info';
import { IEmployeeAddressSummary } from 'app/models/data/entities/human-resources/employee-address/employee-address-summary';
import { IEmployeeAddressLookupModel } from 'app/models/data/entities/human-resources/employee-address/employee-address-lookup-model';

export interface IEmployeeAddressesListViewModel {
  employeeAddresses?: Array<IEmployeeAddressLookupModel>;
  dataTable?: {
    pagingState?: IPagingInfo;
    summaryInfo?: IEmployeeAddressSummary;
  };
}
