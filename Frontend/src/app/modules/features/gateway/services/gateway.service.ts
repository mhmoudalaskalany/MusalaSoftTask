import { Observable } from 'rxjs';
import { HttpService } from 'core/services/http/http.service';
import { Injectable } from "@angular/core";
import { Result } from 'shared/models/result';
import { Gateway } from '../models/gateway';

@Injectable({
    providedIn: 'root'
})

export class GatewayService extends HttpService {
    get baseUrl(): string {
        return 'Gateways/'
    }

    getById(id): Observable<Result<Gateway>> {
        return this.getTypedReq<Gateway>('GetByIdForEdit/' + id);
    }
    getAll(): Observable<Result<Gateway>> {
        return this.getTypedReq<Gateway>('GetAll');
    }
}