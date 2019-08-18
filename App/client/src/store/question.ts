import { Action, Mutation, VuexModule, Module } from 'vuex-module-decorators';
import Axios from 'axios';

@Module
export default class QuestionModule extends VuexModule {

    public latestQuestionList: any[] = [];

    @Mutation
    public setLatestQuestionList(list: any[]) {
        this.latestQuestionList = list;
    }


    @Action
    public async askQuestion(info: any) {
        return await Axios({
            method: 'POST',
            url: '/questions/ask',
            data: {
                ...info,
            },
        });
    }

    @Action
    public async getLatestQuestionList() {
        return await Axios({
            method: 'POST',
            url: '/questions/list',
        }).then((res) => {
            this.context.commit('setLatestQuestionList', res.data.questionList);
        });
    }


    @Action
    public async getQuestionById(id: any) {
        return await Axios({
            method: 'POST',
            url: '/questions/info',
            data: {
                _id: id,
            },
        });
    }

    @Action
    public async viewQuestion(info: { qid: string, uid: string }) {
        // console.log(info);

        return await Axios({
            method: 'POST',
            url: '/questions/view',
            data: {
                q_id: info.qid,
                u_id: info.uid,
            },
        });
    }
    @Action
    public async followQuestion(info: { qid: string, uid: string }) {

        return await Axios({
            method: 'POST',
            url: '/questions/follow',
            data: {
                q_id: info.qid,
                u_id: info.uid,
            },
        });
    }
}
