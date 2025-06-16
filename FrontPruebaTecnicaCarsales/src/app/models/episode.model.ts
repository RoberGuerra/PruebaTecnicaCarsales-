import { Info } from "./info.model";

export interface EpisodeDto {
  id: number;
  name: string;
  air_date: string;
  episode: string;
  characters: string[];
  url: string;
  created: string;
}

export interface EpisodeResponse {
  info: Info;
  results: EpisodeDto[];
}