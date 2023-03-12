import { Injectable, Input } from '@angular/core';

// const KEY = 'token';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  constructor() { }

  retornaToken(chave: string) :string {
    return sessionStorage.getItem(chave) ?? '';
  }

  salvaToken(chave: string, token: string) :void {
    sessionStorage.setItem(chave, token);
  }

  excluiToken(chave: string) :void {
    sessionStorage.removeItem(chave);
  }

  possuiToken(chave: string) :boolean {
    return !!this.retornaToken(chave);
  }

  limpaTokens() :void {
    sessionStorage.clear();
  }

}
