import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UrediPosjetuComponent } from './uredi-posjetu.component';

describe('UrediPosjetuComponent', () => {
  let component: UrediPosjetuComponent;
  let fixture: ComponentFixture<UrediPosjetuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UrediPosjetuComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UrediPosjetuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
