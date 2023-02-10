import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PosjeteComponent } from './posjete.component';

describe('PosjeteComponent', () => {
  let component: PosjeteComponent;
  let fixture: ComponentFixture<PosjeteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PosjeteComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PosjeteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
