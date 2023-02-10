import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PregledNovostComponent } from './pregled-novost.component';

describe('PregledNovostComponent', () => {
  let component: PregledNovostComponent;
  let fixture: ComponentFixture<PregledNovostComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PregledNovostComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PregledNovostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
