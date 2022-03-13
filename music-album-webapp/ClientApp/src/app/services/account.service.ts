import {Injectable} from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  accountCreatedAlert: boolean = false;

  changeAccountFlag(state: boolean): void {
    this.accountCreatedAlert = state;
  }

  isNewAccountCreated(): boolean {
    return this.accountCreatedAlert;
  }

  constructor() { }
}
