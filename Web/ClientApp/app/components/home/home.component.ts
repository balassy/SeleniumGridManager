import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
  selector: 'home',
  templateUrl: './home.component.html'
})
export class HomeComponent {
  public nodeStatuses: NodeStatus[];

  constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
    const url: string = `${baseUrl}api/nodes`;
    http.get(url).subscribe(result => {
      this.nodeStatuses = result.json() as NodeStatus[];
    }, console.error);
  }
}


interface NodeStatus {
  name: string;
  agentHealthy: boolean;
}
