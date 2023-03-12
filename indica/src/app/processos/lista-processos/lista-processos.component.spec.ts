import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaProcessosComponent } from './lista-processos.component';

describe('ListaProcessosComponent', () => {
  let component: ListaProcessosComponent;
  let fixture: ComponentFixture<ListaProcessosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListaProcessosComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListaProcessosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
