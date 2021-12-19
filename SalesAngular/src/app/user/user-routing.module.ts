import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserMasterComponent } from './user-master.component';
import { UserHomeComponent } from './user-home.component';
import { OrderComponent } from './order.component';


const routes: Routes = [
  {path:'user',component:UserMasterComponent,children:
    [
      {path:'home',component:UserHomeComponent},
      {path:'',redirectTo:'home',pathMatch:'full'},
      {path:'order',component:OrderComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
