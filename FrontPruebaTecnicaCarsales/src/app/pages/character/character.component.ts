import { Component, OnInit, inject } from '@angular/core';
import { CommonModule }     from '@angular/common';
import { ActivatedRoute, RouterModule }   from '@angular/router';
import { RickAndMortyService } from '../../services/rick-and-morty.service';
import { CharacterDto }     from '../../models/character.model';

@Component({
  selector: 'app-character',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './character.component.html',
  styleUrls: ['./character.component.css']
})
export class CharacterComponent implements OnInit {
  private route = inject(ActivatedRoute);
  private rmService   = inject(RickAndMortyService);

  selectedCh: CharacterDto | null = null;
  loading = true;
  error: string | null = null;

  ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    const ids:number[] = [0];
    ids.push(id);
    this.rmService.getCharactersByIds(ids).subscribe({
      next: ch => {
        this.selectedCh = ch[0];
        this.loading = false;
      },
      error: () => {
        this.error = 'Can not load a character';
        this.loading = false;
      }
    });
  }
}