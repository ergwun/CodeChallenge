import { Component, Inject, NgZone } from '@angular/core';
import { Assignment } from '../assignment';
import { AssignmentService } from '../assignment.service';

@Component({
  selector: 'app-assignments',
  templateUrl: './assignments.component.html'
})
export class AssignmentsComponent {
  public assignments: Assignment[];

  constructor(
    private zone: NgZone,
    private assignmentService: AssignmentService) {
    this.refresh();
  }

  refresh: () => void = () => {
    this.assignmentService.getAssignments().subscribe(
      result => {
          this.assignments = result;
      },
      error => console.error(error));
  }

  delete(assignmentId: string): void {
    this.assignmentService.deleteAssignment(assignmentId).subscribe(
      result => {
        this.assignments = this.assignments.filter(a => a.id !== assignmentId);
      });
  }
}
