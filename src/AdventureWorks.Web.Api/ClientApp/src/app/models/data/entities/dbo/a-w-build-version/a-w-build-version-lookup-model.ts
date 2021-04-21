export interface IAWBuildVersionLookupModel {
  systemInformationID: number;
  databaseVersion: string;
  versionDate: Date | string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class AWBuildVersionLookupModel implements IAWBuildVersionLookupModel {
  systemInformationID: number;
  databaseVersion: string;
  versionDate: Date | string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<AWBuildVersionLookupModel>) {
    if (!!init) {
      Object.assign<AWBuildVersionLookupModel, Partial<AWBuildVersionLookupModel>>(this, init);
    }
  }
}
