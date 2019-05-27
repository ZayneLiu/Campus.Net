from sqlalchemy import *
from sqlalchemy.orm import (
    scoped_session, sessionmaker, relationship, backref)
from sqlalchemy.ext.declarative import declarative_base

engine = create_engine('sqlite:///db.sqlite3')

db_session = scoped_session(sessionmaker(
    autocommit=False, autoflush=False, bind=engine))

Base = declarative_base()

Base.query = db_session.query_property()


class User(Base):
    __tablename__ = 'user'
    id = Column(Integer, primary_key=True)
    No = Column(String)
    name = Column(String)
    email = Column(String)
