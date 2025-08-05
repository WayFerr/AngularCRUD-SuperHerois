import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HeroFormData, Heroi, Superpoder } from '../../models/heroi.model';
import { ETipoModificacao } from '../../enums/etipo-modificacao';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { HeroiService } from '../../services/heroi.service';

@Component({
  selector: 'app-modal-heroi-component',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './modal-heroi-component.html',
  styleUrl: './modal-heroi-component.scss'
})
export class ModalHeroiComponent implements OnInit {
  @Input() modalType: 'create' | 'edit' = 'create';
  @Input() superpoderes: Superpoder[] = [];

  @Input() heroi: Heroi = {
      id: 0,
      nome: '',
      nomeHeroi: '',
      dataNascimento: new Date(),
      altura: 0,
      peso: 0,
      superpoderes: []
      };
  @Input() public chaveTituloModal!: string
  @Input() public tipoModificacao!: ETipoModificacao

  @Output() saveHero = new EventEmitter<HeroFormData>();

  constructor(private activeModal: NgbActiveModal,
    private heroiService: HeroiService
  ){}

  formData: HeroFormData = {
    nome: '',
    nomeHeroi: '',
    dataNascimento: '',
    altura: 0,
    peso: 0,
    superpoderIds: []
  };

  errors: { [key: string]: string } = {};

  // ngOnInit() {
  //   this.resetForm();
  // }

    ngOnInit(): void {
    if (this.heroi) {
      this.formData = {
        nome: this.heroi.nome,
        nomeHeroi: this.heroi.nomeHeroi,
        dataNascimento: this.formatDateForInput(this.heroi.dataNascimento),
        altura: this.heroi.altura,
        peso: this.heroi.peso,
        superpoderIds: this.heroi.superpoderes.map(sp => sp.id)
      };
    }
  }

  get modalTitle(): string {
    return this.tipoModificacao === ETipoModificacao.Inclusao ? 'Adicionar Novo Herói' : 'Editar Herói';
  }

  get submitButtonText(): string {
    return this.tipoModificacao === ETipoModificacao.Inclusao ? 'Criar Herói' : 'Salvar Alterações';
  }

  loadHeroData() {
    if (this.heroi) {
      this.formData = {
        nome: this.heroi.nome,
        nomeHeroi: this.heroi.nomeHeroi,
        dataNascimento: this.formatDateForInput(this.heroi.dataNascimento),
        altura: this.heroi.altura,
        peso: this.heroi.peso,
        superpoderIds: this.heroi.superpoderes.map(p => p.id)
      };
    }
  }

  resetForm() {
    this.formData = {
      nome: '',
      nomeHeroi: '',
      dataNascimento: '',
      altura: 0,
      peso: 0,
      superpoderIds: []
    };
    this.errors = {};
  }

  formatDateForInput(date: Date): string {
    return new Date(date).toISOString().split('T')[0];
  }

  // onSuperpoderChange(superpoderId: number, event: Event) {
  //   if (isChecked) {
  //     if (!this.formData.superpoderIds.includes(superpoderId)) {
  //       this.formData.superpoderIds.push(superpoderId);
  //     }
  //   } else {
  //     this.formData.superpoderIds = this.formData.superpoderIds.filter(id => id !== superpoderId);
  //   }
  // }

  onSuperpoderChange(superpoderId: number, event: Event): void {
  const inputElement = event.target as HTMLInputElement;
  const isChecked = inputElement?.checked ?? false;

  if (isChecked) {
    if (!this.formData.superpoderIds.includes(superpoderId)) {
      this.formData.superpoderIds.push(superpoderId);
    }
  } else {
    this.formData.superpoderIds = this.formData.superpoderIds.filter(id => id !== superpoderId);
  }
}

  isSuperpoderSelected(superpoderId: number): boolean {
    return this.formData.superpoderIds.includes(superpoderId);
  }

  validateForm(): boolean {
    this.errors = {};
    let isValid = true;

    if (!this.formData.nome.trim()) {
      this.errors['nome'] = 'Nome é obrigatório';
      isValid = false;
    }

    if (!this.formData.nomeHeroi.trim()) {
      this.errors['nomeHeroi'] = 'Nome do herói é obrigatório';
      isValid = false;
    }

    if (!this.formData.dataNascimento) {
      this.errors['dataNascimento'] = 'Data de nascimento é obrigatória';
      isValid = false;
    }

    if (this.formData.altura <= 0) {
      this.errors['altura'] = 'Altura deve ser maior que zero';
      isValid = false;
    }

    if (this.formData.peso <= 0) {
      this.errors['peso'] = 'Peso deve ser maior que zero';
      isValid = false;
    }

    if (this.formData.superpoderIds.length === 0) {
      this.errors['superpoderes'] = 'Selecione pelo menos um superpoder';
      isValid = false;
    }

    return isValid;
  }

 onSubmit() {
  if (!this.validateForm()) return;

  const heroiRequest = {
  nome: this.formData.nome,
  nomeHeroi: this.formData.nomeHeroi,
  dataNascimento: this.formData.dataNascimento,
  altura: this.formData.altura,
  peso: this.formData.peso,
  superpoderIds: [...this.formData.superpoderIds]
};

  const chamada = this.tipoModificacao === ETipoModificacao.Inclusao
    ? this.heroiService.incluirHeroi(heroiRequest )
    : this.heroiService.alterarHeroi(this.heroi.id, heroiRequest );

  chamada.subscribe({
    next: () => {
      this.activeModal.close(true);
    },
    error: (err) => {
      console.error('Erro ao salvar herói:', err);
    }
  });
}

  fecharModal()
  {
    this.activeModal.close();
  }

}
