def simple_decorator(func):
    print('Begin - This is called on decoration')

    def wrapped(*args, **kwargs):
        print('This is called when the decorated function runs')
        return func(*args, **kwargs)
            
    print('End - This is called on decoration')
    return wrapped

# new way to decorate is with @
@simple_decorator # <- the name of the decorator function
def new_way(a,b):
    return a+b

print(new_way(1,2))

# old way with equality!!
def old_way(a,b):
    return a+b

old_way = simple_decorator(old_way)
print(old_way(3,4))
              
    
