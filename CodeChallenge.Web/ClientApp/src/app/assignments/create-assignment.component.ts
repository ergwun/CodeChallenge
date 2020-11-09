import { Component, Inject, Input } from '@angular/core';
import { Assignment } from '../assignment';
import { AssignmentService } from '../assignment.service';
import { CustomerDetails } from '../customer-details';
import { FormControl, FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { CarType } from '../car-type';
import { ProblemDetails } from '../problem-details';

@Component({
  selector: 'app-create-assignment',
  templateUrl: './create-assignment.component.html',
  styleUrls: ['./create-assignment.component.css']
})
export class CreateAssignmentComponent {
  enumCarType = CarType;
  public customerDetails: CustomerDetails;
  private form: FormGroup;
  @Input() onCreation: () => void;
  private emptyFormValues: any;
  private submitClicked: boolean = false;
  private showError: boolean = false;
  private errorMessage: string = "Unknown error.";

  constructor(
    formBuilder: FormBuilder,
    private assignmentService: AssignmentService) {
    this.form = formBuilder.group({
      customerName: ['', [Validators.required, Validators.maxLength(70)]],
      speaksGreek: [false, []],
      carType: [null, []]
    });
    this.emptyFormValues = this.form.value;
  }

  get customerName(): AbstractControl { return this.form.get('customerName'); }

  onSubmit(): void {
    this.submitClicked = true;
    this.showError = false;
    if (this.form.valid) {
      this.customerDetails = <CustomerDetails>this.form.value;
      this.assignmentService.createAssignment(this.customerDetails).subscribe(
        result => {
          this.form.reset(this.emptyFormValues);
          this.submitClicked = false;
          this.onCreation();
        },
        error => {
          let problemDetails = <ProblemDetails>error.error;
          this.errorMessage = problemDetails.detail;
          this.showError = true;
        }
      );
    }
  }

  dismissError(): void {
    this.showError = false;
  }
}
