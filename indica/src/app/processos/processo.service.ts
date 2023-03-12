import { Injectable } from '@angular/core';
import { Processo } from './processo';

@Injectable({
  providedIn: 'root'
})
export class ProcessoService {
  processos: Array<Processo> = [];

  constructor() { }
  incluirProcesso(empresa: string, vaga: string, valor: number) :void {
    const processo: Processo = {
      aberto: true,
      empresa: empresa,
      id: this.processos.length + 1,
      indice: this.processos.length,
      premiado: '',
      vaga: vaga,
      valor: valor,
      indicacoes: []
    }
    this.processos.push(processo);
  };

  listarProcessos() :Processo[]{
    return this.processos;
  };

  encerrarProcesso(id: number) {
    this.processos.forEach((item) => {
      if (item.id === id) {
        item.aberto = false;
      } 
    })
  }

}
