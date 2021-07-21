import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';


@Component({
  selector: 'app-show-all',
  templateUrl: './show-all.component.html',
  styleUrls: ['./show-all.component.css']
})
export class ShowAllComponent implements OnInit {

  constructor(private service:SharedService) { }

  CustomersList:any=[];

  ngOnInit(): void{
    this.refreshCustomersList();
  }


  refreshCustomersList()
  {
    this.service.getCustomerList().subscribe(data=>{
      this.CustomersList = data;
    })
  }
}
