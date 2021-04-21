export interface IDatabaseLog {
  databaseLogID: number;
  postTime: Date | string;
  databaseUser: string;
  event: string;
  schema: string;
  object: string;
  tsql: string;
  xmlEvent: string;
}

export class DatabaseLog implements IDatabaseLog {
  databaseLogID: number;
  postTime: Date | string;
  databaseUser: string;
  event: string;
  schema: string;
  object: string;
  tsql: string;
  xmlEvent: string;

  constructor(init?: Partial<DatabaseLog>) {
    if (!!init) {
      Object.assign<DatabaseLog, Partial<DatabaseLog>>(this, init);
    }
  }
}
