import { Component, Input, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Sensor } from '../Sensor';
import { SensorLimit } from '../sensor-limit';
import { SensorReading } from '../sensor-reading';

@Component({
  selector: 'app-sensorbanner',
  templateUrl: './sensorbanner.component.html',
  styleUrls: ['./sensorbanner.component.css']
})
export class SensorbannerComponent implements OnInit {
  
  @Input() sensorID : number;
  @Input() roomUUID : string;
  sensorReading : SensorReading = new SensorReading();
  sensorLimit : SensorLimit = new SensorLimit();
  sensor : Sensor = new Sensor();



  constructor(private apiService : ApiService) {
    
   }

  ngOnInit(): void {
    this.apiService.GetSensorLimit(this.sensorID).subscribe(result => {
      this.sensorLimit = result;
      console.log(this.sensorLimit);

    })
    this.apiService.GetSensorReadings(this.roomUUID,this.sensorID,1).subscribe(result => {
      this.sensorReading = result[0];
      console.log(this.sensorReading);
    });

  }


}
