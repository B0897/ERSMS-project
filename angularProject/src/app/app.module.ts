import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'
import { AppRoutingModule, routingComponents } from './app-routing.module'

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { Listing } from './listing/listing.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AnimalCard } from './animal-card/animal-card.component';
import { Form } from './form/form.component';
import { AnimalDetailsComponent } from './animal-details/animal-details.component';
import { AnimalDetailsFormComponent } from './animal-details/animal-details-form/animal-details-form.component';
import { PersonDetailsComponent } from './person-details/person-details.component';
import { PersonDetailsFormComponent } from './person-details/person-details-form/person-details-form.component';
import { FileUploadComponent } from './file-upload/file-upload.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { PrivacyPolicyComponent } from './privacy-policy/privacy-policy.component';



@NgModule({
  declarations: [
    routingComponents,
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AnimalCard,
    Form,
    Listing,
    AnimalDetailsFormComponent,
    PersonDetailsFormComponent,
    FileUploadComponent,
    LoginComponent,
    RegisterComponent,
    PrivacyPolicyComponent,
  ],
  imports: [
    BrowserModule, HttpClientModule, RouterModule, FormsModule, AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [NO_ERRORS_SCHEMA]
})
export class AppModule { }
