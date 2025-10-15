import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrl: './order-detail.component.scss',
  standalone: false,
})
export class OrderDetailComponent implements OnInit {
  // Todo loq que viene de la ruta es string
  id? : string | null;

  // Inyeccion de dependencias (constructor con propiedades que no sabemos donde se llaman)
  constructor(
    private route : ActivatedRoute,
  ) {}

  ngOnInit(): void {
    // agarra la ruta actual y busca en los parametros el id
    this.id = this.route.snapshot.paramMap.get('id');
    console.log(this.id);
  }
}
