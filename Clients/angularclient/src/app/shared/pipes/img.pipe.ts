import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'base64'
})
export class ImgPipe implements PipeTransform {

  transform(value: any, contentType: string): any {
    var base64Content = `data:${contentType};base64,${value}`;
    return base64Content;
  }

}
