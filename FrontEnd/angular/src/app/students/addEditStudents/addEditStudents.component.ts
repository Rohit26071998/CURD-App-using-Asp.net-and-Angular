import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-addEditStudents',
  templateUrl: './addEditStudents.component.html',
  styleUrls: ['./addEditStudents.component.css']
})
export class AddEditStudentsComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input()
  stu:any;
  SNo:any;
  Name:any;
  Branch:any;
  DOB:any;
  MobileNo:any;
  Address:any;
  State:any;
  Pincode:any;



  ngOnInit():void {
    this.SNo = this.stu.SNo;
    this.Name = this.stu.Name;
    this.Branch = this.stu.Branch;
    this.DOB = this.stu.DOB;
    this.MobileNo = this.stu.MobileNo;
    this.Address = this.stu.Address;
    this.State = this.stu.State;
    this.Pincode = this.stu.Pincode;
  }

  addStudents(){
    var val = {
      SNo:this.SNo,
      Name:this.Name,
      Branch:this.Branch,
      DOB:this.DOB,
      MobileNo:this.MobileNo,
      Address:this.Address,
      State:this.State,
      Pincode:this.Pincode
    };
      this.service.addStudents(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateStudents(){
    var val = {
      SNo:this.SNo,
      Name:this.Name,
      Branch:this.Branch,
      DOB:this.DOB,
      MobileNo:this.MobileNo,
      Address:this.Address,
      State:this.State,
      Pincode:this.Pincode
    };
    this.service.updateStudents(val).subscribe(res=>{
    alert(res.toString());
    });
  }

}
