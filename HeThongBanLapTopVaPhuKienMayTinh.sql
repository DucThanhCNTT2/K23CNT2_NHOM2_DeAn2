CREATE DATABASE Project2_hthonglaptopvaphukienmaytinh;
GO

USE Project2_hthonglaptopvaphukienmaytinh;
GO

-- Bảng Thương Hiệu
CREATE TABLE ThuongHieu (
    MaTH nvarchar(10) PRIMARY KEY,
    TenTH NVARCHAR(100) NOT NULL,
    QuocGia NVARCHAR(50)
);

-- Bảng Sản Phẩm (chỉ lưu sản phẩm chung)
CREATE TABLE SanPham (
    MaSP nvarchar(10) PRIMARY KEY,
    TenSP NVARCHAR(150) NOT NULL,
    Gia DECIMAL(15,2) NOT NULL,
    SoLuong INT DEFAULT 0,
    MoTa NVARCHAR(MAX),
    MaTH nvarchar(10),
    FOREIGN KEY (MaTH) REFERENCES ThuongHieu(MaTH)
);

-- Bảng Laptop (mở rộng từ Sản phẩm)
CREATE TABLE Laptop (
    MaSP nvarchar(10) PRIMARY KEY,
    CPU NVARCHAR(100),
    RAM NVARCHAR(50),
    OCung NVARCHAR(100),
    CardDoHoa NVARCHAR(100),
    HeDieuHanh NVARCHAR(100),
    ManHinh NVARCHAR(50),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP) ON DELETE CASCADE
);

-- Bảng Khách Hàng
CREATE TABLE KhachHang (
    MaKH nvarchar(10) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    SDT NVARCHAR(20),
    Email NVARCHAR(100),
    DiaChi NVARCHAR(200)
);

-- Bảng Nhân Viên
CREATE TABLE NhanVien (
    MaNV nvarchar(10) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    ChucVu NVARCHAR(50),
    SDT NVARCHAR(20),
    Email NVARCHAR(100)
);

