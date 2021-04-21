export interface IDocument {
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
}

export class Document implements IDocument {
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

  constructor(init?: Partial<Document>) {
    if (!!init) {
      Object.assign<Document, Partial<Document>>(this, init);
    }
  }
}
