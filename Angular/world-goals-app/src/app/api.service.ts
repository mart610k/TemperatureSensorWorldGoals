import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SimpleRoom } from './simple-room';
import { Sensor } from './sensor';
import { SensorReading } from './sensor-reading';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseAPILink : String = "https://localhost:44379/api";

  constructor(private http : HttpClient) { }


  GetRooms() {
    return this.http.get<SimpleRoom[]>(this.baseAPILink+"/Room/Rooms");
  }

  GetSensors(roomUUID : string){
    return this.http.get<Sensor[]>(this.baseAPILink + "/Room/Sensors?Room="+roomUUID)
  }

  GetSensorReadings(roomUUID : string, sensorID : number,count :number ){
    return this.http.get<SensorReading[]>(this.baseAPILink + "/Room/Readings?Room=" + roomUUID + "&SensorID="+ sensorID +"&Count=" + count);
  }
}