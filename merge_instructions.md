How to merge Repositories without losing history
=================================================

//1. into the Project folder
```
    git remote add -f subProject \path\to\subProject
    git merge -s ours --no-commit subProject/master
    git read-tree --prefix=subProject/ -u subProject/master
    git commit -m "Merge subProject"
````

//2. open Github app and Sync

//3. open Git Extensions and delete "Remote Repository"

//4. open Github and delete repository "subProject" (settings)

//5. in Github app delete "subProject"

//6. open windows explorer and delete folder "subProject"
