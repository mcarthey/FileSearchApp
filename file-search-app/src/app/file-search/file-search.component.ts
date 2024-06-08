import { Component } from '@angular/core';
import { FileSearchService } from '../file-search.service';  // Adjusted path

@Component({
  selector: 'app-file-search',
  templateUrl: './file-search.component.html',
  styleUrls: ['./file-search.component.css']
})
export class FileSearchComponent {
  query: string = '';
  results: any[] = [];

  constructor(private fileSearchService: FileSearchService) { }

  onSearch() {
    this.fileSearchService.searchFiles(this.query).subscribe(results => {
      this.results = results;
    });
  }
}
