import graphene
from graphene import relay
from graphene_sqlalchemy import SQLAlchemyObjectType, SQLAlchemyConnectionField
from server.models import db_session, User as UserModel


class User(SQLAlchemyObjectType):
    class Meta:
        model = UserModel
        interfaces = (relay.Node,)


class UserConnection(relay.Connection):
    class Meta:
        node = User


# class SearchResult(graphene.Union):
#     class Meta:
#         types = (User)


class Query(graphene.ObjectType):
    node = relay.Node.Field()
    search = graphene.List(User, q=graphene.Int())
    # Allows sorting over multiple columns, by default over the primary key
    all_users = SQLAlchemyConnectionField(UserConnection)
    # # Disable sorting over this field
    # all_employees = SQLAlchemyConnectionField(UserConnection, sort=None)

    def resolve_search(self, info, **args):
        q = args.get('q')

        user_query = User.get_query(info=info)
        print('++{0}++{1}'.format(q, graphene.ID(q).parse_literal()))
        users = user_query.filter(
            UserModel.id.contains(q))

        return users


schema = graphene.Schema(query=Query, types=[User])
