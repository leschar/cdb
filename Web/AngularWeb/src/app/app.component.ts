import { Component } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { CurrencyUtils } from './utils/currency-utils';
import { environment } from '../enviroments/environment';  

export interface InvestimentoResponse {
  resultadoBruto: number;
  resultadoLiquido: number;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'Angular Projeto GFT';
  texto1: string = '';
  texto2: string = '';
  resultData: InvestimentoResponse | undefined;
  errorMessage: string | undefined;

  constructor(public http: HttpClient) { }

  clicouBotao() {
    const data = {
      Valor: CurrencyUtils.StringParaDecimal(this.texto1),
      Meses: parseInt(this.texto2)
    };
    this.http.post<InvestimentoResponse>(environment.apiUrl, data)
      .subscribe(
        (response) => {
          this.resultData = response;
          this.errorMessage = undefined;
        },
        (error: HttpErrorResponse) => {
          console.error('Erro ao enviar dados para a API:', error);

          if (error.status === 400 && error.error && error.error.errors) {
            this.processarMensagensErro(error.error.errors);
          } else {
            this.errorMessage = 'Ocorreu um erro ao processar a solicitação. Tente novamente mais tarde.';
          }
        }
      );
  }

  processarMensagensErro(errors: any) {
    let mensagensErro: string[] = [];

    for (const campoErro in errors) {
      if (errors.hasOwnProperty(campoErro)) {
        const mensagens = errors[campoErro].filter((msg: string) => msg).join('. ');
        if (mensagens) {
          mensagensErro.push(`${mensagens}\n`);
        }
      }
    }

    this.errorMessage = mensagensErro.join('');
  }

  limparResultados() {
    this.resultData = undefined;
    this.texto1 = '';
    this.texto2 = '';
    this.errorMessage = undefined;
  }
}
