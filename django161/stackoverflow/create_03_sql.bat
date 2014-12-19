call C:\Python34\envdjango16\scripts\activate.bat
manage.py sql aggregates
manage.py sqlcustom aggregates
manage.py sqlindexes aggregates

@rem check for errors
manage.py validate 

@rem drop table statements
manage.py sqlclear aggregates

@rem combination of sql, sqlcustom, sqlindexes
@rem manage.py sqlall aggregates
pause