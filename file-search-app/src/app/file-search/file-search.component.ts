import { Component } from '@angular/core';
import { FileSearchService } from '../file-search.service';

@Component({
  selector: 'app-file-search',
  templateUrl: './file-search.component.html',
  styleUrls: ['./file-search.component.css']
})
export class FileSearchComponent {
  query: string = '';
  results: any[] = [];

  constructor(private fileSearchService: FileSearchService) { }

  searchFiles(): void {
    if (this.query.trim()) {
      this.fileSearchService.searchFiles(this.query).subscribe(
        (data) => {
          this.results = data;
        },
        (error) => {
          console.error('Error occurred:', error);
        }
      );
    }
  }
}
