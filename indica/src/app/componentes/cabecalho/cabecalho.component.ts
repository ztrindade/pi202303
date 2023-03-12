import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/autenticacao/usuario/usuario';
import { UsuarioService } from 'src/app/autenticacao/usuario/usuario.service';

@Component({
  selector: 'app-cabecalho',
  templateUrl: './cabecalho.component.html',
  styleUrls: ['./cabecalho.component.css']
})
export class CabecalhoComponent implements OnInit {

  user: Usuario = {
    id: 0,
    name: '',
    perfil: '',
    username: ''
  };

  constructor(
    private usuarioService: UsuarioService,
    private router: Router,
    ) {}

    ngOnInit(): void {
      this.user = this.usuarioService.retornaUsuario();
      console.log(this.user);
    }

  logout( ) {
    this.usuarioService.logout();
    this.user = {
      id: 0,
      name: '',
      perfil: '',
      username: ''
    };
    this.router.navigate(['']);
  }

}
