import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalDeletarHeroiComponent } from './modal-deletar-heroi-component';

describe('ModalDeletarHeroiComponent', () => {
  let component: ModalDeletarHeroiComponent;
  let fixture: ComponentFixture<ModalDeletarHeroiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ModalDeletarHeroiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ModalDeletarHeroiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
