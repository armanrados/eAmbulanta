import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PregledTerminaComponent } from './pregled-termina.component';

describe('PregledTerminaComponent', () => {
  let component: PregledTerminaComponent;
  let fixture: ComponentFixture<PregledTerminaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PregledTerminaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PregledTerminaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
