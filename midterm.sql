create database midterm
go

use midterm
go

create table qldat (
	ma varchar(5) primary key,
	mau nvarchar(100),
	mucdich nvarchar(100),
	luongnuoc float,
	doanhthu float,
	vitri geometry
)

insert into qldat(ma, mau, mucdich, luongnuoc, doanhthu, vitri) values('M7',N'Xám',N'Trồng lúa',75000,250.6,geometry::STGeomFromText('MULTIPOLYGON(((-2 -2,-2 2,-1 3,1 3,1 -1,-2 -2)),((5 3,7 3,7 -2,5 -2,3 0,6 1,5 3)))',0))
insert into qldat values('M8',N'Nâu',N'Trồng Cây ăn quả',45000,350.4,geometry::STGeomFromText('POLYGON((-2 -2,1 -1,1 0,3 0,3 -2,-2 -2))',0))
insert into qldat values('M9',N'Tím',N'Trồng rau',35000,450.5,geometry::STGeomFromText('POLYGON((1 0,1 3,3 4,5 3,5 1,3 0, 1 0))',0))

select * from qldat
--a
select ma,luongnuoc*vitri.STArea() as luongnuoctuoi
from qldat
--b
select * 
from qldat
where vitri.STArea() >= All(select vitri.STArea() from qldat)
--c
--declare @kenh geometry= geometry::STGeomFromText('POLYGON((-2 1,7 1,7 -1,-2 -1,-2 1))',0);
--select @kenh
select ma, vitri.STIntersection(@kenh).STArea()
from qldat 
--d
declare @kenh geometry= geometry::STGeomFromText('POLYGON((-2 1,7 1,7 -1,-2 -1,-2 1))',0);
update qldat set vitri=vitri.MakeValid().STDifference(@kenh)

select * from qldat
 