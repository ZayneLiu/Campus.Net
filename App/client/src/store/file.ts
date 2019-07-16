import { Action, Mutation, VuexModule, Module } from 'vuex-module-decorators';
import Axios from 'axios';

@Module
export default class FileModule extends VuexModule {
    // @Action
    // public async uploadAvatar(file: File) {
    //     return await Axios({
    //         method: 'POST',
    //         url: '/upload/avatar',
    //         data: {
    //             file,
    //         },
    //     });
    // }
}
