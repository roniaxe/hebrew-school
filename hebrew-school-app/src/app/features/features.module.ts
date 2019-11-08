import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseModule } from './course/course.module';
import { StoreModule } from '@ngrx/store';
import { FEATURE_NAME, featureReducers } from './features.state';
import { EffectsModule } from '@ngrx/effects';
import { CourseEffects } from './course/store/course.effects';
import { ListComponent } from './course/list/list.component';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    CourseModule,
    StoreModule.forFeature(FEATURE_NAME, featureReducers),
    EffectsModule.forFeature([CourseEffects])
  ]
})
export class FeaturesModule { }
