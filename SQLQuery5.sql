

Create table Colors(
ColorId int primary key identity(1,1),
ColorName nvarchar(25),
)
Create table Brands(
BrandId int primary key identity(1,1),
BrandName nvarchar(25),

)

Insert Into [dbo].[Cars](CarId,BrandId,ColorId,DailyPrice,ModelYear,Description)
Values
	('1','1','1','150','2017','Opel Astra Otomatik');
    


Insert Into [dbo].[Colors](ColorName)
Values
	('Beyaz'),('Siyah'),('Gri');

Insert Into [dbo].Brands(BrandName)
Values
	('Opel'),('Mercedes'),('Peugeot'),('Toyota');

Select * from Cars
Select * from Brands
Select * from Colors