import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { IndicacoesRoutingModule } from './indicacoes-routing.module';
import { ListaIndicacoesComponent } from './lista-indicacoes/lista-indicacoes.component';
import { NovaIndicacaoComponent } from './nova-indicacao/nova-indicacao.component';


@NgModule({
  declarations: [
    ListaIndicacoesComponent,
    NovaIndicacaoComponent
  ],
  imports: [
    CommonModule,
    IndicacoesRoutingModule
  ]
})
export class IndicacoesModule { }
