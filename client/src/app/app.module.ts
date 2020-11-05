import { CreateComponent } from './create/create.component';
import { BrowseComponent } from './browse/browse.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { Routes, RouterModule } from '@angular/router'; // CLI imports router
import { CommonModule } from '@angular/common';

const routes: Routes = [
  { path: '', component: BrowseComponent},
  { path: 'create', component: CreateComponent },
];

// configures NgModule imports and exports
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

@NgModule({
  declarations: [
    AppComponent,
    CreateComponent,
    BrowseComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: [RouterModule]
})
export class AppModule { }
