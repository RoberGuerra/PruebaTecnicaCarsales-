import { Info } from "./info.model";

export interface LocationDto {
  id: number;
  name: string;
  type: string;
  dimension: string;
  residents: string[];
  url: string;
  created: string;
}
export interface LocationResponse {
  info: Info;
  results: LocationDto[];
}