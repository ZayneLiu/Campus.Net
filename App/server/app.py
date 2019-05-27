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
    data = request.json
    result = db.register(username=data['username'],
                         email=data['email'],
                         password=data['password'])
    return json.dumps(result)


@app.route('/login', methods=['POST'])
def login():
    data = request.json
    result = db.login(data['email'], data['password'])
    print(result)
    return json.dumps(result)


@app.route('/user-info', methods=['POST'])
def get_user_by_email():
    email = request.json['email']
    result = db.get_user_by_email(email=email)
    print(result)
    return json.dumps(result)


avatars = UploadSet('avatars', IMAGES)
app.config['UPLOADED_AVATARS_DEST'] = './uploads/avatars'
configure_uploads(app, avatars)


@app.route('/upload/avatar', methods=['POST'])
def upload():
    if 'avatar' in request.files:
        filename = avatars.save(request.files['avatar'])
        return json.dumps({'code': 200, 'url': avatars.url(filename)})
    return json.dumps({'code': 204, 'message': 'File not uploaded.'})


@app.route('/questions/ask', methods=['POST'])
def ask_question():
    content = request.json['content']
    title = request.json['title']
    email = request.json['email']
    tags = request.json['tags']
    result = db.ask_question(content=content, title=title, email=email, tags=tags)
    return json.dumps(result)


@app.route('/questions/list', methods=['POST'])
def get_question_list():
    return json.dumps(db.get_questions())


@app.route('/questions/info', methods=['POST'])
def get_question_info():
    _id = Request.get_json(request)['_id']
    return json.dumps(db.get_question(_id))


@app.route('/questions/view', methods=['POST'])
def view_counter():
    q_id = Request.get_json(request)['q_id']
    u_id = Request.get_json(request)['u_id']
    result = db.view_counter(q_id=q_id, u_id=u_id)
    return json.dumps(result)


@app.route('/questions/follow', methods=['POST'])
def view_counter():
    q_id = Request.get_json(request)['q_id']
    u_id = Request.get_json(request)['u_id']
    result = db.follow_question(q_id=q_id, u_id=u_id)
    return json.dumps(result)


if __name__ == '__main__':
    app.debug = True
    app.env = 'development'
    app.run()
