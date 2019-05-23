from pymongo import MongoClient, database
import bson.json_util as json
from bson import ObjectId
import datetime

client = MongoClient('mongodb://192.168.99.100:32770')

# DB
campus_net = client.get_database('campus_net')

# region Collections
users = campus_net.get_collection('users')
questions = campus_net.get_collection('questions')


# endregion


# Getters
def get_user(email: str):
    user = users.find_one({'email': email})
    return user


# Actions

# region Auth

def login(email: str, password: str):
    user = get_user(email)
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
    user = get_user(email=email)
    return {
        'code': 200,
        'user': json._json_convert(user),
    } if user is not None else {
        'code': 404,
        'message': 'Account does not exist!',
    }


def ask_question(title: str, content: str, email: str):
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
    result = questions.find_one({'_id': ObjectId(_id)})
    print(result)
    return {
        'code': 200,
        'question': json._json_convert(result)
    }


def view_counter(q_id: str, u_id: str):
    # 问题浏览次数
    question = questions.find_one({'_id': ObjectId(q_id)})
    user = users.find_one({'_id': ObjectId(u_id)})

    history_list: list = user['question_history']

    if 'views' not in question.keys():
        # 问题浏览记录 字段初始化
        question['views'] = 0
    elif q_id not in history_list and q_id not in history_list:
        views = question['views'] + 1
        question['views'] = views

    # 用户浏览记录 字段初始化
    if 'question_history' not in user.keys():
        user['question_history'] = []

    # 问题历史记录 如果没有重复项 则插入在列表首位
    # 若已经浏览过改问题 则将其在列表中的位置移动至历史记录首位
    if q_id in history_list:
        history_list.remove(q_id)

    history_list.insert(0, q_id)

    questions.update({'_id': question['_id']}, question)
    users.update({'_id': user['_id']}, user)

    return {
        'code': 200,
    }
