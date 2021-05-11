import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerAddEditComponent } from './customer-add-edit/customer-add-edit.component';
import { NavbarComponent } from './navbar/navbar.component';
import { OrdertypeAddEditComponent } from './ordertype-add-edit/ordertype-add-edit.component';
import { OrdertypeListComponent } from './ordertype-list/ordertype-list.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductAddEditComponent } from './product-add-edit/product-add-edit.component';
import { OrderAddEditComponent } from './order-add-edit/order-add-edit.component';
import { OrderListComponent } from './order-list/order-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { LoginComponent } from './login/login.component'
import {NgxPaginationModule} from 'ngx-pagination';
import { Ng2SearchPipeModule } from 'ng2-search-filter';

@NgModule({
  declarations: [
    AppComponent,
    CustomerListComponent,
    CustomerAddEditComponent,
    NavbarComponent,
    OrdertypeAddEditComponent,
    OrdertypeListComponent,
    DashboardComponent,
    ProductListComponent,
    ProductAddEditComponent,
    OrderAddEditComponent,
    OrderListComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxPaginationModule,
    Ng2SearchPipeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
