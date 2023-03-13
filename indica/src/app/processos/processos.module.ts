import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProcessosRoutingModule } from './processos-routing.module';
import { ListaProcessosComponent } from './lista-processos/lista-processos.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MensagemModule } from '../componentes/mensagem/mensagem.module';
import { CabecalhoModule } from '../componentes/cabecalho/cabecalho.module';


@NgModule({
  declarations: [
    ListaProcessosComponent,
  ],
  imports: [
    CommonModule,
    CabecalhoModule,
    FormsModule,
    ReactiveFormsModule,
    MensagemModule,
    ProcessosRoutingModule
  ]
})
export class ProcessosModule { }
