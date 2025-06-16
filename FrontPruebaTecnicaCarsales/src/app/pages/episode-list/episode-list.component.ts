import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RickAndMortyService } from '../../services/rick-and-morty.service';
import { EpisodeDto } from '../../models/episode.model';
import { Info } from '../../models/info.model';
import { CharacterDto } from '../../models/character.model';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-episode-list',
  templateUrl: './episode-list.component.html',
  styleUrls: ['./episode-list.component.css'],
  imports: [CommonModule, RouterModule]
})
export class EpisodeListComponent implements OnInit {

  episodes: EpisodeDto[] = [];
  info: Info = { count: 0, pages: 0, next: null, prev: null };

  currentPage = 1;
  loading = false;
  error: string | null = null;

  expanded = new Set<number>();
  charsByEpisode: Record<number, CharacterDto[]> = {};

  constructor(private rmService: RickAndMortyService) { }

  ngOnInit() {
    this.loadPage(1);
  }

  loadPage(page: number) {
    this.loading = true;
    this.error = null;

    this.rmService.getEpisodes(page).subscribe({
      next: res => {
        this.episodes = res.results;
        this.info = res.info;
        this.currentPage = page;
        this.loading = false;
      },
      error: err => {
        this.error = 'Error loading episodes - ' + err.message;
        this.loading = false;
      }
    });
  }

  prev() { if (this.info.prev) this.loadPage(this.currentPage - 1); }
  next() { if (this.info.next) this.loadPage(this.currentPage + 1); }

  toggle(ep: EpisodeDto) {
    if (this.expanded.has(ep.id)) {
      this.expanded.delete(ep.id);
    } else {
      this.expanded.add(ep.id);
      if (!this.charsByEpisode[ep.id]) {
        const ids = ep.characters.map(u => +u.split('/').pop()!);
        this.rmService.getCharactersByIds(ids).subscribe({
          next: list => this.charsByEpisode[ep.id] = list,
          error: () => this.charsByEpisode[ep.id] = []
        });
      }
    }
  }

  seasonAndEpisodie(seasonEpisode: string) {
    let splitText = seasonEpisode.split('E', 2);
    const season = parseInt(splitText[0].substring(1, 3)).toString();
    const episode = parseInt(splitText[1]).toString();
    const seParser = 'Season: ' + season + '- Episode: ' + episode ;
    return seParser;
  }
}
