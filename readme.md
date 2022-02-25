## Todos on Board API: 
We want to create RESTful APIs for a simple Todo management application. The APIs will perform CRUD operation for Todos and Boards. Todos are organized in boards, on every board there can be multiple Todos. A Todo contains a title (str), done (bool), a created (datetime) and updated (datetime) timestamp. A board has a name (str).

Via a REST API it must be possible to:
- List all boards
- Add a new board 
- Change a board's title 
- Remove a board 
- List all Todos on a board 
- List only uncompleted Todos 
- Add a Todo to a board 
- Change a Todo's title or status 
- Delete a Todo 

Additional features(you can import postman api for better understanding and endpoints)
- All the passwords are encrypted and stored in the db
- You can assign a board to a user and many user can use many boards
- You can get which user is assigned to which boards

For testing and api understanding all endpoints and params and urls you can refer to file of postman collection for the api "TodoAndBoard.postman_collection".

## To run this api

- First please change the connectionString according to your database in appsettings.json.
- Then .net 5.0 have to be in your system.
- For migration of data please run "dotnet ef database update migrateDB".
- Now you can run the api by "dotnet run".
- And for testing you can import "TodoAndBoard.postman_collection" in postman.