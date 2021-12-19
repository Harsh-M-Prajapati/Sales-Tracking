import { Component, OnInit } from '@angular/core';
import { ProductDetails } from 'src/model/ProductDetails.model';
import { AdminService } from '../admin/admin.service';
import { BreakpointObserver } from '@angular/cdk/layout';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { Employee } from 'src/model/employee';
import { LoginService } from '../login.service';

@Component({
  selector: 'app-user-home',
  templateUrl: './user-home.component.html',
  styleUrls: ['./user-home.component.css']
})
export class UserHomeComponent implements OnInit {
  

  
    



  constructor(){
   }

  ngOnInit(): void {
  }

  

}
