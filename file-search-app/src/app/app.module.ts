import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { FileSearchComponent } from './file-search/file-search.component';
import { FileSearchService } from './file-search.service'; // Import the service

const routes: Routes = [
  { path: '', component: FileSearchComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    FileSearchComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes)
  ],
  providers: [FileSearchService], // Provide the service
  bootstrap: [AppComponent]
})
export class AppModule { }
