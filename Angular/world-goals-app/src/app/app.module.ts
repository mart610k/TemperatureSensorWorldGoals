import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SensorsShowerComponent } from './sensors-shower/sensors-shower.component';
import { RoomBriefComponent } from './room-brief/room-brief.component';
import { SensorbannerComponent } from './sensorbanner/sensorbanner.component';
import { SensorReadingComponent } from './sensor-reading/sensor-reading.component';
import { SchoolDepartmentComponent } from './school-department/school-department.component';

@NgModule({
  declarations: [
    AppComponent,
    SensorsShowerComponent,
    RoomBriefComponent,
    SensorbannerComponent,
    SensorReadingComponent,
    SchoolDepartmentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
