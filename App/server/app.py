from flask import Flask
from flask import Request, request, Response
from flask_cors import CORS
import bson.json_util as json
from flask_uploads import UploadSet, IMAGES, configure_uploads


import db

app = Flask(__name__)
CORS(app)


@app.route('/')
def index():
    return 'hello'


@app.route('/register', methods=['POST'])
def register():
    data = Request.get_json(request)
    result = db.register(username=data['username'],
                         email=data['email'],
                         password=data['password'])
    return json.dumps(result)


@app.route('/login', methods=['POST'])
def login():
    data = Request.get_json(request)
    result = db.login(data['email'], data['password'])
    print(result)
    return json.dumps(result)


@app.route('/user-info', methods=['POST'])
def getUserByEmail():
    email = Request.get_json(request)['email']
    result = db.get_user_by_email(email=email)
    print(result)
    return json.dumps(result)


avatars = UploadSet('avatars', IMAGES)
app.config['UPLOADED_AVATARS_DEST'] = './uploads/avatars'
configure_uploads(app, avatars)


@app.route('/upload/avatar', methods=['POST'])
def upload():
    # print(request.files)
    if 'avatar' in request.files:
        filename = avatars.save(request.files['avatar'])
        return json.dumps({'code': 200, 'url': avatars.url(filename)})
    return json.dumps({'code': 204, 'message': 'File not uploaded.'})


@app.route('/questions/ask', methods=['POST'])
def askQuestion():
    print(Request.get_json(request))
    content = Request.get_json(request)['content']
    title = Request.get_json(request)['title']
    email = Request.get_json(request)['email']
    result = db.ask_question(content=content, title=title, email=email)
    return json.dumps(result)


@app.route('/questions/list', methods=['POST'])
def getQuestionList():
    return json.dumps(db.get_questions())


@app.route('/questions/info', methods=['POST'])
def getQuestionInfo():
    _id = Request.get_json(request)['_id']
    print(_id)
    return json.dumps(db.get_question(_id))


@app.route('/questions/view', methods=['POST'])
def viewCounter():
    q_id = Request.get_json(request)['q_id']
    u_id = Request.get_json(request)['u_id']
    result = db.view_counter(q_id=q_id, u_id=u_id)
    return json.dumps(result)


if __name__ == '__main__':
    app.debug = True
    app.env = 'development'
    app.run()
