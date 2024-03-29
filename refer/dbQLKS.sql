--Tạo Database

-- Table: public."KhachHang"

-- DROP TABLE public."KhachHang";

CREATE TABLE public."KhachHang"
(
    "MaKhachHang" character(5) COLLATE pg_catalog."default" NOT NULL,
    "HoTen" character(50) COLLATE pg_catalog."default" NOT NULL,
    "CMND" character(12) COLLATE pg_catalog."default" NOT NULL,
    "NgaySinh" date,
    "GioiTinh" character(3) COLLATE pg_catalog."default",
    "DiaChi" character(100) COLLATE pg_catalog."default",
    "SoDienThoai" character(12) COLLATE pg_catalog."default" NOT NULL,
    "MaLoaiKhachHang" character(5) COLLATE pg_catalog."default",
    CONSTRAINT "KhachHang_pkey" PRIMARY KEY ("MaKhachHang"),
    CONSTRAINT "FK_KhachHang_LoaiKhachHang" FOREIGN KEY ("MaLoaiKhachHang")
        REFERENCES public."LoaiKhachHang" ("MaLoaiKhachHang") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."KhachHang"
    OWNER to postgres;
-----------------------------------------------------------------------------

--Tạo bảng Nhân Viên

-- Table: public."NhanVien"

-- DROP TABLE public."NhanVien";

CREATE TABLE public."NhanVien"
(
    "MaNhanVien" character(5) COLLATE pg_catalog."default" NOT NULL,
    "HoTen" character(50) COLLATE pg_catalog."default" NOT NULL,
    "CMND" character(12) COLLATE pg_catalog."default" NOT NULL,
    "NgaySinh" date,
    "GioiTinh" character(3) COLLATE pg_catalog."default",
    "DiaChi" character(100) COLLATE pg_catalog."default",
    "ChucVu" character(20) COLLATE pg_catalog."default",
    CONSTRAINT "NhanVien_pkey" PRIMARY KEY ("MaNhanVien")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."NhanVien"
    OWNER to postgres;
	
	
-----------------------------------------------------------------------

--Tạo bảng LOẠI KHÁCH HÀNG

-- Table: public."LoaiKhachHang"

-- DROP TABLE public."LoaiKhachHang";

CREATE TABLE public."LoaiKhachHang"
(
    "MaLoaiKhachHang" character(5) COLLATE pg_catalog."default" NOT NULL,
    "TenLoai" character(20) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "LoaiKhachHang_pkey" PRIMARY KEY ("MaLoaiKhachHang")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."LoaiKhachHang"
    OWNER to postgres;
--------------------------------------------------------------------------

--Tạo bảng khách hàng

-- Table: public."KhachHang"

-- DROP TABLE public."KhachHang";

CREATE TABLE public."KhachHang"
(
    "MaKhachHang" character(5) COLLATE pg_catalog."default" NOT NULL,
    "HoTen" character(50) COLLATE pg_catalog."default" NOT NULL,
    "CMND" character(12) COLLATE pg_catalog."default" NOT NULL,
    "NgaySinh" date,
    "GioiTinh" character(3) COLLATE pg_catalog."default",
    "DiaChi" character(100) COLLATE pg_catalog."default",
    "SoDienThoai" character(12) COLLATE pg_catalog."default" NOT NULL,
    "MaLoaiKhachHang" character(5) COLLATE pg_catalog."default",
    CONSTRAINT "KhachHang_pkey" PRIMARY KEY ("MaKhachHang"),
    CONSTRAINT "FK_KhachHang_LoaiKhachHang" FOREIGN KEY ("MaLoaiKhachHang")
        REFERENCES public."LoaiKhachHang" ("MaLoaiKhachHang") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."KhachHang"
    OWNER to postgres;


------------------------------------------------------------------------

--TẠO BẢNG LOẠI PHÒNG

-- Table: public."LoaiPhong"

-- DROP TABLE public."LoaiPhong";

CREATE TABLE public."LoaiPhong"
(
    "MaLoaiPhong" character(5) COLLATE pg_catalog."default" NOT NULL,
    "TenLoaiPhong" character(50) COLLATE pg_catalog."default" NOT NULL,
    "DonGia" money NOT NULL,
    CONSTRAINT "LoaiPhong_pkey" PRIMARY KEY ("MaLoaiPhong")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."LoaiPhong"
    OWNER to postgres;
--------------------------------------------------------------------

--TẠO BẢNG PHÒNG
-- Table: public."Phong"

-- DROP TABLE public."Phong";

CREATE TABLE public."Phong"
(
    "MaPhong" character(5) COLLATE pg_catalog."default" NOT NULL,
    "TenPhong" character(20) COLLATE pg_catalog."default" NOT NULL,
    "MaLoaiPhong" character(5) COLLATE pg_catalog."default",
    CONSTRAINT "Phong_pkey" PRIMARY KEY ("MaPhong"),
    CONSTRAINT "FK_Phong_LoaiPhong" FOREIGN KEY ("MaLoaiPhong")
        REFERENCES public."LoaiPhong" ("MaLoaiPhong") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."Phong"
    OWNER to postgres;
-------------------------------------------------------------------

--TẠO BẢNG TÌNH TRẠNG PHÒNG
-- Table: public."TinhTrang"

-- DROP TABLE public."TinhTrang";

CREATE TABLE public."TinhTrang"
(
    "MaTinhTrang" character(5) COLLATE pg_catalog."default" NOT NULL,
    "LoaiTinhTrang" character(20) COLLATE pg_catalog."default" NOT NULL,
    "NgayCuaTinhTrang" date NOT NULL,
    "MaPhong" character(5) COLLATE pg_catalog."default",
    CONSTRAINT "TinhTrang_pkey" PRIMARY KEY ("MaTinhTrang"),
    CONSTRAINT "FK_TinhTrang_Phong" FOREIGN KEY ("MaPhong")
        REFERENCES public."Phong" ("MaPhong") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."TinhTrang"
    OWNER to postgres;
---------------------------------------------------------------

--TẠO BẢNG PHIẾU THUÊ

-- Table: public."PhieuThue"

-- DROP TABLE public."PhieuThue";

CREATE TABLE public."PhieuThue"
(
    "MaPhieuThue" character(5) COLLATE pg_catalog."default" NOT NULL,
    "MaKhachHang" character(5) COLLATE pg_catalog."default",
    "MaNhanVien" character(5) COLLATE pg_catalog."default",
    "NgayLap" date NOT NULL,
    "SoLuongPhong" integer NOT NULL,
    CONSTRAINT "PhieuThue_pkey" PRIMARY KEY ("MaPhieuThue"),
    CONSTRAINT "FK_PhieuThue_KhachHang" FOREIGN KEY ("MaKhachHang")
        REFERENCES public."KhachHang" ("MaKhachHang") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_PhieuThue_NhanVien" FOREIGN KEY ("MaNhanVien")
        REFERENCES public."NhanVien" ("MaNhanVien") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."PhieuThue"
    OWNER to postgres;
----------------------------------------------------------------

--tẠO BẢNG CHI TIẾT PHIẾU THUÊ

-- Table: public."ChiTietPhieuThue"

-- DROP TABLE public."ChiTietPhieuThue";

CREATE TABLE public."ChiTietPhieuThue"
(
    "MaChiTietPhieuThue" character(5) COLLATE pg_catalog."default" NOT NULL,
    "MaPhieuThue" character(5) COLLATE pg_catalog."default",
    "MaPhong" character(5) COLLATE pg_catalog."default",
    "NgayNhanPhong" date,
    "NgayTraPhong" date,
    "ThanhTienPhong" money,
    "PhuThu" money,
    "GhiChu" character(100) COLLATE pg_catalog."default",
    CONSTRAINT "ChiTietPhieuThue_pkey" PRIMARY KEY ("MaChiTietPhieuThue"),
    CONSTRAINT "FK_ChiTietPhieuThue_PhieuThue" FOREIGN KEY ("MaPhieuThue")
        REFERENCES public."PhieuThue" ("MaPhieuThue") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_ChiTietPhieuThue_Phong" FOREIGN KEY ("MaPhong")
        REFERENCES public."Phong" ("MaPhong") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."ChiTietPhieuThue"
    OWNER to postgres;
------------------------------------------------------------------------

--tẠO BẢNG BÁO CÁO MẬT ĐỘ

-- Table: public."BaoCaoMatDo"

-- DROP TABLE public."BaoCaoMatDo";

CREATE TABLE public."BaoCaoMatDo"
(
    "MaBaoCaoMatDo" character(5) COLLATE pg_catalog."default" NOT NULL,
    "ThangBaoCaoMatDo" date,
    CONSTRAINT "BaoCaoMatDo_pkey" PRIMARY KEY ("MaBaoCaoMatDo")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."BaoCaoMatDo"
    OWNER to postgres;
-----------------------------------------------------------------------

--TẠO BẢNG CHI TIẾT BÁO CÁO MẬT ĐỘ

-- Table: public."ChiTietBaoCaoMatDo"

-- DROP TABLE public."ChiTietBaoCaoMatDo";

CREATE TABLE public."ChiTietBaoCaoMatDo"
(
    "MaChiTietBaoCaoMatDo" character(5) COLLATE pg_catalog."default" NOT NULL,
    "MaBaoCaoMatDo" character(5) COLLATE pg_catalog."default",
    "MaPhong" character(5) COLLATE pg_catalog."default",
    "SoNgayThueTrongThang" integer,
    "TiLeSuDung" character(10) COLLATE pg_catalog."default",
    CONSTRAINT "ChiTietBaoCaoMatDo_pkey" PRIMARY KEY ("MaChiTietBaoCaoMatDo"),
    CONSTRAINT "FK_ChiTietBaoCaoMatDo_BaoCaoMatDo" FOREIGN KEY ("MaBaoCaoMatDo")
        REFERENCES public."BaoCaoMatDo" ("MaBaoCaoMatDo") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_ChiTietBaoCaoMatDo_Phong" FOREIGN KEY ("MaPhong")
        REFERENCES public."Phong" ("MaPhong") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."ChiTietBaoCaoMatDo"
    OWNER to postgres;
------------------------------------------------------------------------

--THÊM DỮ LIỆU BẢNG NHÂN VIÊN

INSERT INTO public."NhanVien"(
	"MaNhanVien", "HoTen", "CMND", "NgaySinh", "GioiTinh", "DiaChi", "ChucVu")
	VALUES ('NV001', 'Trần Ngọc Hiền', '300153978198', '10/17/1988', 'Nữ', '253, KP6, Phường Linh Trung, Quận Thủ Đức', 'Tiếp tân');
INSERT INTO public."NhanVien"(
	"MaNhanVien", "HoTen", "CMND", "NgaySinh", "GioiTinh", "DiaChi", "ChucVu")
	VALUES ('NV002', 'Phạm Thị Hoa', '240153978911', '12/7/1991', 'Nữ', '253 Hoàng Diệu, Phường Linh Tây, Quận Thủ Đức', 'Tiếp tân');
INSERT INTO public."NhanVien"(
	"MaNhanVien", "HoTen", "CMND", "NgaySinh", "GioiTinh", "DiaChi", "ChucVu")
	VALUES ('NV003', 'Trần Tuấn Phong', '301017767126', '10/15/1990', 'Nam', '191 Điện Biên Phủ, Quận 1', 'Tiếp tân');
INSERT INTO public."NhanVien"(
	"MaNhanVien", "HoTen", "CMND", "NgaySinh", "GioiTinh", "DiaChi", "ChucVu")
	VALUES ('NV004', 'Nguyễn Minh Hoàng', '298017667142', '2/25/1992', 'Nam', '19 Nguyễn Đình Chiểu, Quận 3', 'Tiếp tân');
INSERT INTO public."NhanVien"(
	"MaNhanVien", "HoTen", "CMND", "NgaySinh", "GioiTinh", "DiaChi", "ChucVu")
	VALUES ('NV005', 'Lê Ngọc Ánh', '321897551843', '12/5/1989', 'Nữ', '112 KP5 Lý Thường Kiệt, Quận 10', 'Kế toán');
-----------------------------------------------------------------------------
--Thêm DỮ LIỆU BẢNG LOẠI KHÁCH HÀNG

INSERT INTO public."LoaiKhachHang"(
	"MaLoaiKhachHang", "TenLoai")
	VALUES ('LKH01', 'Khách nội địa');
INSERT INTO public."LoaiKhachHang"(
	"MaLoaiKhachHang", "TenLoai")
	VALUES ('LKH02', 'Khách nước ngoài');

------------------------------------------------------------------------
--Thêm Dữ LIỆU BẢNG KHÁCH HÀNG

INSERT INTO public."KhachHang"(
	"MaKhachHang", "HoTen", "CMND", "NgaySinh", "GioiTinh", "DiaChi", "SoDienThoai", "MaLoaiKhachHang")
	VALUES ('KH001', 'Trần Trí Văn', '276234216339', '11/23/1981', 'Nam', 'Kiên Giang', '01207779999', 'LKH01');
INSERT INTO public."KhachHang"(
	"MaKhachHang", "HoTen", "CMND", "NgaySinh", "GioiTinh", "DiaChi", "SoDienThoai", "MaLoaiKhachHang")
	VALUES ('KH002', 'Huỳnh Tố Tâm', '288234776980', '1/12/1979', 'Nữ', 'Trà Vinh', '01217788990', 'LKH01');
INSERT INTO public."KhachHang"(
	"MaKhachHang", "HoTen", "CMND", "NgaySinh", "GioiTinh", "DiaChi", "SoDienThoai", "MaLoaiKhachHang")
	VALUES ('KH003', 'Monkey D.Luffy', '299225797785', '5/1/1990', 'Nam', 'Nhật Bản', '01216785648', 'LKH02');
INSERT INTO public."KhachHang"(
	"MaKhachHang", "HoTen", "CMND", "NgaySinh", "GioiTinh", "DiaChi", "SoDienThoai", "MaLoaiKhachHang")
	VALUES ('KH004', 'Nico Robin', '302925117751', '5/1/1988', 'Nữ', 'Nhật Bản', '0939885446', 'LKH02');
INSERT INTO public."KhachHang"(
	"MaKhachHang", "HoTen", "CMND", "NgaySinh", "GioiTinh", "DiaChi", "SoDienThoai", "MaLoaiKhachHang")
	VALUES ('KH005', 'Nguyễn Mỹ Ngọc', '312267234729', '11/2/1991', 'Nữ', 'Tiền Giang', '0939767412', 'LKH01');
INSERT INTO public."KhachHang"(
	"MaKhachHang", "HoTen", "CMND", "NgaySinh", "GioiTinh", "DiaChi", "SoDienThoai", "MaLoaiKhachHang")
	VALUES ('KH006', 'Phạm Thiên Minh', '311784789450', '1/12/1989', 'Nam', 'Hà Nội', '0909342112', 'LKH01');
INSERT INTO public."KhachHang"(
	"MaKhachHang", "HoTen", "CMND", "NgaySinh", "GioiTinh", "DiaChi", "SoDienThoai", "MaLoaiKhachHang")
	VALUES ('KH007', 'Lê Minh Hoàng', '320711234278', '7/13/1976', 'Nam', 'Hà Nội', '0939566713', 'LKH01');
INSERT INTO public."KhachHang"(
	"MaKhachHang", "HoTen", "CMND", "NgaySinh", "GioiTinh", "DiaChi", "SoDienThoai", "MaLoaiKhachHang")
	VALUES ('KH008', 'Vivian', '112326551873', '2/11/1988', 'Nữ', 'Pháp', '0939566713', 'LKH02');
INSERT INTO public."KhachHang"(
	"MaKhachHang", "HoTen", "CMND", "NgaySinh", "GioiTinh", "DiaChi", "SoDienThoai", "MaLoaiKhachHang")
	VALUES ('KH009', 'Dylan', '124827816133', '10/27/1990', 'Nam', 'Hoa Kỳ', '0914666799', 'LKH02');
INSERT INTO public."KhachHang"(
	"MaKhachHang", "HoTen", "CMND", "NgaySinh", "GioiTinh", "DiaChi", "SoDienThoai", "MaLoaiKhachHang")
	VALUES ('KH010', 'Lý Khắc Hiếu', '297734194637', '11/9/1982', 'Nam', 'Vũng Tàu', '01239581129', 'LKH01');
INSERT INTO public."KhachHang"(
	"MaKhachHang", "HoTen", "CMND", "NgaySinh", "GioiTinh", "DiaChi", "SoDienThoai", "MaLoaiKhachHang")
	VALUES ('KH011', 'Âu Đức Toàn', '303735539815', '12/12/1977', 'Nam', 'Đồng Tháp', '01206681335', 'LKH01');
INSERT INTO public."KhachHang"(
	"MaKhachHang", "HoTen", "CMND", "NgaySinh", "GioiTinh", "DiaChi", "SoDienThoai", "MaLoaiKhachHang")
	VALUES ('KH012', 'Trịnh Nghiệp Thành', '299179135534', '5/6/1992', 'Nam', 'Đà Nẵng', '0914553640', 'LKH01');
------------------------------------------------------------------------------------

--THÊM DỮ LIỆU BẢNG LOẠI PHÒNG 

INSERT INTO public."LoaiPhong"(
	"MaLoaiPhong", "TenLoaiPhong", "DonGia")
	VALUES ('LP001', 'Phòng giường đơn thường', '500000');
INSERT INTO public."LoaiPhong"(
	"MaLoaiPhong", "TenLoaiPhong", "DonGia")
	VALUES ('LP002', 'Phòng giường đơn VIP', '2000000');
INSERT INTO public."LoaiPhong"(
	"MaLoaiPhong", "TenLoaiPhong", "DonGia")
	VALUES ('LP003', 'Phòng giường đôi thường', '900000');
INSERT INTO public."LoaiPhong"(
	"MaLoaiPhong", "TenLoaiPhong", "DonGia")
	VALUES ('LP004', 'Phòng giường đôi VIP', '3500000');
INSERT INTO public."LoaiPhong"(
	"MaLoaiPhong", "TenLoaiPhong", "DonGia")
	VALUES ('LP005', 'Phòng tập thể 4 giường', '2500000');

---------------------------------------------------------------------------------

--THÊM DỮ LIỆU BẢNG PHÒNG
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH100', 'Phòng 100' , 'LP001');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH101', 'Phòng 101' , 'LP001');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH102', 'Phòng 102' , 'LP001');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH103', 'Phòng 103' , 'LP001');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH104', 'Phòng 104' , 'LP001');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH200', 'Phòng 200' , 'LP002');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH201', 'Phòng 201' , 'LP002');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH202', 'Phòng 202' , 'LP002');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH203', 'Phòng 203' , 'LP002');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH204', 'Phòng 204' , 'LP002');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH300', 'Phòng 300' , 'LP003');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH301', 'Phòng 301' , 'LP3');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH302', 'Phòng 302' , 'LP3');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH303', 'Phòng 303' , 'LP3');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH304', 'Phòng 304' , 'LP3');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH400', 'Phòng 400' , 'LP4');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH401', 'Phòng 401' , 'LP4');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH402', 'Phòng 402' , 'LP4');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH403', 'Phòng 403' , 'LP4');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH404', 'Phòng 404' , 'LP4');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH500', 'Phòng 500' , 'LP5');
INSERT INTO public."Phong"(
	"MaPhong", "TenPhong", "MaLoaiPhong")
	VALUES ('PH501', 'Phòng 501' , 'LP5');

-----------------------------------------------------------------------------------
--THÊM DỮ LIỆU BẢNG PHIẾU THUÊ

--INSERT INTO public."PhieuThue"(
	--"MaPhieuThue", "MaKhachHang", "MaNhanVien", "NgayLap", "SoLuongPhong")
	--VALUES ('PT001', 'KH001', 'NV003', '5/27/2018', '2');

-----------------------------------------------------------------------------------
--THÊM DỮ LIỆU BẢNG CHI TIẾT PHIẾU THUÊ

--INSERT INTO public."ChiTietPhieuThue"(
	--"MaChiTietPhieuThue", "MaPhieuThue", "MaPhong", "NgayNhanPhong", "NgayTraPhong", "ThanhTienPhong", "PhuThu", "GhiChu")
	--VALUES ('CT001', 'PT001', 'PH100', '5/27/2018', '5/30/2018', '', '','' );
--INSERT INTO public."ChiTietPhieuThue"(
	--"MaChiTietPhieuThue", "MaPhieuThue", "MaPhong", "NgayNhanPhong", "NgayTraPhong", "ThanhTienPhong", "PhuThu", "GhiChu")
	--VALUES ('CT2', 'PT1', 'PH101', '5/27/2018', '5/29/2018', '','' ,'' );



