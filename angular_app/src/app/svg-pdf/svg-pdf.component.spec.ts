import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SvgPDFComponent } from './svg-pdf.component';

describe('SvgPDFComponent', () => {
  let component: SvgPDFComponent;
  let fixture: ComponentFixture<SvgPDFComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SvgPDFComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SvgPDFComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
