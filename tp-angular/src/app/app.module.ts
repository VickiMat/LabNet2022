import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import {MatButtonModule} from '@angular/material/button';
import { CategoriesComponent } from './Northwind/categories/categories/categories.component';
import { NorthwindModule } from './Northwind/northwind.module';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './general/header/header.component';
import { CategoriesModule } from './Northwind/categories/categories.module';
import { HomePageComponent } from './home-page/home-page.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomePageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CategoriesModule,
    NoopAnimationsModule,
    MatButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
