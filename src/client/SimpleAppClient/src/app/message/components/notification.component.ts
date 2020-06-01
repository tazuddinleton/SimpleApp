import { Component, OnInit } from '@angular/core';
import { NotificationService } from '../services/notification.service';
import { Message } from '../models/notification';
import { MessageType } from '../models/notification.type';


@Component({
    selector: 'notification',
    templateUrl: './notification.component.html'
})
export class NotificationComponent implements OnInit{
    messages: Message[] = [];
    notificationType: any;

    constructor(private notificationService: NotificationService){        
        this.notificationType = MessageType;        
    }
    ngOnInit(): void {
        this.notificationService.messages.subscribe(messages => this.messages = messages);
    }
}