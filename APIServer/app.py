from server import app
import click


@app.cli.command()
def initdb():
    from server.models import Base, engine
    Base.metadata.create_all(bind=engine)
    click.echo('DB Initialized.')
    pass


if __name__ == '__main__':
    app.debug = True
    app.run()
