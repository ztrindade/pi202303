import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaIndicacoesComponent } from './lista-indicacoes.component';

describe('ListaIndicacoesComponent', () => {
  let component: ListaIndicacoesComponent;
  let fixture: ComponentFixture<ListaIndicacoesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListaIndicacoesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListaIndicacoesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
