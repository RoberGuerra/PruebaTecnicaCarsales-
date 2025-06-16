import { Info } from "./info.model";

export interface CharacterOrigin {
  name: string;
  url: string;
}
export interface CharacterLocation {
  name: string;
  url: string;
}
export interface CharacterDto {
  id: number;
  name: string;
  status: string;
  species: string;
  type: string;
  gender: string;
  origin: CharacterOrigin;
  location: CharacterLocation;
  image: string;
  episode: string[];
  url: string;
  created: string;
}
export interface CharacterResponse {
  info: Info;
  results: CharacterDto[];
}