import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListaProcessosComponent } from './lista-processos/lista-processos.component';

const routes: Routes = [
  {
    path: '',
    component: ListaProcessosComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProcessosRoutingModule { }
