import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';
@Component({
  selector: 'app-showStudents',
  templateUrl: './showStudents.component.html',
  styleUrls: ['./showStudents.component.css']
})
export class ShowStudentsComponent implements OnInit {

  constructor(private service:SharedService) { }

  StudentsList:any=[];

  ModalTitle:any;
  ActivateAddEditStudentsComp:boolean=false;
  stu:any;


  ngOnInit():void {
    this.refreshStuList();
  }

  addClick(){
    this.stu={
      SNo:0,
      Name:"",
      Branch:"",
      DOB:"",
      MobileNo:"",
      Address:"",
      State:"",
      Pincode:""
    }
    this.ModalTitle="Add New Student";
    this.ActivateAddEditStudentsComp=true;
  }

  editClick(item:any){
    console.log(item);
    this.stu=item;
    this.ModalTitle="Edit Student";
    this.ActivateAddEditStudentsComp=true;
  }

  deleteClick(item:any){
    if(confirm('Are you sure to delete Data??')){
      this.service.deleteStudents(item.SNo).subscribe(data=>{
        alert(data.toString());
        this.refreshStuList();
      })
    }
  }

  closeClick(){
    this.ActivateAddEditStudentsComp=false;
    this.refreshStuList();
  }

  refreshStuList(){
    this.service.getStuList().subscribe(data=>{
      this.StudentsList=data;
    });
  }
}
