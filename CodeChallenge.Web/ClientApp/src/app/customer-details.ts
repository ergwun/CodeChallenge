import { CarType } from "./car-type";

export interface CustomerDetails {
  customerName: string;
  speaksGreek: boolean;
  carTypePreference: CarType | null;
}
