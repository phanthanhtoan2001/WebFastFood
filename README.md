# WebFastFood
Project FastFood
create database FastFood
go
use FastFood
go
create table SanPham(
MaSP char(6) primary key,
Tensp nvarchar(25),
Dongia int,
Size nvarchar(200),
Hinhanh nvarchar(30),
Soluongton int,
MaNSX char(6),
MaNCC char(6),
MaLoaiSP char(6)
)
go

create table PhieuNhap(
Maphieu char(6) primary key,
Ngaynhap date
)
go

create table NCC(
MaNCC char(6) primary key,
TenNCC nvarchar(25),
Diachi nvarchar(50),
Email varchar(30),
SDT char(12)
)
go

create table NSX(
MaNSX char(6) primary key,
TenNSX nvarchar(25),
Logo nvarchar(30))
go

create table LoaiSP(
MaLoaiSP char(6) primary key,
TenLoai nvarchar(25),
Icon nvarchar(30)
)
go
create table DonDatHang(
MaDDH char(6) primary key,
Ngaydat date,
Tinhtrangdonhang bit,
Ngaygiao date,
MaTK char(6),
)
go

create table TaiKhoan(
MaTK char(6) primary key,
TenTK nvarchar(30),
MatKhau char(10),
Hinh nvarchar(30),
SDT char(12),
Email varchar(30),
DiaChi nvarchar(50),
MaLTK int,
)
go
create table LoaiTK(
MaLTK int primary key ,
TenLTK char(8)

)

create table CTDDH(

 MaDDH char(6),
MaSP char(6),
soluong int,
Dongia int,
TinhTrang bit,
YeuCauKH nvarchar(100),
PRIMARY KEY (MaDDH, MaSP))

go

create table CTPN(
MaSP char(6),
Maphieu char(6),
Giamua int,
Soluong int,
PRIMARY KEY (MaSP,Maphieu)
)
go



ALTER TABLE SanPham  WITH CHECK ADD FOREIGN KEY([MaNSX])
REFERENCES NSX ([MaNSX])
GO

ALTER TABLE SanPham  WITH CHECK ADD FOREIGN KEY([MaNCC])
REFERENCES NCC ([MaNCC])
GO

ALTER TABLE SanPham  WITH CHECK ADD FOREIGN KEY([MaLoaiSP])
REFERENCES LoaiSP ([MaLoaiSP])
GO



ALTER TABLE DonDatHang  WITH CHECK ADD FOREIGN KEY([MaTK])
REFERENCES TaiKhoan([MaTK])
GO



ALTER TABLE [dbo].CTDDH  WITH CHECK ADD FOREIGN KEY([MaDDH])
REFERENCES [dbo].DonDatHang ([MaDDH])
GO

ALTER TABLE [dbo].CTDDH  WITH CHECK ADD FOREIGN KEY([MaSP])
REFERENCES [dbo].SanPham ([MaSP])
GO

ALTER TABLE [dbo].CTPN  WITH CHECK ADD FOREIGN KEY([MaSP])
REFERENCES [dbo].SanPham ([MaSP])
GO

ALTER TABLE [dbo].CTPN  WITH CHECK ADD FOREIGN KEY([MaPhieu])
REFERENCES [dbo].PhieuNhap ([MaPhieu])
GO
AlTer TABLE  [dbo].TaiKhoan WITH CHECK ADD FOREIGN KEY([MaLTK])
REFERENCES [dbo].LoaiTK ([MaLTK])
GO

