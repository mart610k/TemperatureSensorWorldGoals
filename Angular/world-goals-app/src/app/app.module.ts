import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SensorsShowerComponent } from './sensors-shower/sensors-shower.component';
import { RoomBriefComponent } from './room-brief/room-brief.component';

@NgModule({
  declarations: [
    AppComponent,
    SensorsShowerComponent,
    RoomBriefComponent
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
