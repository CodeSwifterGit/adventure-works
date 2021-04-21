export interface IDatabaseLogUpdateModel {
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

export class DatabaseLogUpdateModel implements IDatabaseLogUpdateModel {
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

  constructor(init?: Partial<DatabaseLogUpdateModel>) {
    if (!!init) {
      Object.assign<DatabaseLogUpdateModel, Partial<DatabaseLogUpdateModel>>(this, init);
    }
  }
}
