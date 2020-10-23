import { Component, OnDestroy, OnInit } from '@angular/core';

@Component({
  selector: 'app-public-index',
  templateUrl: './public-index.component.html',
  styleUrls: ['./public-index.component.scss']
})
export class PublicIndexComponent implements OnInit {
  // form: FormGroup;

  // constructor(private fb: FormBuilder, private router: Router) {
  // this.form = this.fb.group({
  //   email: ['', [Validators.required, Validators.email]],
  //   password: ['', [Validators.required]]
  // });
  // }

  constructor() {}

  ngOnInit() {}

  // onSubmit() {
  //   this.router.navigate(['/home']);
  //   console.log(this.form.value);
  //   if (this.form.valid) {
  //   }
  // }
}
