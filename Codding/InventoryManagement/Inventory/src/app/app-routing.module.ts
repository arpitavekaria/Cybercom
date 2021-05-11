import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerAddEditComponent } from './customer-add-edit/customer-add-edit.component';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { OrderListComponent } from './order-list/order-list.component';
import { ProductAddEditComponent } from './product-add-edit/product-add-edit.component';
import { ProductListComponent } from './product-list/product-list.component';
import { AuthGuardService } from './services/auth-guard.service';

const routes: Routes = [
  {
    path:'',
    redirectTo: 'dashboard',
    pathMatch : 'full'
    
  },
  {
    path:'dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuardService]
  },
  
  {
    path:'login',
    component: LoginComponent
  },
  {
    path:'customer',
    component: CustomerListComponent,
    canActivate: [AuthGuardService]
  },
  {
    path:'customer/add',
    component: CustomerAddEditComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: 'customer/edit/:id', 
    component: CustomerAddEditComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: 'product',
    component: ProductListComponent,
    canActivate: [AuthGuardService]
  },
  {
    path:'product/add',
    component: ProductAddEditComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: 'product/edit/:id', 
    component: ProductAddEditComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: 'order',
    component: OrderListComponent,
    canActivate: [AuthGuardService]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
