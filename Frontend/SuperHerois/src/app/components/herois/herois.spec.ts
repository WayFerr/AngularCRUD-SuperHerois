import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Herois } from './herois';

describe('Herois', () => {
  let component: Herois;
  let fixture: ComponentFixture<Herois>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Herois]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Herois);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
