import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FileSearchComponent } from './file-search/file-search.component';

const routes: Routes = [
  { path: '', component: FileSearchComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' } // Add this route for wildcard
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
