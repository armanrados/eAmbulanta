import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JavneNabavkeComponent } from './javne-nabavke.component';

describe('JavneNabavkeComponent', () => {
  let component: JavneNabavkeComponent;
  let fixture: ComponentFixture<JavneNabavkeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JavneNabavkeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JavneNabavkeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
