import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import {SimpleRoom} from "../simple-room";

@Component({
  selector: 'app-room-brief',
  templateUrl: './room-brief.component.html',
  styleUrls: ['./room-brief.component.css']
})
export class RoomBriefComponent implements OnInit {
  roomData : SimpleRoom[];

  constructor(private apiservice : ApiService) {
  }

  ngOnInit(): void {
    this.apiservice.GetRooms().subscribe(data => this.roomData = data)
  }
}