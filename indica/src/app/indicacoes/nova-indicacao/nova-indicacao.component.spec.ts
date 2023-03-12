import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NovaIndicacaoComponent } from './nova-indicacao.component';

describe('NovaIndicacaoComponent', () => {
  let component: NovaIndicacaoComponent;
  let fixture: ComponentFixture<NovaIndicacaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NovaIndicacaoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NovaIndicacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
