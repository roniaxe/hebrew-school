import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { FeaturesState } from '../../features.state';
import { AddCourse } from '../store/course.actions';

@Component({
  selector: 'app-course-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  constructor(private store: Store<FeaturesState>) { }

  ngOnInit() {
    this.store.subscribe(courseState => {
      console.log(courseState);
    });

    this.store.dispatch(AddCourse({course: {id: 2, name: 'added course'}}));
  }

}
