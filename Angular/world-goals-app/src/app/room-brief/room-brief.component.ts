import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {SimpleRoom} from "../simple-room";

@Component({
  selector: 'app-room-brief',
  templateUrl: './room-brief.component.html',
  styleUrls: ['./room-brief.component.css']
})
export class RoomBriefComponent implements OnInit {
  roomData : SimpleRoom[]; 


  constructor(private http : HttpClient) {
    this.GetRooms();
   }

  ngOnInit(): void {
  }

  GetRooms(){
    this.http.get<SimpleRoom[]>("https://localhost:44379/api/Room/Rooms").subscribe(
      result => 
      { 
        console.log(result);
        this.roomData = result; 
      }
    );
  }
}