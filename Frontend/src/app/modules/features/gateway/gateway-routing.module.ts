import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from 'core/services/guards/authguard.guard';
import { AddGatewayComponent } from './components/add-gateway/add-gateway.component';
import { AllGatewayComponent } from './components/all-gateway/all-gateway.component';
import { ViewGatewayComponent } from './components/view-gateway/view-gateway.component';

const routes: Routes = [

    {
        path: '',
        redirectTo: 'all',
        pathMatch: 'full'
    },
    {
        path: 'all',
        component: AllGatewayComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'add',
        component: AddGatewayComponent,
        canActivate: [AuthGuard]
    },
    {
        path: ':id',
        component: AddGatewayComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'view/:id',
        component: ViewGatewayComponent,
        canActivate: [AuthGuard]
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class GatewayRoutingModule { }
