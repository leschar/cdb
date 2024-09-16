import { Directive, ElementRef, HostListener, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appCurrencyInput]'
})
export class CurrencyInputDirective {
  constructor(private el: ElementRef<HTMLInputElement>, private renderer: Renderer2) { }

  @HostListener('focus')
  onFocus() {
    if (!this.el.nativeElement.value || this.el.nativeElement.value.trim() === 'R$') {
      this.el.nativeElement.value = 'R$ 0,00';
    }
  }

  @HostListener('blur')
  onBlur() {
    if (!this.el.nativeElement.value || this.el.nativeElement.value === 'R$ 0,00') {
      this.el.nativeElement.value = '';
    }
  }

  @HostListener('input', ['$event'])
  onInput(event: InputEvent) {
    const cleanValue = (event.target as HTMLInputElement).value.replace(/[^\d]/g, '');

    if (cleanValue.length > 0) {
      const numericValue = parseInt(cleanValue, 10) / 100;
      const formattedValue = numericValue.toLocaleString('pt-BR', {
        style: 'currency',
        currency: 'BRL',
        minimumFractionDigits: 2
      });
      (event.target as HTMLInputElement).value = formattedValue;
    } else {
      (event.target as HTMLInputElement).value = 'R$ 0,00';
    }
  }
}
