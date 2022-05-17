use DogShow
--1 
--Create table Club2
--(
-- IdClub int Primary key not null,
-- NameClub Nvarchar(50)  not null,
-- Breed Nvarchar(50)  not null,
-- MinNumber int  not null ,
-- MaxNumber int not null
--)

--2
Create table Expert2
(
 IdExpert int not null,
 Name Nvarchar(50)  not null,
 Surname Nvarchar(50)  not null,
 IdRing int  not null ,
 IdClub int not null

 Foreign key (IdRing) references Ring (IdRing)
)

