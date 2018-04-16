import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Response } from '@angular/http/src/static_response';
import { Observable } from 'rxjs/Observable';
import "rxjs/add/operator/map";

import { NodeDetailsResponse, NodeStatusResponse, ScreenshotResponse } from './api.types';

@Injectable()
export class ApiService {
  private _baseUrl: string;
  private _http: Http;

  constructor(http: Http,
              @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
  }

  public getNodes(): Observable<NodeStatusResponse[]> {
    const url: string = `${this._baseUrl}api/nodes`;
    return this._http.get(url).map((res: Response) => res.json());
  }

  public getNodeDetails(nodeId: string): Observable<NodeDetailsResponse> {
    const url: string = `${this._baseUrl}api/nodes/${nodeId}`;
    return this._http.get(url).map((res: Response) => res.json());
  }

  public getScreenshot(nodeId: string): Observable<ScreenshotResponse> {
    const url: string = `${this._baseUrl}api/nodes/${nodeId}/screenshot`;
    return this._http.get(url).map((res: Response) => res.json());
  }

  public terminateProcesses(nodeId: string): Observable<Response> {
    const url: string = `${this._baseUrl}api/nodes/${nodeId}/processes`;
    return this._http.delete(url);
  }
}
