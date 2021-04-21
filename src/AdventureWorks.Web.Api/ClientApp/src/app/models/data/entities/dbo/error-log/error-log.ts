export interface IErrorLog {
  errorLogID: number;
  errorTime: Date | string;
  userName: string;
  errorNumber: number;
  errorSeverity: number | null;
  errorState: number | null;
  errorProcedure: string;
  errorLine: number | null;
  errorMessage: string;
}

export class ErrorLog implements IErrorLog {
  errorLogID: number;
  errorTime: Date | string;
  userName: string;
  errorNumber: number;
  errorSeverity: number | null;
  errorState: number | null;
  errorProcedure: string;
  errorLine: number | null;
  errorMessage: string;

  constructor(init?: Partial<ErrorLog>) {
    if (!!init) {
      Object.assign<ErrorLog, Partial<ErrorLog>>(this, init);
    }
  }
}
