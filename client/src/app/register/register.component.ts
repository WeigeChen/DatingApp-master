import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Observable, Observer, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  
  @Output() cancelRegister = new EventEmitter();
  model: any ={};


  constructor(private accountService :AccountService , private toastr :ToastrService) { }

  ngOnInit(): void {
  }

  register(){
    // console.log(this.model);
    // this.accountService.register(this.model).pipe(
      
    //   map((response)=>{
    //      console.log(response);
    //      alert('test');
    //     this.cancel();
    //     // return response;
    //   }
    //   ))

    this.accountService.register(this.model).subscribe(
    (response) =>{console.log(response),
     this.cancel();
    }
    ,(error)=>{console.log(error);
      this.toastr.error(error.error);
    }
    )
    
    
  }
  cancel(){
    this.cancelRegister.emit(false);
  }

}
