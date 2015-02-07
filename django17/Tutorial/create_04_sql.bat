call C:\Python34\envdjango17\scripts\activate.bat
manage.py sql polls
manage.py sqlcustom polls 
manage.py sqlindexes polls

@rem check for errors
manage.py validate 

@rem drop table statements
manage.py sqlclear polls 

@rem combination of sql, sqlcustom, sqlindexes
@rem manage.py sqlall polls 
pause