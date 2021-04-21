export interface IErrorLogLookupModel {
  errorLogID: number;
  errorTime: Date | string;
  userName: string;
  errorNumber: number;
  errorSeverity: number | null;
  errorState: number | null;
  errorProcedure: string;
  errorLine: number | null;
  errorMessage: string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class ErrorLogLookupModel implements IErrorLogLookupModel {
  errorLogID: number;
  errorTime: Date | string;
  userName: string;
  errorNumber: number;
  errorSeverity: number | null;
  errorState: number | null;
  errorProcedure: string;
  errorLine: number | null;
  errorMessage: string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<ErrorLogLookupModel>) {
    if (!!init) {
      Object.assign<ErrorLogLookupModel, Partial<ErrorLogLookupModel>>(this, init);
    }
  }
}
