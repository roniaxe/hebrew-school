import * as CourseActions from './course.actions';
import { CourseState } from './course.models';

export const courseFeatureKey = 'course';

export const initialState: CourseState = {
  courses: [
    {
      id: 1,
      name: 'test course'
    }
  ]
};

export function courseReducer(state = initialState, action: CourseActions.ActionsUnion): CourseState {
  switch (action.type) {
    case CourseActions.CourseActionTypes.LoadCourses:
      return state;
    case CourseActions.CourseActionTypes.AddCourse:
      return {
        ...state,
        courses: [...state.courses, action.course]
      }
    default:
      return state;
  }
}
