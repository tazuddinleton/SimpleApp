import { Injectable } from '@angular/core';

@Injectable()
export class NotificationService {
    constructor(){

    }

    notify(msg: string){
        // will be implemented later
        console.log(msg);
    }
}