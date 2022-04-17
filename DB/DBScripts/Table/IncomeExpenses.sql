IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('IncomeExpenses'))
BEGIN
	CREATE TABLE  IncomeExpenses(
		Id [UNIQUEIDENTIFIER] DEFAULT NEWID()  NOT NULL,	
		[Year] VARCHAR(5) NOT NULL,
		[Month] VARCHAR(5) NOT NULL,
		IncomeType1 INT,
		IncomeType2 INT,
		IncomeType3 INT,
		ExpenseType1 INT,
		ExpenseType2 INT,
		ExpenseType3 INT,
		ExpenseType4 INT,
		CONSTRAINT chk_Months CHECK ([Month] IN ('Jan', 'Feb', 'Mar', 'Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec')),
		CONSTRAINT PK_IncomeExpenses PRIMARY KEY CLUSTERED ( Id )
			
	);
	INSERT INTO IncomeExpenses([Year],[Month],IncomeType1,IncomeType2,IncomeType3,ExpenseType1,ExpenseType2,ExpenseType3,ExpenseType4)
		VALUES 	
		('2019','Jan','1200','251','0',null,'200',null,null),
		('2019','Feb',null,null,null,null,null,null,null),
		('2019','Mar',null,'152',null,null,null,'250',null),
		('2019','Apr','52',null,'225','300',null,null,null),
		('2019','May',null,'522',null,null,null,null,null),
		('2019','Jun',null,null,null,null,'500',null,null),
		('2019','Jul',null,null,null,null,null,null,null),
		('2019','Aug',null,null,null,'100',null,null,null),
		('2019','Sep',null,null,null,null,null,null,null),
		('2019','Oct',null,null,null,null,null,null,null),
		('2019','Nov',null,null,null,null,null,null,null),
		('2019','Dec',null,null,null,null,null,null,null),
		('2022','Jan','1200','251','0',null,'200',null,null),
		('2022','Feb',null,null,null,null,null,null,null),
		('2022','Mar',null,'152',null,null,null,'250',null),
		('2022','Apr','52',null,'225','300',null,null,null),
		('2022','May',null,'522',null,null,null,null,null),
		('2022','Jun',null,null,null,null,'500',null,null),
		('2022','Jul',null,null,null,null,null,null,null),
		('2022','Aug',null,null,null,'100',null,null,null),
		('2022','Sep',null,null,null,null,null,null,null),
		('2022','Oct',null,null,null,null,null,null,null),
		('2022','Nov',null,null,null,null,null,null,null),
		('2022','Dec',null,null,null,null,null,null,null)
		
END 
GO