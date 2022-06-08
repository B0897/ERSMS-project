import { RegisterComponent } from './register/register.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component'
import { Listing } from './listing/listing.component'
import { AnimalDetailsComponent } from './animal-details/animal-details.component'
import { PersonDetailsComponent } from './person-details/person-details.component'
import { LoginComponent } from './login/login.component'
import { PrivacyPolicyComponent } from './privacy-policy/privacy-policy.component';


const routes: Routes = [
  { path: 'listing', component:  Listing},
  { path: 'followed', component:  Listing},
  { path: 'profile', component:  PersonDetailsComponent},
  { path: 'animal/:id', component:  AnimalDetailsComponent},
  { path: 'person/:id', component:  PersonDetailsComponent},
  { path: 'login', component:  LoginComponent},
  { path: '', component:  LoginComponent},
  { path: 'register', component: RegisterComponent},
  { path: 'privacy-policy', component: PrivacyPolicyComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

export const routingComponents = [Listing, AnimalDetailsComponent, PersonDetailsComponent];
