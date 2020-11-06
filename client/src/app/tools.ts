export class Tools {


  public static decode(str: string): string {
    return Tools.convertHTMLEntity(str);
  }

  public static convertHTMLEntity(text: string) : string{
    const span = document.createElement('span');

    return text
    .replace(/&[#A-Za-z0-9]+;/gi, (entity,position,text)=> {
        span.innerHTML = entity;
        return span.innerText;
    });
}


}
