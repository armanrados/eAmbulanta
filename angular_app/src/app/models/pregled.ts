export interface Pregled{
  id: number;
  odobreno: boolean;
  obavljeno: boolean;
  datum: string;
  vrijeme: string;
  napomena: string;
  odgovor: string;
  dijagnoza : string;
  terapija : string;
  doktorId : string;
  pacijentId : string;
}
