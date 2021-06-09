
export interface IDocumentUpdateModel {
  documentID: number;
  title: string;
  fileName: string;
  fileExtension: string;
  revision: string;
  changeNumber: number;
  status: number;
  documentSummary: string;
  document: Int8Array;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */
}

export class DocumentUpdateModel implements IDocumentUpdateModel {
  documentID: number;
  title: string;
  fileName: string;
  fileExtension: string;
  revision: string;
  changeNumber: number;
  status: number;
  documentSummary: string;
  document: Int8Array;
  modifiedDate: Date | string;

  // Uncomment the following line if you need child navigation properties (can cause a poor performance)
  /*  */
  // Uncomment the following line if you need parent navigation properties
  /*  */

  constructor(init?: Partial<DocumentUpdateModel>) {
    if (!!init) {
      Object.assign<DocumentUpdateModel, Partial<DocumentUpdateModel>>(this, init);
    }
  }
}
