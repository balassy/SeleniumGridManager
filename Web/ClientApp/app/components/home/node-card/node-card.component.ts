import { Component, HostBinding, Inject, Input } from '@angular/core';

import { ApiService } from '../../../services/api/api.service';
import { ScreenshotResponse, NodeDetailsResponse } from '../../../services/api/api.types';

@Component({
  selector: 'node-card',
  templateUrl: './node-card.component.html',
  host: { 'class': 'card bg-white' }
})
export class NodeCardComponent {
  @Input()
  public nodeId: string;

  @HostBinding('class.border-success') borderSuccess: boolean;
  @HostBinding('class.border-danger') borderDanger: boolean;

  public imageSrc: string;
  public node: NodeDetailsResponse;

  private _api: ApiService;

  constructor(api: ApiService) {
    this._api = api;
  }

  public ngOnInit() {
    this._getNodeDetails();
    this._getScreenshot();
  }

  private _getNodeDetails() {
    this._api.getNodeDetails(this.nodeId).subscribe((nodeDetails: NodeDetailsResponse) => {
      this.node = nodeDetails;
      this.borderSuccess = this.node.agentHealthy;
      this.borderDanger = !this.node.agentHealthy;
    });
  }

  private _getScreenshot() {
    this._api.getScreenshot(this.nodeId).subscribe((screenshot: ScreenshotResponse) => {
      this.imageSrc = screenshot.imageContent;
    });
  }
}




