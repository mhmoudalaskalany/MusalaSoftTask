
import { Component, OnInit } from '@angular/core';
import { BaseEditComponent } from 'base/components/base-edit-component';
import { ActivatedRoute } from '@angular/router';
import { Shell } from 'base/components/shell';
import { GatewayService } from 'features/gateway/services/gateway.service';
import { Gateway } from 'features/gateway/models/gateway';
@Component({
    selector: 'app-view-gateway',
    templateUrl: './view-gateway.component.html',
    styleUrls: ['./view-gateway.component.scss'],
})
export class ViewGatewayComponent extends BaseEditComponent implements OnInit {

    model: Gateway;
    get Service(): GatewayService { return Shell.Injector.get(GatewayService); }
    constructor(public route: ActivatedRoute) {
        super(route);
    }


    ngOnInit() {
        super.ngOnInit()
    }


    Redirect(url?: string) {
        const currentRoute = this.Route.url;
        const index = currentRoute.lastIndexOf(url ? url : 'view/');
        const str = currentRoute.substring(0, index);
        this.Route.navigate([str]);
    }





}
