import { IProductDocumentLookupModel } from 'app/models/data/entities/production/product-document/product-document-lookup-model';

export interface IDocumentLookupModel {
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

export class DocumentLookupModel implements IDocumentLookupModel {
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

  constructor(init?: Partial<DocumentLookupModel>) {
    if (!!init) {
      Object.assign<DocumentLookupModel, Partial<DocumentLookupModel>>(this, init);
    }
  }
}
