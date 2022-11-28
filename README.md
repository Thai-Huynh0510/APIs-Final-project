# APIs-Final-project

3 HTTP methods:
- Get/{id} :retrieve information from specific ID
- Post : add new item
- Delete : delete an item

Get/ {id} will throw "not found" when get the id doesn't exist.

Delete will respond "Deleted" when hit delete id or throw "not found" if the id doesn't exist.

After deleted a specific Id, hit get that Id will throw "Not found".

3 Models:
- Funkopop.cs
- Funkovalues.cs
- FunkoDBContext.cs

Controller:
- Funkopopscontroller.cs


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
