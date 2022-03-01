import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {

  tokenIsSet = localStorage.getItem("jwt");

  constructor(
    private router: Router,
  ) { }

  ngOnInit(): void {
  }

  logout(): void {
    localStorage.removeItem("jwt");
    this.router.navigate(['/login']);
  }


}
