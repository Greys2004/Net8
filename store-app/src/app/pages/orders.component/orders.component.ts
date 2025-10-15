import { Component, OnInit } from '@angular/core';
import { OrderService } from '../../core/services/order.service';
import { Order } from '../../core/models/order.model';

@Component({
  selector: 'app-orders.component',
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.scss',
  standalone: false,
})
export class OrdersComponent implements OnInit {
  constructor(private orderService: OrderService) {}

  orders : Order[] = [];
  ngOnInit(): void {
    console.log("Iniciando componente");
    this.orderService.getAllOrders().subscribe(res => {
      this.orders = res;
    });
    console.log("Terminando componente");
  }

  showModal(order: Order) {
    console.log(order);
  }
}
