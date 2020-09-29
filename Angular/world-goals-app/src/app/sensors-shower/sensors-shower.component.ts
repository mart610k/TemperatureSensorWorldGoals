import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Sensor} from "../Sensor";

@Component({
  selector: 'app-sensors-shower',
  templateUrl: './sensors-shower.component.html',
  styleUrls: ['./sensors-shower.component.css']
})
export class SensorsShowerComponent implements OnInit {
  sensors : Sensor[] = [] ;

  constructor(private http: HttpClient) { 
    this.GetData()
  }

  ngOnInit(): void {
  }

  GetData() {
    this.http.get<Sensor[]>("https://localhost:44379/api/Sensor/Sensors").subscribe(
      result =>{
        this.sensors = result;
      }
    );
   }
}
