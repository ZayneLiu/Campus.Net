from flask import Blueprint

bp_api = Blueprint(name='api', url_prefix='/api', import_name='api')


@bp_api.route('/')
def api_index():
    return 'this is api server', 200
