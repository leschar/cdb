import { TestBed, ComponentFixture, tick,fakeAsync  } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { By } from '@angular/platform-browser';


describe('AppComponent', () => {
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AppComponent],
      imports: [HttpClientModule, FormsModule]
    }).compileComponents();

    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('Criar o app', () => {
    expect(component).toBeTruthy();
  });

  it('Limpar os resultados', () => {
    component.resultData = {
      resultadoBruto: 1000,
      resultadoLiquido: 800
    };
    component.texto1 = '1000';
    component.texto2 = '12';
    component.errorMessage = 'Alguma mensagem de erro';

    component.limparResultados();

    expect(component.resultData).toBeUndefined();
    expect(component.texto1).toBe('');
    expect(component.texto2).toBe('');
    expect(component.errorMessage).toBeUndefined();
  });

   it(`Deve localizar o titulo da pagina`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
     expect(app.title).toEqual('Angular Projeto GFT');
   });

   it(`Deve localizar os itens da pagina`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    const inputTexto1 = fixture.debugElement.query(By.css('input[placeholder="R$ Ex: 1000,00"]'));
    const inputTexto2 = fixture.debugElement.query(By.css('input[placeholder="Meses para simulação | Ex: 1"]'));
    const divElement = fixture.debugElement.query(By.css('.mt-5')); 
    const buttonEnviar = divElement.query(By.css('.btn-primary')); 
    const buttonLimpar = divElement.query(By.css('.btn-secondary')); 

    expect(app.title).toEqual('Angular Projeto GFT');
    expect(inputTexto1).toBeTruthy();
    expect(inputTexto2).toBeTruthy();
    expect(divElement).toBeTruthy(); 
    expect(buttonEnviar).toBeTruthy(); 
    expect(buttonLimpar).toBeTruthy(); 

   });

   
   xit('Deve verificar valor correto após interação', fakeAsync(() => {
    const input1 = fixture.debugElement.query(By.css('input[placeholder="R$ Ex: 1000,00"]')).nativeElement;
    const input2 = fixture.debugElement.query(By.css('input[placeholder="Meses para simulação | Ex: 1"]')).nativeElement;

    input1.value = '500';
    input1.dispatchEvent(new Event('input'));

    input2.focus();
    input2.value = '6';
    input2.dispatchEvent(new Event('input'));


    tick();
    fixture.detectChanges();

    expect(component.texto1).toBe('500');
    expect(+component.texto2).toBe(6);
  }));


  xit('Deve verificar valor correto após interação com botão', () => {
    const input1 = fixture.debugElement.query(By.css('input[placeholder="R$ Ex: 1000,00"]')).nativeElement;
    const input2 = fixture.debugElement.query(By.css('input[placeholder="Meses para simulação | Ex: 1"]')).nativeElement;
    const button = fixture.debugElement.query(By.css('button[style="margin-right: 40px;"]')).nativeElement;
  
    input1.value = '1000';
    input1.dispatchEvent(new Event('input'));
  
    input2.value = '6';
    input2.dispatchEvent(new Event('input'));
  
    button.click();
  
    fixture.detectChanges();
    expect(component.texto1).toBe('1000');
    expect(+component.texto2).toBe(6);
  });
  

});
