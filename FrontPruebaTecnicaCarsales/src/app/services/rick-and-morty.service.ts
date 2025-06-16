import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../enviroments/environment';
import { EpisodeResponse } from '../models/episode.model';
import { CharacterResponse, CharacterDto } from '../models/character.model';
import { LocationResponse } from '../models/location.model';
import { Observable } from 'rxjs';

@Injectable(
  {
    providedIn: 'root'
  }
)

export class RickAndMortyService {
  private base = environment.apiBaseUrl;

  constructor(private http: HttpClient) { }

  getEpisodes(page = 1): Observable<EpisodeResponse> {
    return this.http.get<EpisodeResponse>(`${this.base}/episodes`, {
      params: new HttpParams().set('page', page.toString())
    });
  }

  getCharacters(page = 1): Observable<CharacterResponse> {
    return this.http.get<CharacterResponse>(`${this.base}/characters`, {
      params: new HttpParams().set('page', page.toString())
    });
  }

  getLocations(page = 1): Observable<LocationResponse> {
    return this.http.get<LocationResponse>(`${this.base}/locations`, {
      params: new HttpParams().set('page', page.toString())
    });
  }

  getCharactersByIds(ids: number[]): Observable<CharacterDto[]> {
    const idList = ids.join(',');
    const params = new HttpParams().set('ids', idList);
    return this.http.get<CharacterDto[]>(`${this.base}/charactersIds`, { params });
  }
}
