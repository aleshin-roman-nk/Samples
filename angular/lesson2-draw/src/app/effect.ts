import { Mouse } from "./mouse";
import { Particle } from "./particle";

export class Effect {
    canvas: HTMLCanvasElement;
    context!: CanvasRenderingContext2D;
    width: number;
    height: number;
    particles: Particle[];
    numberOfParticles: number;

    gradient: CanvasGradient;
    mouse: Mouse;

    constructor(canvas: HTMLCanvasElement){
        this.canvas = canvas;
        this.width = this.canvas.width;
        this.height = this.canvas.height;
        this.context = this.canvas.getContext('2d')!;

        this.gradient = this.context.createLinearGradient(0, 0, this.width, this.height);
        this.gradient.addColorStop(0, 'white');
        this.gradient.addColorStop(0.5, 'magenta');
        this.gradient.addColorStop(1, 'blue');

        this.context.fillStyle = this.gradient;
        //this.context.strokeStyle = this.gradient;
        this.context.strokeStyle = 'black';

        this.particles = [];
        this.numberOfParticles = 200;
        this.createParticles();

        this.mouse = new Mouse();
    }

    createParticles(){
        for(let i = 0; i < this.numberOfParticles; i++){
            this.particles.push(new Particle(this));
        }
    }

    handleParticles(ctx: CanvasRenderingContext2D){
        this.connectParticles(ctx);
        this.particles.forEach(particle => {
            particle.draw(ctx);
            particle.update();
        });
    }

    connectParticles(ctx: CanvasRenderingContext2D){
        const maxDistance = 100;
        for(let a = 0; a < this.particles.length; a++){
            for(let b = a; b < this.particles.length; b++){
                const dx = this.particles[a].x - this.particles[b].x;
                const dy = this.particles[a].y - this.particles[b].y;
                const distance = Math.hypot(dx, dy);
                const opacity = 1 - (distance / maxDistance);
                ctx.globalAlpha = opacity;
                if(distance < maxDistance){
                    ctx.save();
                    ctx.beginPath();
                    ctx.moveTo(this.particles[a].x, this.particles[a].y);
                    ctx.lineTo(this.particles[b].x, this.particles[b].y);
                    ctx.lineWidth = 2;
                    ctx.stroke();
                    ctx.restore();
                }
            }
        }
    }

    resize(width: number, height: number){
        // this.canvas.width = width;
        // this.canvas.height = height;
        this.width = width;
        this.height = height;
        this.gradient = this.context.createLinearGradient(0, 0, width, height);
        this.gradient.addColorStop(0, 'white');
        this.gradient.addColorStop(0.5, 'magenta');
        this.gradient.addColorStop(1, 'blue');
        this.context.fillStyle = this.gradient;
        this.context.strokeStyle = 'black';
        this.particles.forEach(p => {
            p.reset()
        })
    }

    mousemove(x: number, y:number){
        if(this.mouse.pressed){
            this.mouse.x = x;
            this.mouse.y = y;
        }
    }

    mousepressed(s: boolean){
        this.mouse.pressed = s;
    }
}