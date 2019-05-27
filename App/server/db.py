from pymongo import MongoClient, database
import bson.json_util as json
from bson import ObjectId
import datetime

client = MongoClient('mongodb://192.168.99.100:32770')

# DB
campus_net = client.get_database('campus_net')

# region Collections


# endregion


# Getters
    user = users.find_one({'email': email})
    return user


# Actions

# region Auth

def login(email: str, password: str):
    if user is None:
        return {
            'code': 404,
            'message': 'Account does not exist!',
        }
    elif password != user['password']:
        return {
            'code': 404,
            'message': 'Incorrect email or password!',
        }

    if password == user['password']:
        return {
            'code': 200,
            'user': json._json_convert(user),
        }


def register(username: str, email: str, password: str):
    if users.find_one({'email': email}) is None:
        result = users.insert_one({'username': username,
                                   'email': email,
                                   'password': password, }).acknowledged
        print(result)
        return users.find_one(email)
    else:
        return {'code': 409, 'message': 'Account already exists.'}


# endregion


def get_user_by_email(email: str):
    return {
        'code': 200,
        'user': json._json_convert(user),
    } if user is not None else {
        'code': 404,
        'message': 'Account does not exist!',
    }


    result = questions.insert_one(
        {
            'title': title,
            'content': content,
            'email': email,
            'time': datetime.datetime.now().__str__()[0:19]
        }).acknowledged
    # print(result)
    return {
        'code': 200,
        'message': 'Question asked, please wait for answer.'
    } if result else {
        'code': 500,
        'message': 'Error, try again later.'
    }


def get_questions():
    question_list = []
    for question in questions.find().sort('time'):
        question_list.append(question)
        print(question)
    return {
        'code': 200,
        'questionList': json._json_convert(question_list)
    }
    # print()


def get_question(_id: str):
    return {
        'code': 200,
        'question': json._json_convert(result)
    }


def view_counter(q_id: str, u_id: str):
    # 问题浏览次数

    history_list: list = user['question_history']

    if 'views' not in question.keys():
        # 问题浏览记录 字段初始化
        views = question['views'] + 1
        question['views'] = views

    # 用户浏览记录 字段初始化
    if 'question_history' not in user.keys():




    return {
        'code': 200,
    }
