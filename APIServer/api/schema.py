import graphene
from graphene import relay
from graphene_sqlalchemy import SQLAlchemyObjectType, SQLAlchemyConnectionField

from models import db_session, User as UserModel


class User(SQLAlchemyObjectType):
    class Meta:
        model = UserModel
        interfaces = (relay.Node, )


class UserConnection(relay.Connection):
    class Meta:
        node = User


class Query(graphene.ObjectType):
    node = relay.Node.Field()
    # Allows sorting over multiple columns, by default over the primary key
    all_user = SQLAlchemyConnectionField(UserConnection)
    # all_employees = SQLAlchemyConnectionField(EmployeeConnection)
    # # Disable sorting over this field
    # all_departments = SQLAlchemyConnectionField(
    #     DepartmentConnection, sort=None)


schema = graphene.Schema(query=Query)
