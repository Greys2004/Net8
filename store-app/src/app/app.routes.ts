import { Routes } from '@angular/router';

// http:localhost:4200/ -> /admin
export const routes: Routes = [
    {path: '', pathMatch: 'full', redirectTo: 'admin'},
    {
        path: '',
        loadChildren: () => 
            import('./pages/pages-module').then(m => m.PagesModule)
    }
];
