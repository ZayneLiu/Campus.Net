from flask import Flask, blueprints
import json

app = Flask(__name__)

from server.api import bp_api
app.register_blueprint(blueprint=bp_api)


@app.route('/')
def index():
    return json.dumps({'message': 'this is the index page'})


from flask_graphql import GraphQLView
from server.schema import schema

app.add_url_rule(
    '/graphql',
    view_func=GraphQLView.as_view(
        'graphql',
        schema=schema,
        graphiql=True  # for having the GraphiQL interface
    )
)

from server.models import db_session
@app.teardown_appcontext
def shutdown_session(exception=None):
    db_session.remove()
