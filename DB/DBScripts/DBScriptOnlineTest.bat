set /p server= Enter SQL Server Name:
set db_name="OnlineTestDB"
set /p dbUser_name= Enter DB User Name:
set /p dbPassword= Enter Password:


cd "Table"
del "ResultLog.log"
CALL BTable.bat




