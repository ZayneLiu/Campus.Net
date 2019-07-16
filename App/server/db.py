from pymongo import MongoClient, database
from pymongo.collection import Collection
import bson.json_util as json
from bson import ObjectId
import datetime
from werkzeug.datastructures import FileStorage

client = MongoClient('mongodb://192.168.99.100:32770')

# DB
campus_net = client.get_database('campus_net')

# region Collections
users: Collection = campus_net.get_collection('users')
questions: Collection = campus_net.get_collection('questions')


# endregion


# Getters
def _get_user_by_email(email: str):
    user = users.find_one({'email': email})
    return user


def _get_user_by_id(u_id: str):
    user = users.find_one({'_id': ObjectId(u_id)})
    return user


def _get_question_by_id(q_id: str):
    question = questions.find_one({'_id': ObjectId(q_id)})
    return question


def _update_question_by_id(q_id: str, new_q):
    return questions.update_one({'_id': ObjectId(q_id)}, {'$set': {**new_q}}).acknowledged


def _update_user_by_id(u_id: str, new_u):
    return users.update_one({'_id': ObjectId(u_id)}, {'$set': {**new_u}}).acknowledged


def _update_user_by_email(email: str, new_u):
    return users.update_one({'email': email}, {'$set': {**new_u}}).acknowledged


# Actions

# region Auth

def login(email: str, password: str):
    user = _get_user_by_email(email)
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
        # print(result)
        return users.find_one(email)
    else:
        return {'code': 409, 'message': 'Account already exists.'}


# endregion


def get_user_by_email(email: str):
    user = _get_user_by_email(email=email)
    return {
        'code': 200,
        'user': json._json_convert(user),
    } if user is not None else {
        'code': 404,
        'message': 'Account does not exist!',
    }


def ask_question(title: str, content: str, email: str, tags: list):
    result = questions.insert_one(
        {
            'title': title,
            'content': content,
            'email': email,
            'tags': tags,
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
        # print(question)
    return {
        'code': 200,
        'questionList': json._json_convert(question_list)
    }
    # print()


def get_question(_id: str):
    result = _get_question_by_id(_id)
    # print(result)
    return {
        'code': 200,
        'question': json._json_convert(result)
    }


def view_counter(q_id: str, u_id: str):
    # 问题浏览次数
    question = _get_question_by_id(q_id)
    user = _get_user_by_id(u_id)

    history_list: list = user['question_history']

    if 'views' not in question.keys():
        # 问题浏览记录 字段初始化
        question['views'] = 1
    elif q_id not in history_list:
        views = question['views'] + 1
        question['views'] = views

    _update_question_by_id(question['_id'], question)
    # questions.update_one({'_id': question['_id']}, question)

    # 用户浏览记录 字段初始化
    if 'question_history' not in user.keys():
        user['question_history'] = [].append(q_id)
    elif q_id in history_list:
        # 已经浏览过改问题 则将其在列表中的位置移动至历史记录首位
        history_list.remove(q_id)
        history_list.insert(0, q_id)
    else:
        # 尚未浏览过此问题 则插入在列表首位
        history_list.insert(0, q_id)

    _update_user_by_id(user['_id'], user)
    # users.update_one({'_id': user['_id']}, user)

    return {
        'code': 200,
    }


def set_avatar(email: str, avatar: str):
    user = _get_user_by_email(email)
    user['avatar'] = avatar
    return _update_user_by_email(email=email, new_u=user)
    # users.update_one({'email': email}, result_user)


def follow_question(q_id: str, u_id: str):
    # 用户信息中的关注的问题列表
    user = _get_user_by_id(u_id)
    if 'following_questions' not in user.keys():
        user['following_questions'] = [q_id]
        # user['following_questions'].append(q_id)
    else:
        following_list = user['following_questions']
        user['following_questions'] = following_list + [q_id]

    _update_user_by_id(u_id=u_id, new_u=user)

    # 问题详情中已关注该问题的用户数
    question = _get_question_by_id(q_id)
    if 'followed' not in question.keys():
        question['followed'] = [u_id]
    else:
        temp = question['followed']
        question['followed'] = temp + [u_id]

    _update_question_by_id(q_id=q_id, new_q=question)

    return {
        'code': 200,
    }


def get_question_history(email: str):
    user = _get_user_by_email(email=email)
    history_list: list = user['question_history']
    result_question_list: list = []
    for question_id in history_list:
        result_question_list.append(_get_question_by_id(question_id))

    return json._json_convert(result_question_list)
