import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DashboardService } from '../services/dashboard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  dashboard !: any;
  searchForm !: FormGroup;
  
  constructor(private dashboardService : DashboardService,private fb: FormBuilder) { }

  showLoader = true;

  ngOnInit(): void {
    this.gelAllData();
  }

  gelAllData(){
    this.dashboardService.getdashboard().subscribe((res:any) => {
      this.dashboard = res;
      this.showLoader = false;
    })
  }

}
