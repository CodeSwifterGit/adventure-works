export interface IErrorLogUpdateModel {
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

export class ErrorLogUpdateModel implements IErrorLogUpdateModel {
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

  constructor(init?: Partial<ErrorLogUpdateModel>) {
    if (!!init) {
      Object.assign<ErrorLogUpdateModel, Partial<ErrorLogUpdateModel>>(this, init);
    }
  }
}
