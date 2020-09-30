import { Component,Input, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Sensor } from '../Sensor';
import { SensorReading} from "../sensor-reading";
import { SimpleRoom } from '../simple-room';


@Component({
  selector: 'app-sensor-reading',
  templateUrl: './sensor-reading.component.html',
  styleUrls: ['./sensor-reading.component.css']
})
export class SensorReadingComponent implements OnInit {
  
  sensorsReading : SensorReading[] = [];
  sensors : Sensor[] = [];

  @Input() room : SimpleRoom;
  
  constructor(private apiService : ApiService) {
    
  }

  ngOnInit(): void {
    this.apiService.GetSensors(this.room.guid).subscribe(result => {this.sensors = result; this.GetData()});
  }

  GetData() {
    for (let index = 0; index < this.sensors.length; index++) {
      this.apiService.GetSensorReadings(this.room.guid,this.sensors[index].sensorID,1).subscribe(result => {
        let sensorReading = result[0];
        sensorReading.sensorID = this.sensors[index].sensorID;
        sensorReading.sensorName = this.sensors[index].sensorName;
        this.sensorsReading.push(sensorReading);
      } 
      );
    }
   }
}
