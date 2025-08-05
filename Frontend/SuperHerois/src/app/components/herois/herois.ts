import { Heroi, Superpoder } from './../../models/heroi.model';
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeroiService } from '../../services/heroi.service';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { ModalHeroiComponent } from '../../modals/modal-heroi-component/modal-heroi-component';
import { ETipoModificacao } from '../../enums/etipo-modificacao';
import { ModalDeletarHeroiComponent } from '../../modals/modal-deletar-heroi-component/modal-deletar-heroi-component';

@Component({
  selector: 'app-herois',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './herois.html',
  styleUrls: ['./herois.scss']
})
export class Herois implements OnInit{
herois: Heroi[] = [];
superpoderes: Superpoder[] = [];
loading = true;

  constructor(private heroiService: HeroiService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.carregarHerois();
    this.carregarSuperpoderes();
  }

  carregarHerois(): void {
    this.loading = true;
    this.heroiService.obterHerois().subscribe({
      next: (herois) => {
        this.herois = herois;
        this.loading = false;
      },
      error: (error) => {
        console.error('Erro ao carregar heróis:', error);
        this.loading = false;
      }
    });
  }

  carregarSuperpoderes(): void {
    this.loading = true;
    this.heroiService.obterSuperpoderes().subscribe({
      next: (superpoderes) => {
        this.superpoderes = superpoderes;
        this.loading = false;
      },
      error: (error) => {
        console.error('Erro ao carregar superpoderes:', error);
        this.loading = false;
      }
    });
  }

  deletarHeroi(heroi: Heroi): void {
  const modalRef: NgbModalRef = this.modalService.open(ModalDeletarHeroiComponent, {
    size: 'lg',
    backdrop: 'static',
    animation: false
  });

  const { componentInstance } = modalRef;
  componentInstance.heroiId = heroi.id;

  modalRef.result.then((sucesso: boolean) => {
    if (sucesso) {
      this.carregarHerois();
    }
  }).catch(() => {});
}

  trackHeroiId(index: number, heroi: Heroi): number {
  return heroi.id;
}

obterIniciais(nomeHeroi: string): string {
  return nomeHeroi
    .split(' ')
    .map(p => p.charAt(0))
    .join('')
    .substring(0, 2)
    .toUpperCase();
}

public abrirModalInclusaoAlteracao(heroi?: Heroi): void {
    const modalRef: NgbModalRef = this.modalService.open(ModalHeroiComponent, {
      size: 'lg',
      backdrop: 'static',
      animation: false
    });

    const { componentInstance } = modalRef;

    if (heroi) {
      componentInstance.heroi = heroi;
      componentInstance.chaveTituloModal = 'Alteração';
      componentInstance.tipoModificacao = ETipoModificacao.Alteracao;
      componentInstance.superpoderes = [...this.superpoderes]
    } else {
      componentInstance.heroi = {
      id: 0,
      nome: '',
      nomeHeroi: '',
      dataNascimento: new Date(),
      altura: 0,
      peso: 0,
      superpoderes: []
    };
      componentInstance.chaveTituloModal = 'Inclusão';
      componentInstance.tipoModificacao = ETipoModificacao.Inclusao;
      componentInstance.superpoderes = this.superpoderes
    }


      modalRef.result.then((sucesso: boolean) => {
    if (sucesso) {
      this.carregarHerois();
    }

}).catch(() => {});
  }
}
