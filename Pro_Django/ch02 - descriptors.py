import datetime

class CurrentDate(object):
    def __get__(self, instance, cls):
        print(self)
        print(instance)
        print(cls)
        return datetime.date.today()

    def __set__(self, instance, value):
        print(self)
        print(instance)
        raise NotImplementedError("Can't change the current date.")

class Example():
    date = CurrentDate()

print(Example.date) # called as class method (instance argument = None)

e = Example()
print(e.date) # called as instance method
try:
    e.date = datetime.date.today() # this will raise an exception
except NotImplementedError as E:
    print('Raised NotImplementedError ->', E)
  
