export interface IAWBuildVersion {
  systemInformationID: number;
  databaseVersion: string;
  versionDate: Date | string;
  modifiedDate: Date | string;
}

export class AWBuildVersion implements IAWBuildVersion {
  systemInformationID: number;
  databaseVersion: string;
  versionDate: Date | string;
  modifiedDate: Date | string;

  constructor(init?: Partial<AWBuildVersion>) {
    if (!!init) {
      Object.assign<AWBuildVersion, Partial<AWBuildVersion>>(this, init);
    }
  }
}
