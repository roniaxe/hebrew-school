import { AppState } from '../store/reducers';
import { CourseState } from './course/store/course.models';
import { createFeatureSelector, ActionReducerMap } from '@ngrx/store';
import { courseReducer } from './course/store/course.reducer';

export const FEATURE_NAME = 'features';
export const selectFeatures = createFeatureSelector<State, FeaturesState>(
  FEATURE_NAME
);
export const featureReducers: ActionReducerMap<FeaturesState> = {
  course: courseReducer
};

export interface FeaturesState {
  course: CourseState;
}

export interface State extends AppState {
  features: FeaturesState;
}
