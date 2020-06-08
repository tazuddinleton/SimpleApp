import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import {Message} from '../models/notification'
import { MessageType } from '../models/notification.type';


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

    displayError(msg: string){
        this.notifications.push({message: msg, type: MessageType.error});
        this.messages.next(this.notifications);
    }

    displaySuccess(msg: string){
        this.notifications.push({message: msg, type: MessageType.success});
        this.messages.next(this.notifications);
    }

    displayWarning(msg: string){
        this.notifications.push({message: msg, type: MessageType.warning});
        this.messages.next(this.notifications);
    }

    
    displayInfo(msg: string){
        this.notifications.push({message: msg, type: MessageType.info});
        this.messages.next(this.notifications);
    }
}