import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-render',
  templateUrl: './render.component.html',
  styleUrls: ['./render.component.css']
})
export class RenderComponent implements OnInit {
  private ctx!: CanvasRenderingContext2D;

  private x: number = 10;
  private y: number = 40;

  private dx: number = 3;
  private dy: number = 4;

  private width: number = 0;
  private height: number = 0;

  private obj_width: number = 20;
  private obj_height: number = 40;

  public score: number = 0;

  public color: string = 'red';

  ngOnInit(): void {
    this.ctx = this.canvas.nativeElement.getContext('2d')!;
    this.canvas!.nativeElement.width = window.innerWidth;
    this.canvas!.nativeElement.height = window.innerHeight;
    this.width = this.canvas!.nativeElement.width;
    this.height = this.canvas!.nativeElement.height;
    this.draw();
  }
  @ViewChild('output', { static: true }) canvas!: ElementRef<HTMLCanvasElement>;

  draw() {
    // Animation logic goes here

    // Clear canvas
    this.ctx.clearRect(0, 0, this.width, this.height);
    //this.ctx.clearRect(0, 0, this.canvas!.nativeElement.width, this.canvas!.nativeElement.height);

    // Draw animated elements
    this.ctx.fillStyle = this.color;
    this.ctx.fillRect(this.x, this.y, this.obj_width, this.obj_height);
    //this.ctx.beginPath()
    //this.ctx.ellipse(this.x, this.y, this.obj_width * 0.5, this.obj_height * 0.5, 0, 0, Math.PI * 2);
    //this.ctx.fill();

    this.update();

    // Request next frame
    requestAnimationFrame(() => this.draw());
  }

  update() {
    this.x += this.dx;
    this.y += this.dy;

    let isDchanged = false;

    if (this.x > this.width - this.obj_width || this.x < 0) {this.dx = -this.dx; isDchanged = true }
    if (this.y > this.height - this.obj_height || this.y < 0) {this.dy = -this.dy; isDchanged = true }

    if(isDchanged) {this.score++; this.color = this.getRandomColor()}
  }

  getRandomColor(): string {
    const letters = '0123456789ABCDEF';
    let color = '#';
    for (let i = 0; i < 6; i++) {
      color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
  }

}
