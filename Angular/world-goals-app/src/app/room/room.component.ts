import { Component, Input, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Sensor } from '../sensor';
import { SensorReading } from '../sensor-reading';
import { SimpleRoom } from '../simple-room';
import { interval} from 'rxjs';
import { SensorLimit } from '../sensor-limit';


@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.css']
})
export class RoomComponent implements OnInit {

  room: SimpleRoom;
  @Input() roomName: string;
  refreshTime = interval(10 * 1000);
  sensors: Sensor[] = [];
  sensorReadings: SensorReading[] = [];
  constructor(private apiService: ApiService) {

    this.apiService.GetRooms().subscribe(result => {
      this.room = this.FindRoomByName(this.roomName, result);
      if (this.room !== undefined) {
        apiService.GetSensors(this.room.guid).subscribe(result => {
          this.sensors = result;
          this.GetData();
          this.refreshTime.subscribe(() => this.GetData())
        });
        
      }
    });
  }

  FindRoomByName(roomName: string, rooms: SimpleRoom[]): SimpleRoom {
    let toreturn: SimpleRoom = undefined;
    toreturn = rooms.find(x => x.name === roomName);
    return toreturn;
  }

  ngOnInit(): void {
    
  }
  
  GetSensorLimitInfo(sensorID : number) {
    this.apiService.GetSensorLimit(sensorID).subscribe(result => {
      return result;
    });
  }

  GetData() {
    this.sensorReadings = [];
    for (let index = 0; index < this.sensors.length; index++) {
      
      this.apiService.GetSensorReadings(this.room.guid, this.sensors[index].sensorID, 1).subscribe(result => {
        let sensorReading = result[0];
        sensorReading.sensorID = this.sensors[index].sensorID;
        sensorReading.sensorName = this.sensors[index].sensorName;
        this.sensorReadings.push(sensorReading);
        this.sensorReadings.sort(function(a, b) {
          return a.sensorID - b.sensorID;
      });
      }
      );

    }
  }
}
