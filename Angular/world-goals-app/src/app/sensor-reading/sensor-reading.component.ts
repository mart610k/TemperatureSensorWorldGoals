import { HttpClient } from '@angular/common/http';
import { Component,Input, OnInit } from '@angular/core';
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

  
  constructor(private http : HttpClient) {
    
  }

  ngOnInit(): void {
    this.GetSensors();
    
  }

  GetData() {
    console.log("Something");
    for (let index = 0; index < this.sensors.length; index++) {
      this.http.get<SensorReading[]>("https://localhost:44379/api/Room/Readings?Room="+this.room.guid + "&SensorID="+this.sensors[index].sensorID +"&Count=1").subscribe(
      result =>{
        let sensorReading = result[0];
        sensorReading.sensorID = this.sensors[index].sensorID;
        sensorReading.sensorName = this.sensors[index].sensorName;
        this.sensorsReading.push(sensorReading);
      }
    );
      
    }
    
   }

  GetSensors(){
    this.http.get<Sensor[]>("https://localhost:44379/api/Room/Sensors?Room="+this.room.guid).subscribe(
      result =>{
        console.log(result);
        this.sensors = result;
        this.GetData();
      }
    );
  }
}
