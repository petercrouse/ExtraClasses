import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from '@_app/app-routing.module';
import { AppComponent } from '@_app/containers/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CoreModule } from '@_core/core.module';
import { MenubarComponent } from '@_app/components/menubar/menubar.component';
import { SidenavComponent } from '@_app/components/sidenav/sidenav.component';
import { SharedModule } from '@_shared/shared.module';

@NgModule({
  declarations: [
    AppComponent,
    MenubarComponent,
    SidenavComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CoreModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
