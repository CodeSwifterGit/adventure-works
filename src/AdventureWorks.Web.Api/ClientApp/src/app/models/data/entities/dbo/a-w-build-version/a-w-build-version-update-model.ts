export interface IAWBuildVersionUpdateModel {
  systemInformationID: number;
  databaseVersion: string;
  versionDate: Date | string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class AWBuildVersionUpdateModel implements IAWBuildVersionUpdateModel {
  systemInformationID: number;
  databaseVersion: string;
  versionDate: Date | string;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<AWBuildVersionUpdateModel>) {
    if (!!init) {
      Object.assign<AWBuildVersionUpdateModel, Partial<AWBuildVersionUpdateModel>>(this, init);
    }
  }
}
