import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from './products.component/products.component';
import { ShopComponent } from './shop.component/shop.component';
import { InvoicesComponent } from './invoices.component/invoices.component';
import { OrdersComponent } from './orders.component/orders.component';
import { OrderDetailComponent } from './order-detail.component/order-detail.component';
import { ShopService } from '../core/services/shop.service';
import { AdminLayout } from './admin-layout/admin-layout';
import { ADMIN_ROUTES } from './pages.routes';
import { RouterModule } from '@angular/router';
import { OrderService } from '../core/services/order.service';

import { NzTableModule } from 'ng-zorro-antd/table';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzTagModule } from 'ng-zorro-antd/tag';

@NgModule({
  declarations: [
    ShopComponent,
    ProductsComponent,
    InvoicesComponent,
    OrdersComponent,
    OrderDetailComponent,
    AdminLayout
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(ADMIN_ROUTES),
    NzTableModule,
    NzButtonModule,
    NzIconModule,
    NzTagModule
  ],
  providers: [
    ShopService,
    OrderService
  ],
  exports:[
    ShopComponent,
    ProductsComponent,
    InvoicesComponent,
    OrdersComponent,
    OrderDetailComponent,
    AdminLayout,
    RouterModule
  ]
})

export class PagesModule { }
