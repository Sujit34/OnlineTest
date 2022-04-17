IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('IncomeCosts'))
BEGIN
	CREATE TABLE  IncomeCosts(
		Id [UNIQUEIDENTIFIER] DEFAULT NEWID()  NOT NULL,	
		[Year] VARCHAR(5) NOT NULL,
		[Month] VARCHAR(5) NOT NULL,
		Income INT  NOT NULL DEFAULT(0),	
		CumulativeIncome INT NOT NULL DEFAULT(0) ,
		Cost INT NOT NULL DEFAULT(0),
		CumulativeCost INT NOT NULL DEFAULT(0),
		CONSTRAINT chk_Month CHECK ([Month] IN ('Jan', 'Feb', 'Mar', 'Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec')),
		CONSTRAINT PK_IncomeCosts PRIMARY KEY CLUSTERED ( Id )			
	);
	INSERT INTO IncomeCosts([Year],[Month],Income,CumulativeIncome,Cost,CumulativeCost)
		VALUES 	
		('2019','Jan','100','100','200','200'),
		('2019','Feb','50','150','70','270'),
		('2019','Mar','150','300','120','390'),
		('2019','Apr','0','300','200','590'),
		('2019','May','800','1100','300','890'),
		('2019','Jun','50','1150','50','940'),
		('2019','Jul','100','1250','50','990'),
		('2019','Aug','0','1250','0','990'),
		('2019','Sep','0','1250','0','990'),
		('2019','Oct','0','1250','0','990'),
		('2019','Nov','0','1250','0','990'),
		('2019','Dec','0','1250','0','990'),
		('2022','Jan','200','1250','100','990'),
		('2022','Feb','200','1250','100','990'),
		('2022','Mar','200','1250','100','990'),
		('2022','Apr','200','1250','100','990'),
		('2022','May','200','1250','100','990'),
		('2022','Jun','200','1250','100','990'),
		('2022','Jul','200','1250','100','990'),
		('2022','Aug','200','1250','100','990'),
		('2022','Sep','200','1250','100','990'),
		('2022','Oct','200','1250','100','990'),
		('2022','Nov','200','1250','100','990'),
		('2022','Dec','200','1250','100','990')
		
END 
GO