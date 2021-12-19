import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MasterComponent } from './master.component';
import { ViewOrdersComponent } from './view-orders.component';
import { HomeComponent } from './home.component';


const routes: Routes = [
  {path:'master',component:MasterComponent,children:
    [
      {path:'home',component:HomeComponent},
      {path:'orders',component:ViewOrdersComponent}
    ]
  },
  {path:'',redirectTo:'/master',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
