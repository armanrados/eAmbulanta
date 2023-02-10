import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ZakaziTerminComponent } from './zakazi-termin.component';

describe('ZakaziTerminComponent', () => {
  let component: ZakaziTerminComponent;
  let fixture: ComponentFixture<ZakaziTerminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ZakaziTerminComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ZakaziTerminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
