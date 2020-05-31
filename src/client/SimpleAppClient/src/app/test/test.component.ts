import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'test',
    templateUrl: './template.html',
})
export class TestComponent implements OnInit{

    public pageTitle: string = "This is product list page!";    
    public items :number[] = [];
    constructor(){
        
    }
    ngOnInit(): void {
        this.items = [3,4,5];
    }
}