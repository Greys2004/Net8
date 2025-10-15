import { Component } from '@angular/core';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { PagesModule } from '../../../pages/pages-module';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-side-bar',
  imports: [NzMenuModule, NzIconModule,PagesModule, RouterModule,NzIconModule],
  templateUrl: './side-bar.component.html',
  styleUrl: './side-bar.component.scss',
  standalone: true
})
export class SideBarComponent {

}
