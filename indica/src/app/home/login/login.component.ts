import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AutenticacaoService } from 'src/app/autenticacao/autenticacao.service';
import { TokenService } from 'src/app/autenticacao/token.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  usuario = '';
  senha = '';

  constructor(
    private AutenticacaoService: AutenticacaoService,
    private router: Router,
    private tokenService: TokenService) {}

    ngOnInit(): void {
      this.tokenService.limpaTokens();
    }

  login() :void {
      this.AutenticacaoService.autenticar(this.usuario, this.senha)
      .then(() => {
        this.router.navigate([
          'processos'
        ])
      })
      .catch((erro: any) => {
        window.alert(erro);
      });
  }
}