-- Bảng Hóa Đơn
CREATE TABLE HoaDon (
    MaHD nvarchar(10) PRIMARY KEY,
    NgayLap DATE NOT NULL,
    MaKH nvarchar(10),
    MaNV nvarchar(10),
    TongTien DECIMAL(15,2),
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

-- Bảng Chi Tiết Hóa Đơn
CREATE TABLE CTHoaDon (
    MaHD nvarchar(10),
    MaSP nvarchar(10),
    SoLuong INT NOT NULL,
    DonGia DECIMAL(15,2) NOT NULL,
    PRIMARY KEY (MaHD, MaSP),
    FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD) ON DELETE CASCADE,
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

-- Thêm Thương Hiệu
INSERT INTO ThuongHieu (MaTH ,TenTH, QuocGia) VALUES
(N'TH01' ,N'Acer', N'Mỹ'),
(N'TH02' ,N'Asus', N'Đài Loan'),
(N'TH03' ,N'LG', N'Hàn'),
(N'TH04' ,N'Lenovo', N'Trung Quốc');

-- =========================
-- NHÂN VIÊN
-- =========================
INSERT INTO NhanVien ( MaNV,HoTen, ChucVu, SDT, Email) VALUES
(N'NV01' ,N'Đinh Văn Hiếu', N'Quản lý', '0961234567', 'hieu@gmail.com'),
(N'NV02' ,N'Nguyễn Đức Thành', N'Nhân viên bán hàng', '0971234567', 'thanh@gmail.com'),
(N'NV03' ,N'Phạm Hoàng Nam', N'Thủ kho', '0981234567', 'nam@gmail.com'),
(N'NV04' ,N'Lê Thị Mai', N'Kế toán', '0991234567', 'mai@gmail.com'),
(N'NV05' ,N'Bùi Văn Phúc', N'Bảo trì', '0951234567', 'phuc@gmail.com');

-- =========================
-- KHÁCH HÀNG
-- =========================
INSERT INTO KhachHang (MaKH ,HoTen, SDT, Email, DiaChi) VALUES
(N'KH01' ,N'Nguyễn Văn A', '0901234567', 'a@gmail.com', N'Hà Nội'),
(N'KH02' ,N'Trần Thị B', '0912345678', 'b@gmail.com', N'Hải Phòng'),
(N'KH03' ,N'Lê Văn C', '0923456789', 'c@gmail.com', N'Đà Nẵng'),
(N'KH04' ,N'Phạm Thị D', '0934567890', 'd@gmail.com', N'HCM'),
(N'KH05' ,N'Hoàng Văn E', '0945678901', 'e@gmail.com', N'Cần Thơ');

-- =========================
-- SẢN PHẨM (chỉ Laptop, không còn Phụ kiện)
-- =========================
INSERT INTO SanPham (MaSP, TenSP, Gia, SoLuong, MoTa, MaTH) VALUES
(N'SP01',N'Acer Predator Helios 300 PH315-52-78HH Gaming Laptop', 15000000, 10, N'Laptop Gaminng', N'TH01'),  -- Asus
(N'SP02',N'Acer Swift 7 SF714-52T-7134 Laptop', 20000000, 8, N'Laptop học tập', N'TH01'),     -- Dell
(N'SP03',N'LG Gram 14ZD90N-V.AX55A5 Laptop', 18000000, 7, N'Laptop mỏng nhẹ', N'TH03'),      -- HP
(N'SP04',N'ASUS ROG Zephyrus M GU502GU-AZ090T Gaming', 25000000, 5, N'Laptop gaming', N'TH02'),       -- Acer
(N'SP05',N'Laptop Lenovo ThinkPad', 30000000, 3, N'Laptop doanh nhân', N'TH04'); -- Dell

-- =========================
-- CHI TIẾT LAPTOP
-- =========================
INSERT INTO Laptop (MaSP, CPU, RAM, OCung, CardDoHoa, HeDieuHanh, ManHinh) VALUES
(N'SP01', N'Intel i5', N'8GB', N'SSD 512GB', N'Intel Iris', N'Windows 11', N'15.6 inch'),
(N'SP02', N'Intel i7', N'16GB', N'SSD 1TB', N'NVIDIA GTX 1650', N'Windows 11', N'15.6 inch'),
(N'SP03', N'AMD Ryzen 5', N'8GB', N'SSD 512GB', N'AMD Radeon', N'Windows 11', N'14 inch'),
(N'SP04', N'Intel i7', N'16GB', N'SSD 1TB', N'NVIDIA RTX 3050', N'Windows 11', N'15.6 inch'),
(N'SP05', N'Intel i9', N'32GB', N'SSD 2TB', N'NVIDIA RTX 4060', N'Windows 11 Pro', N'16 inch');

-- =========================
-- HÓA ĐƠN
-- =========================
INSERT INTO HoaDon (MaHD ,NgayLap, MaKH, MaNV, TongTien) VALUES
(N'HD01','2025-08-01', N'KH01' , N'NV01', 15000000),
(N'HD02','2025-08-02', N'KH02' , N'NV02', 20000000),
(N'HD03','2025-08-03', N'KH03' , N'NV03', 18000000),
(N'HD04','2025-08-04', N'KH04' , N'NV04', 25000000),
(N'HD05','2025-08-05', N'KH05' , N'NV05', 30000000);

-- =========================
-- CHI TIẾT HÓA ĐƠN
-- =========================
INSERT INTO CTHoaDon (MaHD, MaSP, SoLuong, DonGia) VALUES
(N'HD01', N'SP01', 1, 15000000),  -- Asus Vivobook
(N'HD02', N'SP02', 1, 20000000),  -- Dell Inspiron
(N'HD03', N'SP03', 1, 18000000),  -- HP Pavilion
(N'HD04', N'SP04', 1, 25000000),  -- Acer Nitro 5
(N'HD05', N'SP05', 1, 30000000);  -- Lenovo ThinkPad

-- Xem toàn bộ bảng Thương Hiệu
SELECT * FROM ThuongHieu;

-- Xem toàn bộ bảng Sản Phẩm
SELECT 
    sp.MaSP,
    sp.TenSP,
    sp.Gia,
    th.TenTH AS ThuongHieu,
    th.QuocGia
FROM SanPham sp
JOIN ThuongHieu th ON sp.MaTH = th.MaTH;

-- Xem toàn bộ bảng Laptop
SELECT * FROM Laptop;

-- Xem toàn bộ bảng Khách Hàng
SELECT * FROM KhachHang;

-- Xem toàn bộ bảng Nhân Viên
SELECT * FROM NhanVien;

-- Xem toàn bộ bảng Hóa Đơn
SELECT 
    hd.MaHD,
    kh.HoTen AS TenKhachHang,
    nv.HoTen AS TenNhanVien,
    hd.NgayLap,
    hd.TongTien
FROM HoaDon hd
JOIN KhachHang kh ON hd.MaKH = kh.MaKH
JOIN NhanVien nv ON hd.MaNV = nv.MaNV;

-- Xem toàn bộ bảng Chi Tiết Hóa Đơn
SELECT 
    hd.MaHD,
    kh.HoTen AS TenKhachHang,
    nv.HoTen AS TenNhanVien,
    sp.TenSP AS TenSanPham,
    cthd.SoLuong,
    cthd.DonGia,
    hd.NgayLap
FROM CTHoaDon cthd
JOIN HoaDon hd ON cthd.MaHD = hd.MaHD
JOIN KhachHang kh ON hd.MaKH = kh.MaKH
JOIN NhanVien nv ON hd.MaNV = nv.MaNV
JOIN SanPham sp ON cthd.MaSP = sp.MaSP;


ALTER TABLE SanPham
ADD Anh NVARCHAR(255);

UPDATE SanPham
SET Anh = 'images/Acer-Predator-Helios.jpg'
WHERE MaSP = 'SP01';

UPDATE SanPham
SET Anh = 'images/Acer-Swift-7.jpg'
WHERE MaSP = 'SP02';

UPDATE SanPham
SET Anh = 'images/LG-Gram.jpg'
WHERE MaSP = 'SP03';

UPDATE SanPham
SET Anh = 'images/Asus-ROG-Zephyrus.jpg'
WHERE MaSP = 'SP04';

UPDATE SanPham
SET Anh = 'images/lenovo-thinkpad.jpg'
WHERE MaSP = 'SP05';