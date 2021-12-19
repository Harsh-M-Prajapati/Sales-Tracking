import { Component, OnInit } from '@angular/core';
import { Product } from 'src/model/Product.model';
import { UserService } from './user.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Order } from 'src/model/Order.model';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  product:Product[] = [];
  order:Order = new Order();
  prod:Product []= [];
  currentDate = new Date();


  constructor(private service:UserService, private spinner:NgxSpinnerService, 
    private toastr:ToastrService) {
      //this.date = this.datePipe.transform(this.date, 'yyyy-MM-dd');
    }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts():void{
    this.spinner.show();
    this.service.getProdcuts().subscribe((data)=>{
      this.product = data as Product[]
      console.log(data as Product[]);
      this.spinner.hide();
    },(err)=>{
      this.toastr.error(err,'Alert');
      this.spinner.hide();
    });
  }

  submit():void{
    this.spinner.show();
    this.order.EmployeeID =+ sessionStorage.getItem('UserID');
    this.order.OrderDate = this.currentDate.toLocaleDateString();
    this.service.placeOrder(this.order).subscribe((data)=>{
      let message = data.Message;
      if(message == "Success"){
        this.toastr.success('Order added','Alert');
      }
      else{
        this.toastr.error(message,'Alert');
      }
      this.spinner.hide();
    },(err)=>{
      this.toastr.error(err,'Alert');
    });
    //console.log(this.order);
  }

  onChange(event):void{
    console.log(event.target.value);
    this.prod = this.product.filter(prod => prod.ProductID == event.target.value);
    console.log(this.prod[0])
    this.order.ProductPrice = this.prod[0].ProductPrice;
    //console.log(Order.ProductPrice)
  }

}
