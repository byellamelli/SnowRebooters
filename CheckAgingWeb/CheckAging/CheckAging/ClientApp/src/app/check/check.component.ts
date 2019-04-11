import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-check',
  templateUrl: './check.component.html'
})
export class CheckComponent {
  public checks: Check[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Check[]>(baseUrl + 'api/Check/GetChecks').subscribe(result => {
      this.checks = result;
    }, error => console.error(error));
  }
}

interface Check {
  id: number;
  dateIssued: string;
  dateCleared: string;
  amount: string;
  payee: string;
  phoneNumber: string;
  emailAddress: string; 
}
