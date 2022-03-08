import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {FormBuilder, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  form: FormGroup;
  invalidRegister: boolean;

  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private router: Router
  ) {}


  ngOnInit(): void {
    this.form = this.formBuilder.group({
      email: '',
      password: '',
      confirmPassword: '',
      firstName: null,
      lastName: null,
      roleId: 2,
      distributionId: 4,
    });
  }

  submit(): void {
    this.http.post("https://localhost:5003/api/users/register", this.form.getRawValue(), {
      responseType: 'text'
    })
      .subscribe({
        next: (response: string) => {
          this.router.navigate(['/'])
        },
        error: (error: any) => {
          this.invalidRegister = true;
        }
      });
  }

}
