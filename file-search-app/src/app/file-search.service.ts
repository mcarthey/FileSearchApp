import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileSearchService {
  private apiUrl = 'http://file_search_api:5000/api/filesearch';  // Use service name instead of localhost

  constructor(private http: HttpClient) { }

  searchFiles(query: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/search`, { params: { query } });
  }
}
