'''
  inspect.getargspec() -> a function that returns information about what
                          arguments a function accepts. It accepts the function
                          object to be inspected, and returns a tuple
                          of the following:

    • args—A list of all argument names specified for the function.
      If the function doesn’t accept any arguments, this will be an empty list.
    • varargs—The name of the variable used for positional arguments,
      If the function doesn’t accept positional arguments, this will be None.
    • varkwargs—The name of the variable used for keyword arguments,
      If the function doesn’t accept keyword arguments, this will be None.
    • defaults—A tuple of all default values specified
      If none of the arguments specify a default value, this will be None
'''
def test(a, b, c=True, d=False, *e, **f):
    pass

import inspect
print(inspect.getargspec(test))

# simple way to find which arguments have defaults
# the trick is that required arguments (a,b) must be declared
# before the optional arguments (c,d)
def get_defaults(func):
    args, varargs, varkwargs, defaults = inspect.getargspec(func)
    index = len(args) - len(defaults) # Index of the first optional argument
    return dict(zip(args[index:], defaults))

print(get_defaults(test))

