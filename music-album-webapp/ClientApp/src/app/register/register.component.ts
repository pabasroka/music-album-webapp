import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {FormBuilder, FormGroup} from "@angular/forms";
import {Distribution} from "../models/Distribution";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  form: FormGroup;
  invalidRegister: boolean;
  distributions: Array<Distribution> = [];

  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.initForm();
    this.getDistributions();
  }

  initForm(): void {
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

  getDistributions(): void {
    this.http.get("https://localhost:5003/api/distributions", {
      responseType: "text",
    }).subscribe((data) => {

      const parsedData = JSON.parse(data);

      parsedData.forEach((el: { id: number; name: string; }) => {
        if (el.id != null && el.name != null) {
          this.distributions.push(new Distribution(el.id, el.name));
        }
      })

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
