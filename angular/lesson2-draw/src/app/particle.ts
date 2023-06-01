import { Effect } from "./effect";

export class Particle {
    
    effect: Effect;
    x: number;
    y: number;
    radius: number;

    vx: number;
    vy: number;

    constructor(effect: Effect){
        this.effect = effect;
        this.radius = Math.random() * 5 + 2;
        this.x = this.radius + Math.random() * (this.effect.width - this.radius * 2);
        this.y = this.radius + Math.random() * (this.effect.height - this.radius * 2);
        this.vx = Math.random() * 2 - 1;
        this.vy = Math.random() * 2 - 1;
    }

    draw(ctx: CanvasRenderingContext2D){
        //ctx.fillStyle = `hsl(${ this.x * 0.5 }, 100%, 50%)`
        //ctx.fillStyle = "red"
        ctx.beginPath();
        ctx.arc(this.x, this.y, this.radius, 0, Math.PI * 2);
        ctx.fill();
        //ctx.stroke();
        ctx.lineWidth = 2
    }

    update(){
        if(this.effect.mouse.pressed){
            const dx = this.x - this.effect.mouse.x;
            const dy = this.y - this.effect.mouse.y;
            const distance = Math.hypot(dx, dy);
            const force = this.effect.mouse.radius / distance;
            if(distance < this.effect.mouse.radius){
                const angle = Math.atan2(dy, dx);
                this.x += Math.cos(angle);
                this.y += Math.sin(angle);
            }
        }

        this.x += this.vx;
        if(this.x > this.effect.width - this.radius || this.x < this.radius) this.vx *= -1;
        this.y += this.vy;
        if(this.y > this.effect.height - this.radius || this.y < this.radius) this.vy *= -1;
    }

    reset(){
        this.x = this.radius + Math.random() * (this.effect.width - this.radius * 2);
        this.y = this.radius + Math.random() * (this.effect.height - this.radius * 2);
    }
}