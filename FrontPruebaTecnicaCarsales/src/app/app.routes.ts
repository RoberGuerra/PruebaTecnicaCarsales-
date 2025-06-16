import { Routes }                 from '@angular/router';

import { EpisodeListComponent }   from './pages/episode-list/episode-list.component';
import { CharacterComponent } from './pages/character/character.component';
// import { CharacterListComponent } from './pages/character-list/character-list.component';
// import { LocationListComponent }  from './pages/location-list/location-list.component';

export const routes: Routes = [
  { path: '',          redirectTo: 'episodes', pathMatch: 'full' },
  { path: 'episodes',  component: EpisodeListComponent },
  { path: 'character/:id',  component: CharacterComponent },
//   { path: 'characters',component: CharacterListComponent },
//   { path: 'locations', component: LocationListComponent },
  { path: '**',        redirectTo: 'episodes' },
];
