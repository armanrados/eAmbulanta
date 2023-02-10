import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NovaPosjetaComponent } from './nova-posjeta.component';

describe('NovaPosjetaComponent', () => {
  let component: NovaPosjetaComponent;
  let fixture: ComponentFixture<NovaPosjetaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NovaPosjetaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NovaPosjetaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
