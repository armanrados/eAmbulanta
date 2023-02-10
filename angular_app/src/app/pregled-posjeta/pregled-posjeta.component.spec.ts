import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PregledPosjetaComponent } from './pregled-posjeta.component';

describe('PregledPosjetaComponent', () => {
  let component: PregledPosjetaComponent;
  let fixture: ComponentFixture<PregledPosjetaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PregledPosjetaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PregledPosjetaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
