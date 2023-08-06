import { ApplicationRef, EmbeddedViewRef, Injectable, ViewContainerRef } from '@angular/core';
import { ModalAComponent } from '../modal-a/modal-a.component';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ModalAServiceService {

  constructor(private viewContainerRef: ViewContainerRef, private appRef: ApplicationRef) {}

  show(title: string, message: string): Promise<boolean> {
    return new Promise<boolean>((resolve) => {

      //const componentFactory = this.componentFactoryResolver.resolveComponentFactory(ModalAComponent);
      //const componentRef = componentFactory.create(this.injector);
      const componentRef = this.viewContainerRef.createComponent(ModalAComponent)

      componentRef.instance.title = title;
      componentRef.instance.message = message;
      componentRef.instance.finished.subscribe((result: boolean) => {
        this.appRef.detachView(componentRef.hostView);
        componentRef.destroy();
        resolve(result);
      });

      this.appRef.attachView(componentRef.hostView);
      const domElem = (componentRef.hostView as EmbeddedViewRef<any>).rootNodes[0] as HTMLElement;
      document.body.appendChild(domElem);
    });
  }

/*   show<TModalComponent>(modalCompType: TModalComponent): Observable<UserMessage> {
    return new Promise<boolean>((resolve) => {

      const componentRef = this.viewContainerRef.createComponent(modalCompType)

      componentRef.instance.closeModal.subscribe((result: boolean) => {
        this.appRef.detachView(componentRef.hostView);
        componentRef.destroy();
        resolve(result);
      });

      this.appRef.attachView(componentRef.hostView);
      const domElem = (componentRef.hostView as EmbeddedViewRef<any>).rootNodes[0] as HTMLElement;
      document.body.appendChild(domElem);
    });
  } */

}
