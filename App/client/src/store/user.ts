import { Module, VuexModule, Mutation, Action } from 'vuex-module-decorators';

import UserInterface, { LoginInfo, RegisterInfo } from '@/models/User';

import Axios from 'axios';

@Module
export default class User extends VuexModule {
    public isLoggedIn: boolean = false;
    public user: any = {};

    @Mutation
    public setUser(user: any) {
        this.user = user;
    }

    @Mutation
    public setLoginState(isLoggedIn: boolean) {
        this.isLoggedIn = isLoggedIn;
    }


    @Action
    public async login(info: LoginInfo) {
        // console.log(info);
        return await Axios({
            method: 'POST',
            url: 'login',
            data: info,
        });
    }

    @Action
    public async register(info: RegisterInfo) {
        return await Axios({
            method: 'POST',
            url: 'register',
            data: info,
        });
    }

    @Action
    public async getUserInfo(email: string) {
        await Axios({
            method: 'POST',
            url: '/user-info',
            data: {
                email,
            },
        }).then((res) => {
            if (res.data.code === 200) {
                this.context.commit('setUser', res.data.user);
            } else if (res.data.code === 404) {
                // tslint:disable-next-line:no-console
                console.log(res.data.message);
            }
        });
    }

    @Action
    public async getUserProfile(email: string) {
        console.log(email);

        return await Axios({
            method: 'POST',
            url: '/user-info',
            data: {
                email,
            },
        });
    }

}
