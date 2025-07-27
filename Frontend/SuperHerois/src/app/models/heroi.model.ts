export interface Heroi {
  id: number;
  nome: string;
  nomeHeroi: string;
  dataNascimento: Date;
  altura: number;
  peso: number;
  superpoderes: Superpoder[];
}

export interface Superpoder {
  id: number;
  superpoder: string;
  descricao: string;
}

export interface HeroFormData {
  nome: string;
  nomeHeroi: string;
  dataNascimento: string;
  altura: number;
  peso: number;
  superpoderIds: number[];
}
