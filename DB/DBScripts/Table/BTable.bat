ECHO add column and update date

sqlcmd -S %server% -d %db_name% -U %dbUser_name% -P %dbPassword% -i "IncomeCosts.sql" >> "ResultLog.log"
sqlcmd -S %server% -d %db_name% -U %dbUser_name% -P %dbPassword% -i "IncomeExpenses.sql" >> "ResultLog.log"
sqlcmd -S %server% -d %db_name% -U %dbUser_name% -P %dbPassword% -i "MonthSequences.sql" >> "ResultLog.log"







