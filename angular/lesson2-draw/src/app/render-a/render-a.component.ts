import { Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import { Effect } from '../effect';

@Component({
  selector: 'app-render-a',
  templateUrl: './render-a.component.html',
  styleUrls: ['./render-a.component.css']
})
export class RenderAComponent implements OnInit {
  width!: number;
  height! : number;
  
  private condext2d!: CanvasRenderingContext2D;
  @ViewChild('output', { static: true }) canvas!: ElementRef<HTMLCanvasElement>;
  
  effect!: Effect;

  ngOnInit(): void {
    this.condext2d = this.canvas.nativeElement.getContext('2d')!;
    this.canvas.nativeElement.width = window.innerWidth;
    this.canvas.nativeElement.height = window.innerHeight;
    this.width = this.canvas.nativeElement.width;
    this.height = this.canvas.nativeElement.height;
    this.effect = new Effect(this.canvas.nativeElement);

    this.run();
  } 

  run() {
    this.condext2d.clearRect(0, 0, this.width, this.height);
    this.effect.handleParticles(this.condext2d);
    requestAnimationFrame(() => this.run());
  }

  @HostListener('window:resize')
  onWindowResize(){
    this.canvas.nativeElement.width = window.innerWidth;
    this.canvas.nativeElement.height = window.innerHeight;
    this.width = this.canvas.nativeElement.width;
    this.height = this.canvas.nativeElement.height;
    this.effect.resize(window.innerWidth, window.innerHeight);
  }

  @HostListener('window:mousemove', ['$event'])
  onMouseMove(event: MouseEvent) {
    this.effect.mousemove(event.clientX, event.clientY);
  }

  @HostListener('window:mousedown', ['$event'])
  onMouseDown(event: MouseEvent) {
    this.effect.mousepressed(true);
    this.effect.mousemove(event.clientX, event.clientY);
  }

  @HostListener('window:mouseup', ['$event'])
  onMouseUp(event: MouseEvent) {
    this.effect.mousepressed(false);
  }
}
