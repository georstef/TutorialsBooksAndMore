call C:\Python34\envdjango16\scripts\activate.bat
manage.py sql tictactoe
manage.py sqlcustom tictactoe 
manage.py sqlindexes tictactoe

@rem check for errors
manage.py validate 

@rem drop table statements
manage.py sqlclear tictactoe 

@rem combination of sql, sqlcustom, sqlindexes
@rem manage.py sqlall tictactoe 
pause