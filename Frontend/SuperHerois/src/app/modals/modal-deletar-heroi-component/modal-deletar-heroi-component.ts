import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { HeroiService } from '../../services/heroi.service';

@Component({
  selector: 'app-modal-deletar-heroi-component',
  standalone: true,
  templateUrl: './modal-deletar-heroi-component.html',
  styleUrl: './modal-deletar-heroi-component.scss'
})
export class ModalDeletarHeroiComponent {
   @Input() heroiId: number | null = null;

  constructor(public activeModal: NgbActiveModal,
    private heroiService: HeroiService
  ) {}

  fechar(): void {
    this.activeModal.dismiss();
  }

  confirmarExclusao(): void {
    if (this.heroiId !== null) {
      this.heroiService.deletarHeroi(this.heroiId).subscribe({
        next: () => this.activeModal.close(true),
        error: (err) => {
          console.error('Erro ao deletar herói:', err);
          this.activeModal.dismiss();
        }
      });
    }
  }
}
