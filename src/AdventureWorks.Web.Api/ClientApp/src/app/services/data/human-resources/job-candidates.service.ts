import { Injectable } from '@angular/core';
import { HttpParams, HttpResponse, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequestOptions } from 'app/models/data/common/request-options';
import { IJobCandidate } from 'app/models/data/entities/human-resources/job-candidate/job-candidate';
import { IJobCandidateLookupModel } from 'app/models/data/entities/human-resources/job-candidate/job-candidate-lookup-model';
import { IJobCandidateUpdateModel } from 'app/models/data/entities/human-resources/job-candidate/job-candidate-update-model';
import { IJobCandidatesListViewModel } from 'app/models/data/entities/human-resources/job-candidate/job-candidates-list-view-model';
import { DataService } from 'app/services/common/data.service';
import { ISortedPropertyInfo } from 'app/models/data/common/sorted-property-info';
import { ApiUrlBuilder } from 'app/encoders/api-url-builder';

export interface IJobCandidatePrimaryKey {
  jobCandidateID: number;
}

export interface IJobCandidateUpdateItem extends IJobCandidate {
  requestTarget: IJobCandidatePrimaryKey;
}

@Injectable({
  providedIn: 'root',
})
export class JobCandidatesService {
  constructor(protected apiClient: DataService) {}

  create(model: IJobCandidate, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IJobCandidateLookupModel>;
  create(model: IJobCandidate, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IJobCandidateLookupModel>>;
  create(model: IJobCandidate, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IJobCandidateLookupModel>>;
  create(model: IJobCandidate, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('JobCandidates', {});

    return this.apiClient.create<IJobCandidate, IJobCandidateLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  createMany(model: Array<IJobCandidate>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IJobCandidateLookupModel>>;
  createMany(model: Array<IJobCandidate>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IJobCandidateLookupModel>>>;
  createMany(model: Array<IJobCandidate>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IJobCandidateLookupModel>>>;
  createMany(model: Array<IJobCandidate>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling create.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('JobCandidates/createMany', {});

    return this.apiClient.create<Array<IJobCandidate>, Array<IJobCandidateLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  delete(jobCandidateID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  delete(jobCandidateID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  delete(jobCandidateID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  delete(jobCandidateID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('JobCandidates', {
      jobCandidateID,
    });

    return this.apiClient.delete(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  deleteMany(model: Array<IJobCandidatePrimaryKey>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<any>;
  deleteMany(model: Array<IJobCandidatePrimaryKey>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
  deleteMany(model: Array<IJobCandidatePrimaryKey>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
  deleteMany(model: Array<IJobCandidatePrimaryKey>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('JobCandidates/DeleteMany', {});

    return this.apiClient.post<Array<IJobCandidatePrimaryKey>, any>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  update(jobCandidateID: number, model: IJobCandidateUpdateModel, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IJobCandidateLookupModel>;
  update(jobCandidateID: number, model: IJobCandidateUpdateModel, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IJobCandidateLookupModel>>;
  update(jobCandidateID: number, model: IJobCandidateUpdateModel, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IJobCandidateLookupModel>>;
  update(jobCandidateID: number, model: IJobCandidateUpdateModel, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('JobCandidates', {
      jobCandidateID,
    });

    return this.apiClient.update<IJobCandidateUpdateModel, IJobCandidateLookupModel>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  updateMany(model: Array<IJobCandidateUpdateItem>, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<Array<IJobCandidateLookupModel>>;
  updateMany(model: Array<IJobCandidateUpdateItem>, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<IJobCandidateLookupModel>>>;
  updateMany(model: Array<IJobCandidateUpdateItem>, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<IJobCandidateLookupModel>>>;
  updateMany(model: Array<IJobCandidateUpdateItem>, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    if (model === null || model === undefined) {
      throw new Error('Required parameter model was null or undefined when calling update.');
    }

    let apiUrlBuilder = new ApiUrlBuilder('JobCandidates/UpdateMany', {});

    return this.apiClient.update<Array<IJobCandidateUpdateItem>, Array<IJobCandidateLookupModel>>(apiUrlBuilder.build(), model, options, observe, reportProgress);
  }

  get(jobCandidateID: number, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IJobCandidateLookupModel>;
  get(jobCandidateID: number, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IJobCandidateLookupModel>>;
  get(jobCandidateID: number, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IJobCandidateLookupModel>>;
  get(jobCandidateID: number, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('JobCandidates', {
      jobCandidateID,
    });

    return this.apiClient.get<IJobCandidateLookupModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }

  getByEmployee(employeeID: number | null, options?: IRequestOptions, observe?: 'body', reportProgress?: boolean): Observable<IJobCandidatesListViewModel>;
  getByEmployee(employeeID: number | null, options?: IRequestOptions, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<IJobCandidatesListViewModel>>;
  getByEmployee(employeeID: number | null, options?: IRequestOptions, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<IJobCandidatesListViewModel>>;
  getByEmployee(employeeID: number | null, options?: IRequestOptions, observe: any = 'body', reportProgress: boolean = false): Observable<any> {
    let apiUrlBuilder = new ApiUrlBuilder('JobCandidates/GetJobCandidatesByEmployee', {
      employeeID,
    });

    return this.apiClient.get<IJobCandidatesListViewModel>(apiUrlBuilder.build(), options, observe, reportProgress);
  }
}
