import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'home'
  },
  {
    path: 'home',
    loadChildren: () => 
      import('./home/home.module').then((m) => m.HomeModule)
  },
  {
    path: 'processos',
    loadChildren: () => 
      import('./processos/processos.module').then((m) => m.ProcessosModule)
  },
  {
    path: 'indicacoes',
    loadChildren: () =>
      import('./indicacoes/indicacoes.module').then((m) => m.IndicacoesModule) 
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
