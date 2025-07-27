import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalHeroiComponent } from './modal-heroi-component';

describe('ModalHeroiComponent', () => {
  let component: ModalHeroiComponent;
  let fixture: ComponentFixture<ModalHeroiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ModalHeroiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ModalHeroiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
