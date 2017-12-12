# Herlock Sholmes
A point and click adventure/mystery game made in Unity for VGDC at UCI

## Git Workflow Cheatsheet
### Working on develop branch
1. `git branch develop`
2. Make changes
3. `git add .`
4. `git commit -m "This is my message..."`
5. `git push -u origin develop`


### Updating the master branch
1. on develop branch
2. `git merge master`
3. resolve any conflicts that may occur
4. `git checkout master`
5. `git merge develop`
6. `git push -u origin master`