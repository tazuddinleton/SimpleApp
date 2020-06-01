import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import {Message} from '../models/notification'


@Injectable()
export class NotificationService {
    
    notifications: Message[] = [];
    messages: Subject<Message[]> =  new Subject<Message[]>();
    constructor(){
        
    }
    notify(msg: Message){     
        this.notifications.push(msg);
        this.messages.next(this.notifications);
    }
}