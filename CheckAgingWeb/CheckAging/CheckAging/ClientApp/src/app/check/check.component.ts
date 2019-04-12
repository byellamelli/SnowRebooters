import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-check',
  templateUrl: './check.component.html'
})
export class CheckComponent {
  public checks: Check[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private activatedRoute: ActivatedRoute) {
    http.get<Check[]>(baseUrl + 'api/Check/GetChecks?days=' + this.activatedRoute.snapshot.queryParams["days"]).subscribe(result => {

      this.checks = result;

    }, error => console.error(error));
  }

  sendEmail(toEmail: string, Payee: string, IssuedDate: string): void {

    this.http.post(this.baseUrl + 'api/Check/SendanEmail', { toEmail: toEmail, Payee: Payee, IssuedDate: IssuedDate}).subscribe(() => this.success());
  }

  getCheckData(days: number): void {

   // this.http.get(this.baseUrl + 'api/Check/GetChecks?days'+ days).subscribe(() => this.success());
    window.location.href = this.baseUrl + 'check?days=' + days;
   
  }

  success(): void {
    window.location.reload(true); 
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
