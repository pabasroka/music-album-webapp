import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import {AccountService} from "../services/account.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  form: FormGroup;
  invalidLogin: boolean;
  accountCreatedAlert: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private router: Router,
    private accountService: AccountService,
  ) {
    this.accountCreatedAlert = accountService.isNewAccountCreated();
  }


  ngOnInit(): void {
    this.form = this.formBuilder.group({
      email: '',
      password: '',
    });
  }

  submit(): void {
    this.http.post("https://localhost:5003/api/users/login", this.form.getRawValue(), {
      withCredentials: true,
      responseType: 'text'
    })
    .subscribe({
      next: (response: string) => {
        localStorage.setItem("jwt", response)
        this.invalidLogin = false;
        this.router.navigate(['/'])
      },
      error: (error: any) => {
        this.invalidLogin = true;
      }
    });
  }

}
