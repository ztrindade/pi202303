import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListaIndicacoesComponent } from './lista-indicacoes/lista-indicacoes.component';
import { NovaIndicacaoComponent } from './nova-indicacao/nova-indicacao.component';

const routes: Routes = [
  {
    path: '',
    component: ListaIndicacoesComponent
  },
  {
    path: 'novaIndicacao',
    component: NovaIndicacaoComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IndicacoesRoutingModule { }
