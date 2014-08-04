def advanced_decorator(extra_param=0):
    print('This is called when the decorator is preparing')
    def simple_decorator(func):
        print('Begin - This is called on decoration')

        def wrapped(*args, **kwargs):
            print('This is called when the decorated function runs')
            return extra_param + func(*args, **kwargs)
            
        print('End - This is called on decoration')
        return wrapped
    return simple_decorator
    

# new way to decorate is with @
@advanced_decorator(10) # <- the name of the decorator function with param
def new_way(a,b):
    return a+b

print(new_way(1,2)) # should return 13 (10+1+2)

# --------------------------------------------------------
# old way with equality!!
def simple_decorator_with_param(func, extra_param=0):
    print('Begin - This is called on decoration')

    def wrapped(*args, **kwargs):
        print('This is called when the decorated function runs')
        return extra_param + func(*args, **kwargs)
            
    print('End - This is called on decoration')
    return wrapped


def old_way(a,b):
    return a+b

old_way = simple_decorator_with_param(old_way, 10)
print(old_way(3,4)) # should return 17 (10+3+4)
              
    
