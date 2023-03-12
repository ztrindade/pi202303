import { Component, OnInit } from '@angular/core';
import { TokenService } from 'src/app/autenticacao/token.service';
import { ProcessoService } from '../processo.service';
import { Indicacao, Processo } from '../processo';
import { elementAt } from 'rxjs';

@Component({
  selector: 'app-lista-processos',
  templateUrl: './lista-processos.component.html',
  styleUrls: ['./lista-processos.component.css']
})

export class ListaProcessosComponent implements OnInit {
  podeIncluir = false; 
  podeIndicar = false;
  listaProcessos!: Processo[];
  exibeLista = true;
  exibeDetalhar = false;
  exibeIndicar = false;
  exibeIncluir = false;
  detalhe!: Processo;
// Input do processo
  inputEmpresa = '';
  inputVaga = '';
  inputValor = 0;
// Input da indicação
  inputIndicante = '';
  inputNomeIndicado = '';
  inputTelefoneIndicado = '';
  inputLinkedin = '';

  constructor(
    private tokenService: TokenService,
    private processoService: ProcessoService,
    ) { }

    ngOnInit(): void {
      if (this.tokenService.retornaToken('perfil') === 'adm'){
        this.podeIncluir = true;
      } else {
        this.podeIndicar = true;
      };
      this.inputIndicante = this.tokenService.retornaToken('name');
      this.consultarProcessos();
    }

    aceitarIndicacao(processo: number, indicacao: number) {
      if (window.confirm("Deseja aceitar o candidato indicado?")) {
        this.listaProcessos[processo].indicacoes[indicacao].aceita = true;
        this.detalhaProcesso(this.listaProcessos[processo].id);
      }
    }

    consultarProcessos() :void {
      this.listaProcessos = [];
      this.listaProcessos = this.processoService.listarProcessos();
    }

    detalhaProcesso(id: number|undefined) {
      if (id) {
        this.montarDetalhamento(id);
        this.toggleDetalhar();
      }
    }

    encerraProcesso(id: number|undefined) :void{
      if (window.confirm("Deseja encerrar o processo?")) {
        this.listaProcessos.forEach((processo) => {
          if (processo.id === id) {
            processo.aberto = false;
            let aux: Array<any> = [];
            processo.indicacoes.forEach((item) => {
              if (item.aceita) {
                const indice = aux
                .map((x) => x.nome)
                .indexOf(item.indicante)
                if (indice === -1) {
                  aux.push({nome: item.indicante, quantidade: 1});
                } else {
                  aux[indice].quantidade = aux[indice].quantidade + 1
                }
              }
            })
          if (aux.length > 0) {
            aux.sort((a, b) => b.quantidade - a.quantidade);
            processo.premiado = aux[0].nome;
          }
          this.consultarProcessos();
          if (this.exibeDetalhar) {
            this.toggleDetalhar();
          }
        }
        });
      }
    }

    incluirIndicacao(id: number|undefined) {
      this.listaProcessos.forEach((processo) => {
        if (processo.id === id) {
          const indicacao:Indicacao = {
            aceita: false,
            indicante: this.inputIndicante,
            linkedin: this.inputLinkedin,
            nomeIndicado: this.inputNomeIndicado,
            telefoneIndicado: this.inputTelefoneIndicado,
            sequencial: processo.indicacoes.length
          }
          processo.indicacoes.push(indicacao);
          this.inputLinkedin = '';
          this.inputNomeIndicado = '';
          this.inputTelefoneIndicado = '';
          this.toggleIndicar();
        }
      })
    }

    incluirProcesso() {
      this.processoService.incluirProcesso(this.inputEmpresa, this.inputVaga, this.inputValor);
      this.inputEmpresa = '';
      this.inputVaga = '';
      this.toggleIncluir();    
      this.consultarProcessos();
    }

    montarIndicacao(id: number|undefined) {
      if (id) {
        this.montarDetalhamento(id);
        this.toggleIndicar();
      }
    }

    montarDetalhamento(id: number) {
      this.listaProcessos.forEach((processo) => {
        if (processo.id === id) {
          this.detalhe = processo;
        }
      })
    }

    toggleDetalhar() {
      this.exibeDetalhar = !this.exibeDetalhar;
      this.toggleListar();
    }

    toggleIndicar() {
      this.exibeIndicar = !this.exibeIndicar;
      this.inputNomeIndicado = '';
      this.inputTelefoneIndicado = '';
      this.inputLinkedin = ''
      this.toggleListar();
    }

    toggleIncluir() {
      this.exibeIncluir = !this.exibeIncluir;
      this.toggleListar();
    }

    toggleListar() {
      this.exibeLista = !this.exibeLista;
    }

}
