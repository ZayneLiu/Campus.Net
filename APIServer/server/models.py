from sqlalchemy import *
from sqlalchemy.orm import scoped_session, sessionmaker, relationship, backref
from sqlalchemy.ext.declarative import declarative_base


engine = create_engine('sqlite:///db.sqlite3', convert_unicode=True)

db_session = scoped_session(sessionmaker(
    autocommit=False, autoflush=False, bind=engine))

Base = declarative_base()
Base.query = db_session.query_property()


class User(Base):
    __tablename__ = 'User'
    id = Column(Integer, primary_key=True)
    email = Column(String)
    password = Column(String)
    username = Column(String)
    gender = Column(String)  # 'male' or 'female'
    birthday = Column(Date)
    biography = Column(String)
    # scid = 0
    # tel = 'default'
    # realname = 'default'
