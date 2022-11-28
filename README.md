# APIs-Final-project

3 APIs endpoints:
- Get/{id} 
- Post 
- Delete 

3 Models:
- Funkopop.cs
- Funkovalues.cs
- FunkoDBContext.cs

Controller:
- Funkopopscontroller.cs

Get/ {id} will throw "not found" when get the id doesn't exist.
Delete will respond "Deleted" when hit delete id or throw "not found" if the id doesn't exist.

Database.

Tables:
- Funkopop
- Funkovalues
 
Primary keys:
- FunkoID 
- Estvalue

Foreign Key:
- Estvalue

Constraint:
- FK_FunkoId

The FunkoId is auto increment so don't need to type id in Post method
