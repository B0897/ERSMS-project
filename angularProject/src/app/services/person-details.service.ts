import { Injectable } from '@angular/core';
import { Account } from '../models/account.model'
import { HttpClient, HttpParams } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class PersonDetailsService {

  constructor(private http: HttpClient) { }

    // TODO popraw linki
    readonly baseURL = 'https://ersms.azurewebsites.net/api/user'
    account: Account = new Account();

    getAccount() {
      this.http.get<Account>(this.baseURL+'/${id}').subscribe(p => {
        this.account = p;
      });
    }

    getAccountByLogin(login: string) {
      let queryParams = new HttpParams();
      queryParams = queryParams.append("login", login);
      this.http.get<Account>(this.baseURL, {params: queryParams}).subscribe(acc => {
        this.account = acc;
      })
    }

  updateAccountByID(ID: string) {
    var fd = new FormData();
    fd.append("ID", ID)
    this.http.post<Account>(this.baseURL + "/ID", fd).subscribe(result => {
      
    })
  }
    
    postAccountnDetails() {
      return this.http.post(this.baseURL, this.account);
    }
}
