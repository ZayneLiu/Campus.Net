from flask import Flask
from flask_admin import Admin

from flask_graphql import GraphQLView

from models import db_session, Base, engine, User
from schema import schema

import click

app = Flask(__name__)
app.debug = True
app.secret_key = 'zayne'

app.add_url_rule(
    '/graphql',
    view_func=GraphQLView.as_view(
        'graphql',
        schema=schema,
        graphiql=True  # for having the GraphiQL interface
    )
)


from flask_admin.contrib.sqla import ModelView

# Flask and Flask-SQLAlchemy initialization here

admin = Admin(app, name='API', template_mode='bootstrap3')
admin.add_view(ModelView(User, db_session))
# admin.add_view(ModelView(Post, db.session))

# admin = Admin(app, name='microblog', template_mode='bootstrap3')


@app.teardown_appcontext
def shutdown_session(exception=None):
    db_session.remove()


@app.cli.command()
def initDB():
    click.echo('initdbaaa')
    pass


# @app.cli.command()
if __name__ == "__main__":
    # click.echo('initdb')
    Base.metadata.drop_all(bind=engine)
    Base.metadata.create_all(bind=engine)
    app.env = True
    app.debug = True
    app.run()
