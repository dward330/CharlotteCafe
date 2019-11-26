import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import 'rxjs/Rx';
import 'rxjs/add/operator/retry';

@Injectable()
export class RestService {

  public headers: HttpHeaders;
  private serverUrl = 'http://localhost:2292/api/values';

  //injecting the http service
  constructor(private http: HttpClient) {
    //setting up the http post request headers
    //this.headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  }

  /**
   * A method for uploading the file to the server using http
   * post method
   */
  request(token) {
    this.http.get(this.serverUrl,
                  {headers: new HttpHeaders().set('Authorization', token)}).subscribe(resp => console.log(resp));
  }

}
