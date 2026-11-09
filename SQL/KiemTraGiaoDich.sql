-- Chi doc ket qua da luu; khong tao/xoa/sua bang.
USE MoneyCareDB;
GO
SELECT TOP (30)
    g.MaGiaoDich,
    g.UserId,
    d.Loai,
    d.TenDanhMuc,
    g.SoTien,
    g.NgayGiaoDich,
    g.GhiChu
FROM dbo.GiaoDich AS g
JOIN dbo.DanhMuc AS d
  ON d.MaDanhMuc = g.MaDanhMuc
 AND d.UserId = g.UserId
ORDER BY g.MaGiaoDich DESC;
GO
