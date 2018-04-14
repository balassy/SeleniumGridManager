import { Component, Inject, OnInit } from '@angular/core';

import { ApiService } from '../../services/api/api.service';
import { NodeStatusResponse } from '../../services/api/api.types';

@Component({
  selector: 'home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  public nodes: NodeStatusResponse[];

  private _api: ApiService;

  constructor(api: ApiService) {
    this._api = api;
  }

  public ngOnInit() {
    this._getNodes();
  }

  private _getNodes() {
    this._api.getNodes().subscribe((nodes: NodeStatusResponse[]) => {
      this.nodes = nodes;
    });
  }
}



