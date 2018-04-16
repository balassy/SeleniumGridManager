import { Component, HostBinding, Inject, Input, OnInit } from '@angular/core';

import { ApiService } from '../../../services/api/api.service';
import { ScreenshotResponse, NodeDetailsResponse } from '../../../services/api/api.types';

@Component({
  selector: 'node-card',
  templateUrl: './node-card.component.html',
  host: { 'class': 'card node-card bg-white mx-2 mb-3' },
  styleUrls: ['./node-card.component.css']
})
export class NodeCardComponent implements OnInit {
  @Input()
  public nodeId: string;

  @HostBinding('class.border-success')
  public borderSuccess: boolean;

  @HostBinding('class.border-danger')
  public borderDanger: boolean;

  public imageSrc: string;
  public node: NodeDetailsResponse;

  private _api: ApiService;

  constructor(api: ApiService) {
    this._api = api;
  }

  public ngOnInit(): void {
    this._getNodeDetails();
    this._getScreenshot();
  }

  public onRefreshClicked(): void {
    this._getNodeDetails();
    this._getScreenshot();
  }

  public onScreenshotClicked(): void {
    this._openScreenshotOnNewTab();
  }

  public onTerminateProcessClicked(): void {
    this._terminateProcess();
  }

  private _getNodeDetails(): void {
    this._api.getNodeDetails(this.nodeId).subscribe((nodeDetails: NodeDetailsResponse) => {
      this.node = nodeDetails;
      this.borderSuccess = this.node.agentHealthy;
      this.borderDanger = !this.node.agentHealthy;
    });
  }

  private _getScreenshot(): void {
    this._api.getScreenshot(this.nodeId).subscribe((screenshot: ScreenshotResponse) => {
      this.imageSrc = screenshot.imageContent;
    });
  }

  private _openScreenshotOnNewTab(): void {
    const win: Window = window.open('', 'Screenshot') as Window;
    win.document.body.innerHTML = `<html><body><img src="${this.imageSrc}" /></body></html>`;
  }

  private _terminateProcess(): void {
    this._api.terminateProcesses(this.nodeId).subscribe(() => {
      this._getScreenshot();
    });
  }
}




