import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OdlukeComponent } from './odluke.component';

describe('OdlukeComponent', () => {
  let component: OdlukeComponent;
  let fixture: ComponentFixture<OdlukeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OdlukeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OdlukeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
