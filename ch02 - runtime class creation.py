'''
  runtime class creation
'''

# normal
class SpamNormal:
    def __init__(self, x):
        self.x = x

    def show(self):
        print(self.x)

# runtime
def init(self, x):
    self.x = x

def show(self):
    print(self.x)

# type(name, base, attrs)
# name is the name of the class
# base is a tuple of base classes (all methods/attributes are inherited from these)
# attrs is a dictionary filled with the class attributes
# ***** empty base defaults to (object,) *****
Spam = type("Spam", (object,), {'__init__': init, 'show': show})

# at this point Spam is now a class with 2 methods (__init__, show)
