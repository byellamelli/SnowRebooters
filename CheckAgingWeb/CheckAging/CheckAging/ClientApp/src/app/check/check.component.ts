import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-check',
  templateUrl: './check.component.html'
})
export class CheckComponent {
  public checks: Check[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    http.get<Check[]>(baseUrl + 'api/Check/GetChecks').subscribe(result => {
      this.checks = result;
    }, error => console.error(error));
  }

  sendEmail(toEmail: string, Payee: string, IssuedDate: string): void {

    this.http.post(this.baseUrl + 'api/Check/SendanEmail', { toEmail: toEmail, Payee: Payee, IssuedDate: IssuedDate}).subscribe(() => this.success());
  }

  success(): void {
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
