import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-buyer',
  templateUrl: './buyer.component.html'
})
export class BuyerComponent {
  public buyers: Buyer[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Buyer[]>(baseUrl + 'api/Buyer/GetBuyers').subscribe(result => {
      this.buyers = result;
    }, error => console.error(error));
  }
}

interface Buyer {
  id: number;
  name: string;
}
