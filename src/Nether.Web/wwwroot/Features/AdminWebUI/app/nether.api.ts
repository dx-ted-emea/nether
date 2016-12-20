﻿import { Injectable } from "@angular/core";
import { Http, Response, Headers, RequestOptions } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { Player, Group } from "./model";
import "rxjs/add/operator/catch";
import "rxjs/add/operator/do";
import "rxjs/add/operator/map";
import "rxjs/add/operator/mergeMap";
import "rxjs/add/observable/of";

@Injectable()
export class NetherApiService {

    private _serverUrl: string = "http://localhost:5000/";
    private _clientId: string = "resourceowner-test";
    private _clientSecret: string = "devsecret";
    private _headers: Headers = new Headers({ "Content-Type": "application/json" });
    private _endpointConfig: EndpointConfiguration;
    private _token: TokenResponse;

    constructor(private _http: Http) {
    }

    login(username: string, password: string): Observable<string> {
        return this._http.get(this._serverUrl + ".well-known/openid-configuration")
            .map(response => <EndpointConfiguration>response.json())
            .flatMap(config => {

                this._endpointConfig = config;
                console.log("token endpoint: " + config.token_endpoint);
                let authHead = btoa(this._clientId + ":" + this._clientSecret);
                let formData = `grant_type=password&username=${username}&password=${password}&scope=nether-all`;

                return this._http.post(config.token_endpoint, formData,
                    new RequestOptions({
                        headers: new Headers({
                            "Authorization": "Basic " + authHead,
                            "Content-Type": "application/x-www-form-urlencoded"
                        })
                    }))
                    .map(response => {
                        let token = <TokenResponse>response.json();
                        console.log(token);
                        this._token = token;
                        return token.access_token;
                    });
            });
    }

    getCurrentPlayer(): Observable<Player> {
        return this._http.get(this._serverUrl + "api/player", this.getRequestOptions())
            .map((response: Response) => response.json().player);
    }

    getAllPlayers(): Observable<Player[]> {
        return this._http.get(this._serverUrl + "api/players", this.getRequestOptions())
            .map(response => response.json().players);
    }



    private getRequestOptions(): RequestOptions {
        return new RequestOptions({
            headers: new Headers({
                "Authorization": this._token.token_type + " " + this._token.access_token
                })
        });
    }
}

//subset of endpoint configuraiton
class EndpointConfiguration {
    issuer: string;
    jwks_uri: string;
    authorization_endpoint: string;
    token_endpoint: string;
    scopes_supported: string[];
    claims_supported: string[];
}

//subset of token response
class TokenResponse {
    access_token: string;
    expires_in: number;
    token_type: string;
}