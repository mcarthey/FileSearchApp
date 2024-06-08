import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `<router-outlet></router-outlet>`, // Ensure this is correct
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'file-search-app';
}
