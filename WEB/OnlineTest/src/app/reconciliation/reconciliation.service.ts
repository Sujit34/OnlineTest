import { HttpClient } from '@angular/common/http';
import { identifierModuleUrl } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Observable, Subject, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BaseUrlService } from 'src/app/shared/services/base-url.service';


@Injectable({
  providedIn: 'root'
})
export class ReconciliationService {

  constructor (private http: HttpClient, private baseUrl: BaseUrlService) { }
 
  getYears(): Observable<any> {
    var url = this.baseUrl.BaseUrl() + "/api/Reconciliation/GetYears";
    return this.http.get(`${url}`, {  })
  }
  
  getIncomeCost(year: string):Observable<any> {
    var url = this.baseUrl.BaseUrl() + "/api/Reconciliation/GetAllIncomeCosts?year=" + year;
    return this.http.get(`${url}`, {  })
  }

  getIncomeExpense(year: string):Observable<any> {
    var url = this.baseUrl.BaseUrl() + "/api/Reconciliation/GetAllIncomeExpenses?year=" + year;
    return this.http.get(`${url}`, {  })
  }

  updateAccount(id, incomeType1,incomeType2,incomeType3,expenseType1,expenseType2,expenseType3,expenseType4) {    
    var incomeExpense = {
      id: id,
      incomeType1: incomeType1,
      incomeType2: incomeType2,
      incomeType3: incomeType3,
      expenseType1: expenseType1,
      expenseType2: expenseType2,
      expenseType3: expenseType3,
      expenseType4: expenseType4
    };
    var url = this.baseUrl.BaseUrl() + "/api/Reconciliation/UpdateIncomeExpense";
    return this.http.patch(`${url}`, incomeExpense, { }).pipe(
      catchError(error => {
        return throwError(error);
      })
    );
  }


}