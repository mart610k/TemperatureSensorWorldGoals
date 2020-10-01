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
import { BuildingOverviewComponent } from './building-overview/building-overview.component';
import { RoomComponent } from './room/room.component';

@NgModule({
  declarations: [
    AppComponent,
    SensorsShowerComponent,
    RoomBriefComponent,
    SensorbannerComponent,
    SensorReadingComponent,
    SchoolDepartmentComponent,
    BuildingOverviewComponent,
    RoomComponent
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
