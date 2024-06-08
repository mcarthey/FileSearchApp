import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileSearchService {
  private apiUrl = 'http://localhost:5000/api/filesearch';

  constructor(private http: HttpClient) { }

  searchFiles(query: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/search?query=${query}`);
  }
}
