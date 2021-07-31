import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "http://localhost:52898//api"
constructor(private http:HttpClient) {}
  // Display Students List
  getStuList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Students');
  }
  // Add Student
  addStudents(val:any){
    return this.http.post(this.APIUrl+'/Students',val);
  }
  // Update Students Data
  updateStudents(val:any){
    return this.http.put(this.APIUrl+'/Students',val);
  }
  // Delete Student From List
  deleteStudents(val:any){
    return this.http.delete(this.APIUrl+'/Students/'+val);
  }

}
