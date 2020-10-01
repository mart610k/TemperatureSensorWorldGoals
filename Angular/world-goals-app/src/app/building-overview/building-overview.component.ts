import { compileNgModule } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { SimpleRoom } from '../simple-room';

@Component({
  selector: 'app-building-overview',
  templateUrl: './building-overview.component.html',
  styleUrls: ['./building-overview.component.css']
})
export class BuildingOverviewComponent implements OnInit {

  constructor(private apiService : ApiService) {

    this.apiService.GetRooms().subscribe(result => {
      this.rooms = result;
      console.log(result);
    });
   }

  rooms: SimpleRoom[] = []

  FindRoomByName(roomName : string){
    let toreturn : SimpleRoom = undefined ;
    toreturn = this.rooms.find(x => x.name === roomName);
    

    return toreturn; 
    
  }
  

  ngOnInit(): void {


  }



}
