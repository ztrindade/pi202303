import { Injectable } from '@angular/core';
import { Usuario } from './usuario/usuario';
import { TokenService } from './token.service'

@Injectable({
  providedIn: 'root'
})
export class AutenticacaoService {

  usuarios: Usuario[] = [
    {
      id: 1,
      name: 'Fernanda',
      username: "fernanda",
      perfil: "adm"
    },
    {
      id: 2,
      name: 'Bruna',
      username: "bruna",
      perfil: "indicante"
    },
    {
      id: 3,
      name: 'Danilo',
      username: "danilo",
      perfil: "indicante"
    },
    {
      id: 4,
      name: 'Alexandra',
      username: "alexandra",
      perfil: "indicante"
    },
  ]  
  constructor(private TokenService: TokenService) { }

    autenticar(usuario: string, senha: string): Promise<boolean> {
      let resposta = '';
      this.usuarios.forEach((item) => {
        if (item.username === usuario && senha === 'teste') {
          this.TokenService.limpaTokens();
          resposta = item.id?.toString() ?? '';
          this.TokenService.salvaToken('id', resposta);
          resposta = item.name ?? '';
          this.TokenService.salvaToken('name', resposta);
          resposta = item.perfil ?? '';
          this.TokenService.salvaToken('perfil', resposta);
          this.TokenService.salvaToken('username', item.username);
        }
      });
      if (resposta !== '') {
        return Promise.resolve(true);
      } else {
        return Promise.reject("Credenciais inválidas");
      }
    }

}
