import { createAction, props, union } from '@ngrx/store';
import { Course } from './course.models';

export enum CourseActionTypes {
  LoadCourses = '[Course] Load Courses',
  AddCourse = '[Course] Add Course'
}

// export class LoadCourses implements Action {
//   readonly type = CourseActionTypes.LoadCourses;
// }

export const AddCourse = createAction(CourseActionTypes.AddCourse, props<{course: Course}>());
export const LoadCourses = createAction(CourseActionTypes.LoadCourses);

const actions = union({
  AddCourse,
  LoadCourses,
});

export type ActionsUnion = typeof actions;

