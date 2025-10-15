import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ShopComponent } from './pages/shop.component/shop.component';
import { SideBarComponent } from './shared/components/side-bar/side-bar.component';
import { PagesModule } from './pages/pages-module';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,PagesModule, SideBarComponent],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('store-app');
}
