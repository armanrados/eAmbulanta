import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OglasiComponent } from './oglasi.component';

describe('OglasiComponent', () => {
  let component: OglasiComponent;
  let fixture: ComponentFixture<OglasiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OglasiComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OglasiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
