import { NgModule } from '@angular/core';
import { TestComponent } from './test.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@NgModule({
    declarations: [      
      TestComponent
    ],
    imports: [     
        CommonModule,
        RouterModule.forRoot([              
        {path: 'test', component: TestComponent},
      ]),         
    ],
    providers: [],
    
  })
export class TestModule{

}


