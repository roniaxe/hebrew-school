import { createSelector } from '@ngrx/store';
import { selectFeatures, FeaturesState } from '../../features.state';
import { CourseState } from './course.models';

export const selectCourseFeature = createSelector(
  selectFeatures,
  (state: FeaturesState) => state.course
);

export const selectCourses = createSelector(
  selectCourseFeature,
  (state: CourseState) => state.courses
);
