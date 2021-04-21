export interface IDatabaseLogLookupModel {
  databaseLogID: number;
  postTime: Date | string;
  databaseUser: string;
  event: string;
  schema: string;
  object: string;
  tsql: string;
  xmlEvent: string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class DatabaseLogLookupModel implements IDatabaseLogLookupModel {
  databaseLogID: number;
  postTime: Date | string;
  databaseUser: string;
  event: string;
  schema: string;
  object: string;
  tsql: string;
  xmlEvent: string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<DatabaseLogLookupModel>) {
    if (!!init) {
      Object.assign<DatabaseLogLookupModel, Partial<DatabaseLogLookupModel>>(this, init);
    }
  }
}
