export class CurrencyUtils {

  public static StringParaDecimal(input: string): any {
    if (!input) return 0;
    input = input.replace(/[^\d,.]/g, '').replace(/[.,]/g, '');
    let valorNumerico = parseFloat(input);
    let valorFormatado = (valorNumerico / 100).toFixed(2);
    return parseFloat(valorFormatado);
  }
}
