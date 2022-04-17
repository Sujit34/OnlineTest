import { Component, OnDestroy, OnInit } from '@angular/core';
//import { Console } from 'console';
import { Subscription, Observable } from 'rxjs';
import { ReconciliationService } from './reconciliation.service';


@Component({
  selector: 'app-reconciliation',
  templateUrl: './reconciliation.component.html',
  styleUrls: ['./reconciliation.component.scss']
})
export class ReconciliationComponent implements OnInit {
 
  public Years: any[];
  public IncomeCosts: any[] = [];
  public IncomeExpenses: any[] =[];
  subscription: Subscription;
  selectedValue: string;
  
  constructor(private reconciliationComponentService: ReconciliationService) { }

  ngOnInit(): void {   
    this.getAllYears();        
  }

  getAllYears() {    
     this.reconciliationComponentService.getYears().subscribe(
      (data) => {
        this.Years = data
        this.selectedValue = data[0]
        this.getIncomeCost(this.selectedValue); 
        this.getIncomeExpense(this.selectedValue);         
      }
    )
  }

  getIncomeCost(year)
  {    
    this.reconciliationComponentService.getIncomeCost(year).subscribe(
      (data)  => {
        this.IncomeCosts = data        
      }
    );  
  }

  getIncomeExpense(year)
  {    
    this.reconciliationComponentService.getIncomeExpense(year).subscribe(
      (data)  => {
        this.IncomeExpenses = data        
      }
    );
  }
  
  onSelectChange(obj)
  {
    this.selectedValue = obj.value;
    this.getIncomeCost(this.selectedValue);    
    this.getIncomeExpense(this.selectedValue); 
  }


  onColumnIncomeType1Change(obj,incomeExpense)
  {
    this.reconciliationComponentService.updateAccount(incomeExpense.id,
      parseInt(obj.target.value),incomeExpense.incomeType2,incomeExpense.incomeType3,
      incomeExpense.expenseType1,incomeExpense.expenseType2,incomeExpense.expenseType3,
      incomeExpense.expenseType4).subscribe(
        (data)=>{
          //console.log("Updated Successfully")
          this.getIncomeExpense(this.selectedValue); 
        }
      );      
  }
  onColumnIncomeType2Change(obj,incomeExpense)
  {
    this.reconciliationComponentService.updateAccount(incomeExpense.id,
      incomeExpense.incomeType1,parseInt(obj.target.value),incomeExpense.incomeType3,
      incomeExpense.expenseType1,incomeExpense.expenseType2,incomeExpense.expenseType3,
      incomeExpense.expenseType4).subscribe(
        (data)=>{
         // console.log("Updated Successfully")
          this.getIncomeExpense(this.selectedValue); 
        }
      );  
  }
  onColumnIncomeType3Change(obj,incomeExpense)
  {
    this.reconciliationComponentService.updateAccount(incomeExpense.id,
      incomeExpense.incomeType1,incomeExpense.incomeType2,parseInt(obj.target.value),
      incomeExpense.expenseType1,incomeExpense.expenseType2,incomeExpense.expenseType3,
      incomeExpense.expenseType4).subscribe(
        (data)=>{
         // console.log("Updated Successfully")
          this.getIncomeExpense(this.selectedValue); 
        }
      );  
  }
  onColumnExpenseType1Change(obj,incomeExpense)
  {
    this.reconciliationComponentService.updateAccount(incomeExpense.id,
      incomeExpense.incomeType1,incomeExpense.incomeType2,incomeExpense.incomeType3,
      parseInt(obj.target.value),incomeExpense.expenseType2,incomeExpense.expenseType3,
      incomeExpense.expenseType4).subscribe(
        (data)=>{
         // console.log("Updated Successfully")
          this.getIncomeExpense(this.selectedValue); 
        }
      );  
  }
  onColumnExpenseType2Change(obj,incomeExpense)
  {
    this.reconciliationComponentService.updateAccount(incomeExpense.id,
      incomeExpense.incomeType1,incomeExpense.incomeType2,incomeExpense.incomeType3,
      incomeExpense.expenseType1,parseInt(obj.target.value),incomeExpense.expenseType3,
      incomeExpense.expenseType4).subscribe(
        (data)=>{
         // console.log("Updated Successfully")
          this.getIncomeExpense(this.selectedValue); 
        }
      );  
  }
  onColumnExpenseType3Change(obj,incomeExpense)
  {
    this.reconciliationComponentService.updateAccount(incomeExpense.id,
      incomeExpense.incomeType1,incomeExpense.incomeType2,incomeExpense.incomeType3,
      incomeExpense.expenseType1,incomeExpense.expenseType2,parseInt(obj.target.value),
      incomeExpense.expenseType4).subscribe(
        (data)=>{
          //console.log("Updated Successfully")
          this.getIncomeExpense(this.selectedValue); 
        }
      );  
  }
  onColumnExpenseType4Change(obj,incomeExpense)
  {
    this.reconciliationComponentService.updateAccount(incomeExpense.id,
      incomeExpense.incomeType1,incomeExpense.incomeType2,incomeExpense.incomeType3,
      incomeExpense.expenseType1,incomeExpense.expenseType2,incomeExpense.expenseType3,
      parseInt(obj.target.value)).subscribe(
        (data)=>{
         // console.log("Updated Successfully")
          this.getIncomeExpense(this.selectedValue); 
        }
      );  
  }
}
