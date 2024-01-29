import { of } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';

const switched = of("a", "b", "c").pipe(switchMap(x => of(`from ${x} do XXX`)));

switched.subscribe(x => console.log(x));