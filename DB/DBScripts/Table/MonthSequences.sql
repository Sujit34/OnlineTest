IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('MonthSequences'))
BEGIN
	CREATE TABLE  MonthSequences(
		Id [UNIQUEIDENTIFIER] DEFAULT NEWID()  NOT NULL,		
		[Month] VARCHAR(5) NOT NULL,
		[Sequence] INT NOT NULL,
		CONSTRAINT chk_MonthSequence CHECK ([Month] IN ('Jan', 'Feb', 'Mar', 'Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec')),
		CONSTRAINT PK_MonthSequences PRIMARY KEY CLUSTERED ( Id )			
	);
	INSERT INTO MonthSequences([Month],[Sequence])
		VALUES 	
		('Jan','1'),
		('Feb','2'),
		('Mar','3'),
		('Apr','4'),
		('May','5'),
		('Jun','6'),
		('Jul','7'),
		('Aug','8'),
		('Sep','9'),
		('Oct','10'),
		('Nov','11'),
		('Dec','12')
END 
GO