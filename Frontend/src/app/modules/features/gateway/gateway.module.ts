
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'shared/shared.module';
import { AddGatewayComponent } from './components/add-gateway/add-gateway.component';
import { AllGatewayComponent } from './components/all-gateway/all-gateway.component';
import { GatewayRoutingModule } from './gateway-routing.module';
import { ViewGatewayComponent } from './components/view-gateway/view-gateway.component';


@NgModule({
    declarations: [
        AllGatewayComponent,
        AddGatewayComponent,
        ViewGatewayComponent
    ],
    imports: [
        CommonModule,
        SharedModule,
        GatewayRoutingModule
    ]
})
export class GatewayModule { }
