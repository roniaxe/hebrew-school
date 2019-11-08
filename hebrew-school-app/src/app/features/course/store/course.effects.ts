import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';

import { concatMap } from 'rxjs/operators';
import { EMPTY } from 'rxjs';
import { CourseActionTypes } from './course.actions';
import * as CourseActions from './course.actions';



@Injectable()
export class CourseEffects {


  @Effect()
  loadCourses$ = this.actions$.pipe(
    ofType(CourseActionTypes.LoadCourses),
    /** An EMPTY observable only emits completion. Replace with your own observable API request */
    concatMap(() => EMPTY)
  );


  constructor(private actions$: Actions<CourseActions.ActionsUnion>) {}

}
