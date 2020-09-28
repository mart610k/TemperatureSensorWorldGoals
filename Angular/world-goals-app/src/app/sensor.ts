export class Sensor {
    /**
     *
     */
    sensorID : number;
    sensorName : string;

    
    constructor(sensorID : number, sensorName : string) {
        this.sensorID = sensorID;

        this.sensorName = sensorName;
    }
}
