import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { TokenService } from '../token.service';
import { Usuario } from './usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private usuarioSubject = new BehaviorSubject<Usuario>({});

  constructor(private tokenService: TokenService) { 
  }

  retornaUsuario () :Usuario {
    let usuario: Usuario = {
      id: 0,
      name: '',
      perfil: '',
      username: ''
    };
    usuario.id = parseInt(this.tokenService.retornaToken('id'));
    usuario.name = this.tokenService.retornaToken('name');
    usuario.perfil = this.tokenService.retornaToken('perfil');
    usuario.username = this.tokenService.retornaToken('username');
    return usuario;
  }

  logout() {
    this.tokenService.limpaTokens();
    this.usuarioSubject.next({});
  }

  estahLogado() {
    return this.tokenService.possuiToken('id');
  }
}
