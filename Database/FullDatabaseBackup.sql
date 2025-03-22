CREATE DATABASE CoffeeShopManagementData
GO

USE CoffeeShopManagementData
GO

CREATE TABLE Account
(
	UserName NVARCHAR(100) PRIMARY KEY,
	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'UserX', 	
	PassWord NVARCHAR(1000) NOT NULL DEFAULT N'2024',
	Type INT NOT NULL DEFAULT 0, -- 1: admin || 0: manager
	Avatar NVARCHAR(255) NULL DEFAULT N'Resources\Avatar.png'
)
GO

CREATE TABLE TableFood 
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Bàn chưa có tên',
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống' -- Trống || Có khách
)
GO

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0

	FOREIGN KEY (idCategory) REFERENCES FoodCategory(id)
)
GO

CREATE TABLE Bill
(
    id INT IDENTITY PRIMARY KEY,
    DateCheckIn DATE NOT NULL,
    DateCheckOut DATE,
    idTable INT NOT NULL,
    status INT NOT NULL DEFAULT 0, -- 1: Đã thanh toán || 0: Chưa thanh toán
    discount INT NOT NULL DEFAULT 0, -- Giảm giá mặc định là 0
    totalPrice FLOAT, -- Tổng giá
    
    FOREIGN KEY (idTable) REFERENCES TableFood(id)
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0

	FOREIGN KEY (idBill) REFERENCES Bill(id),
	FOREIGN KEY (idFood) REFERENCES Food(id)
)
GO

-- Thêm tài khoản Người dùng và Admin
INSERT INTO Account (UserName, DisplayName, PassWord, Type) 
VALUES  (N'Admin1', N'Nguyễn Hữu Toàn', N'2024', 1),
		(N'Admin2', N'Nguyễn Thành Luân', N'2024', 1),
		(N'Admin3', N'Trần Khôi Nguyên', N'2024', 1),
		(N'User1', N'Người dùng tài khoản', N'2024', 0)
GO

-- Chèn dữ liệu vào bảng TableFood với id từ 20 đến 49
INSERT INTO TableFood (name, status)
VALUES
(N'Bàn 1', N'Trống'),
(N'Bàn 2', N'Trống'),
(N'Bàn 3', N'Trống'),
(N'Bàn 4', N'Trống'),
(N'Bàn 5', N'Trống'),
(N'Bàn 6', N'Trống'),
(N'Bàn 7', N'Trống'),
(N'Bàn 8', N'Trống'),
(N'Bàn 9', N'Trống'),
(N'Bàn 10', N'Trống'),
(N'Bàn 11', N'Trống'),
(N'Bàn 12', N'Trống'),
(N'Bàn 13', N'Trống'),
(N'Bàn 14', N'Trống'),
(N'Bàn 15', N'Trống'),
(N'Bàn 16', N'Trống'),
(N'Bàn 17', N'Trống'),
(N'Bàn 18', N'Trống'),
(N'Bàn 19', N'Trống'),
(N'Bàn 20', N'Trống'),
(N'Bàn 21', N'Trống'),
(N'Bàn 22', N'Trống'),
(N'Bàn 23', N'Trống'),
(N'Bàn 24', N'Trống'),
(N'Bàn 25', N'Trống'),
(N'Bàn 26', N'Trống'),
(N'Bàn 27', N'Trống'),
(N'Bàn 28', N'Trống'),
(N'Bàn 29', N'Trống'),
(N'Bàn 30', N'Trống');
GO

-- Chèn dữ liệu vào bảng FoodCategory
INSERT INTO FoodCategory (name)
VALUES
(N'Nước'),
(N'Cà phê'),
(N'Thực phẩm'),
(N'Kẹo'),
(N'Bánh');
GO

-- Chèn dữ liệu vào bảng Food với giá từ 10000 đến 50000
INSERT INTO Food (name, idCategory, price)
VALUES
-- Nhóm Nước
(N'Nước khoáng', 1, 15000),
(N'Nước trái cây', 1, 20000),
(N'Nước ngọt', 1, 25000),
(N'Nước lọc', 1, 10000),
(N'Nước chanh', 1, 18000),

-- Nhóm Cà phê
(N'Cà phê đen', 2, 30000),
(N'Cà phê sữa đá', 2, 35000),
(N'Cà phê latte', 2, 40000),
(N'Cà phê cappuccino', 2, 45000),
(N'Cà phê mocha', 2, 50000),

-- Nhóm Thực phẩm
(N'Bánh mì kẹp thịt', 3, 30000),
(N'Phở bò', 3, 40000),
(N'Gà chiên', 3, 35000),
(N'Súp rau', 3, 25000),
(N'Xôi xéo', 3, 28000),

-- Nhóm Kẹo
(N'Kẹo dẻo', 4, 12000),
(N'Kẹo mút', 4, 15000),
(N'Kẹo socola', 4, 20000),
(N'Kẹo gôm', 4, 18000),
(N'Kẹo bạc hà', 4, 16000),

-- Nhóm Bánh
(N'Bánh ngọt', 5, 25000),
(N'Bánh quy', 5, 18000),
(N'Bánh kem', 5, 30000),
(N'Bánh su', 5, 22000),
(N'Bánh bao', 5, 15000);
GO

-- Chèn dữ liệu vào bảng Bill với idTable từ 20 đến 50
INSERT INTO Bill (DateCheckIn, DateCheckOut, idTable, status, discount, totalPrice)
VALUES 
('2024-08-01', '2024-08-01', 1, 1, 10, 50000),
('2024-08-02', '2024-08-02', 2, 1, 15, 75000),
('2024-08-03', '2024-08-03', 3, 1, 5, 30000),
('2024-08-04', '2024-08-04', 4, 1, 20, 80000),
('2024-08-05', '2024-08-05', 5, 1, 10, 40000),
('2024-08-06', '2024-08-06', 6, 1, 25, 100000),
('2024-08-07', '2024-08-07', 7, 1, 0, 0),
('2024-08-08', '2024-08-08', 8, 1, 10, 55000),
('2024-08-09', '2024-08-09', 9, 1, 15, 70000),
('2024-08-10', '2024-08-10', 10, 1, 5, 30000),
('2024-08-11', '2024-08-11', 11, 1, 20, 85000),
('2024-08-12', '2024-08-12', 12, 1, 10, 45000),
('2024-08-13', '2024-08-13', 13, 1, 25, 95000),
('2024-08-14', '2024-08-14', 14, 1, 15, 75000),
('2024-08-15', '2024-08-15', 15, 1, 10, 50000),
('2024-08-16', '2024-08-16', 16, 1, 20, 80000),
('2024-08-17', '2024-08-17', 17, 1, 5, 35000),
('2024-08-18', '2024-08-18', 18, 1, 25, 95000),
('2024-08-19', '2024-08-19', 19, 1, 15, 70000),
('2024-08-20', '2024-08-20', 20, 1, 10, 55000),
('2024-08-21', '2024-08-21', 21, 1, 5, 30000),
('2024-08-22', '2024-08-22', 22, 1, 20, 85000),
('2024-08-23', '2024-08-23', 23, 1, 10, 45000),
('2024-08-24', '2024-08-24', 24, 1, 25, 95000),
('2024-08-25', '2024-08-25', 25, 1, 15, 75000),
('2024-07-01', '2024-07-01', 1, 1, 10, 50000),
('2024-07-02', '2024-07-02', 2, 1, 15, 75000),
('2024-07-03', '2024-07-03', 3, 1, 5, 30000),
('2024-07-04', '2024-07-04', 4, 1, 20, 80000),
('2024-07-05', '2024-07-05', 5, 1, 10, 40000),
('2024-06-01', '2024-06-01', 1, 1, 25, 100000),
('2024-06-02', '2024-06-02', 2, 1, 0, 0),
('2024-06-03', '2024-06-03', 3, 1, 10, 55000),
('2024-06-04', '2024-06-04', 4, 1, 15, 70000),
('2024-06-05', '2024-06-05', 5, 1, 5, 30000),
('2024-05-01', '2024-05-01', 1, 1, 20, 85000),
('2024-05-02', '2024-05-02', 2, 1, 10, 45000),
('2024-05-03', '2024-05-03', 3, 1, 25, 95000),
('2024-05-04', '2024-05-04', 4, 1, 15, 75000),
('2024-05-05', '2024-05-05', 5, 1, 10, 50000),
('2024-04-01', '2024-04-01', 1, 1, 5, 35000),
('2024-04-02', '2024-04-02', 2, 1, 25, 95000),
('2024-04-03', '2024-04-03', 3, 1, 15, 70000),
('2024-04-04', '2024-04-04', 4, 1, 10, 55000),
('2024-04-05', '2024-04-05', 5, 1, 0, 0),
('2024-03-01', '2024-03-01', 1, 1, 20, 80000),
('2024-03-02', '2024-03-02', 2, 1, 15, 75000),
('2024-03-03', '2024-03-03', 3, 1, 10, 50000),
('2024-03-04', '2024-03-04', 4, 1, 5, 35000),
('2024-03-05', '2024-03-05', 5, 1, 20, 85000);
GO

-- Chèn dữ liệu vào bảng BillInfo
INSERT INTO BillInfo (idBill, idFood, count)
VALUES
(1, 1, 2),
(1, 2, 1),
(1, 3, 3),
(2, 4, 1),
(2, 5, 2),
(2, 6, 1),
(3, 7, 1),
(3, 8, 2),
(4, 9, 2),
(4, 10, 3),
(4, 11, 1),
(5, 12, 1),
(5, 13, 1),
(5, 14, 2),
(6, 15, 1),
(6, 16, 2),
(6, 17, 3),
(7, 18, 1),
(7, 19, 1),
(8, 20, 2),
(8, 21, 3),
(8, 22, 1),
(9, 23, 2),
(9, 24, 1),
(10, 5, 1),
(10, 6, 2),
(10, 7, 3),
(11, 8, 1),
(11, 9, 2),
(11, 3, 1),
(12, 1, 1),
(12, 2, 2),
(12, 3, 1),
(13, 4, 1),
(13, 5, 3),
(13, 6, 1),
(14, 7, 2),
(14, 8, 1),
(14, 9, 2),
(15, 10, 2),
(15, 11, 1),
(15, 12, 3),
(16, 13, 2),
(16, 14, 1),
(16, 15, 1),
(17, 16, 1),
(17, 17, 2),
(17, 18, 1),
(18, 19, 3),
(18, 20, 1),
(18, 21, 2),
(19, 22, 1),
(19, 23, 2),
(19, 24, 1),
(20, 5, 3),
(20, 6, 1),
(20, 7, 2),
(1, 1, 2),
(1, 2, 1),
(1, 3, 3),
(2, 4, 1),
(2, 5, 2),
(2, 6, 1),
(3, 7, 1),
(3, 8, 2),
(4, 9, 2),
(4, 10, 3),
(4, 11, 1),
(5, 12, 1),
(5, 13, 1),
(5, 14, 2),
(6, 15, 1),
(6, 16, 2),
(6, 17, 3),
(7, 18, 1),
(7, 19, 1),
(8, 20, 2),
(8, 21, 3),
(8, 22, 1),
(9, 23, 2),
(9, 24, 1),
(10, 5, 1),
(10, 6, 2),
(10, 7, 3),
(11, 8, 1),
(11, 9, 2),
(11, 3, 1),
(12, 1, 1),
(12, 2, 2),
(12, 3, 1),
(13, 4, 1),
(13, 5, 3),
(13, 6, 1),
(14, 7, 2),
(14, 8, 1),
(14, 9, 2),
(15, 10, 2),
(15, 11, 1),
(15, 12, 3),
(16, 13, 2),
(16, 14, 1),
(16, 15, 1),
(17, 16, 1),
(17, 17, 2),
(17, 18, 1),
(18, 19, 3),
(18, 20, 1),
(18, 21, 2),
(19, 22, 1),
(19, 23, 2),
(19, 24, 1),
(20, 5, 3),
(20, 6, 1),
(20, 7, 2);
GO

-- Danh sách các PROC --------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROC USP_GetAccountByUserName
@userName nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName
END
GO

CREATE PROC USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END
GO

CREATE PROC USP_GetTableList
AS SELECT * FROM TableFood
Go


CREATE PROC USP_InsertBill
@idTable INT
AS
BEGIN
	INSERT Bill(DateCheckIn, DateCheckOut, idTable, status, discount)
	VALUES (GETDATE(), NULL, @idTable, 0, 0)
END
GO

CREATE PROC USP_InsertBillInfo
    @idBill INT,
    @idFood INT,
    @count INT
AS
BEGIN
    DECLARE @isExitsBillInfo INT;
    DECLARE @foodCount INT = 1;

    SELECT @isExitsBillInfo = b.id, @foodCount = b.count 
    FROM BillInfo AS b 
    WHERE idBill = @idBill AND idFood = @idFood;

    IF (@isExitsBillInfo > 0)
    BEGIN
        DECLARE @newCount INT = @foodCount + @count
        IF (@newCount > 0)
        BEGIN
            UPDATE BillInfo 
            SET count = @foodCount + @count
            WHERE idFood = @idFood AND idBill = @idBill
        END
        ELSE 
        BEGIN
            DELETE FROM BillInfo 
            WHERE idBill = @idBill AND idFood = @idFood
        END
    END
    ELSE
    BEGIN
        INSERT INTO BillInfo (idBill, idFood, count)
        VALUES (@idBill, @idFood, @count);
    END
END
GO

CREATE TRIGGER UTG_UpdateBillInfo
ON BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBIll INT

	SELECT @idBIll = idBill FROM inserted

	DECLARE @idTable INT

	SELECT @idTable = idTable FROM Bill WHERE id = @idBill AND status = 0

	DECLARE @count INT
	SELECT @count = COUNT(*) FROM BillInfo WHERE idBill = @idBIll

	IF (@count > 0)
		UPDATE TableFood  SET status = N'Có khách' WHERE id = @idTable
	ELSE
		UPDATE TableFood  SET status = N'Trống' WHERE id = @idTable
END
GO

CREATE TRIGGER UTG_UpdateTable
ON TableFood FOR UPDATE
AS
BEGIN
	DECLARE @idTable INT
	DECLARE @status NVARCHAR(100)
	SELECT @idTable = id, @status = inserted.status FROM Inserted

	DECLARE @idBill INT
	SELECT @idBill = id FROM Bill WHERE idTable = @idTable AND Status = 0

	DECLARE @countBillInfo INT
	SELECT @countBillInfo = COUNT(*) FROM BillInFo WHERE idBill = @idBill

	IF (@countBillInfo > 0 AND @status <> N'Có khách')
		UPDATE TableFood  SET status = N'Có khách' WHERE id = @idTable
	ELSE IF (@countBillInfo <= 0 AND @status <> N'Trống')
		UPDATE TableFood  SET status = N'Trống' WHERE id = @idTable

END
GO

CREATE TRIGGER UTG_UpdateBill
ON Bill FOR UPDATE
AS
BEGIN	
	DECLARE @idBill INT

	SELECT @idBill = id FROM inserted

	DECLARE @idTable INT

	SELECT @idTable = idTable FROM Bill WHERE id = @idBill

	DECLARE @count INT = 0;

	SELECT @count = count(*) FROM Bill WHERE idTable = @idTable AND status = 0

	IF (@count = 0)
		UPDATE TableFood SET status = N'Trống' WHERE id = @idTable
END
GO

CREATE PROC USP_SwitchTable
@idTable1 INT, @idTable2 INT
AS 
BEGIN
	
	DECLARE @idFirstBill INT
	DECLARE @idSecondBill INT

	DECLARE @isFirstTableEmpty INT = 1
	DECLARE @isSecondTableEmpty INT = 1

	SELECT @idSecondBill = id FROM Bill WHERE idTable = @idTable2 AND status = 0
	SELECT @idFirstBill = id FROM Bill WHERE idTable = @idTable1 AND status = 0

	IF (@idFirstBill IS NULL)
	BEGIN
		INSERT INTO Bill(DateCheckIn, DateCheckOut, idTable, status)
		VALUES (GETDATE(), NULL, @idTable1, 0)
		SELECT @idFirstBill = MAX (id) FROM Bill WHERE idTable = @idTable1 AND status = 0
	END

	SELECT @isFirstTableEmpty = COUNT(*) FROM BillInfo WHERE idBill = @idFirstBill

		IF (@idSecondBill IS NULL)
	BEGIN
		INSERT INTO Bill(DateCheckIn, DateCheckOut, idTable, status)
		VALUES (GETDATE(), NULL, @idTable2, 0)
		SELECT @idSecondBill = MAX (id) FROM Bill WHERE idTable = @idTable2 AND status = 0
	END
	
	SELECT @isSecondTableEmpty = COUNT(*) FROM BillInfo WHERE idBill = @idSecondBill

	SELECT id INTO IDBillInfoTable FROM BillInfo WHERE idBill = @idSecondBill

	UPDATE BillInfo SET idBill = @idSecondBill WHERE idBill = @idFirstBill

	UPDATE BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM IDBillInfoTable)

	DROP TABLE IDBillInfoTable

	IF (@isFirstTableEmpty = 0)
		UPDATE TableFood SET status = N'Trống' WHERE id = @idTable2
		
		IF (@isSecondTableEmpty = 0)
		UPDATE TableFood SET status = N'Trống' WHERE id = @idTable1
END
GO

CREATE PROC USP_MergeTable
@idTable1 INT, @idTable2 INT
AS
BEGIN
    DECLARE @idFirstBill INT
    DECLARE @idSecondBill INT

    DECLARE @isFirstTableEmpty INT = 1
    DECLARE @isSecondTableEmpty INT = 1

    SELECT @idFirstBill = id FROM Bill WHERE idTable = @idTable1 AND status = 0

    SELECT @idSecondBill = id FROM Bill WHERE idTable = @idTable2 AND status = 0

    IF (@idFirstBill IS NULL)
    BEGIN
        INSERT INTO Bill(DateCheckIn, DateCheckOut, idTable, status)
        VALUES (GETDATE(), NULL, @idTable1, 0)
        SELECT @idFirstBill = MAX(id) FROM Bill WHERE idTable = @idTable1 AND status = 0
    END

    IF (@idSecondBill IS NULL)
    BEGIN
        INSERT INTO Bill(DateCheckIn, DateCheckOut, idTable, status)
        VALUES (GETDATE(), NULL, @idTable2, 0)
        SELECT @idSecondBill = MAX(id) FROM Bill WHERE idTable = @idTable2 AND status = 0
    END

    SELECT @isFirstTableEmpty = COUNT(*) FROM BillInfo WHERE idBill = @idFirstBill
    SELECT @isSecondTableEmpty = COUNT(*) FROM BillInfo WHERE idBill = @idSecondBill

    IF (@isSecondTableEmpty > 0)
    BEGIN
        UPDATE BillInfo SET idBill = @idFirstBill WHERE idBill = @idSecondBill
    END

    SELECT @isSecondTableEmpty = COUNT(*) FROM BillInfo WHERE idBill = @idSecondBill
    IF (@isSecondTableEmpty = 0)
    BEGIN
        UPDATE TableFood SET status = N'Trống' WHERE id = @idTable2
    END

    IF (@isFirstTableEmpty = 0)
    BEGIN
        UPDATE TableFood SET status = N'Có khách' WHERE id = @idTable1
    END

    IF (@isSecondTableEmpty = 0)
    BEGIN
        DELETE FROM Bill WHERE id = @idSecondBill
    END
END
GO

CREATE PROC USP_GetListBillByDate
@checkIn date, @checkOut date
AS
BEGIN
	SELECT b.id AS [ID], t.name AS [Tên bàn], b.totalPrice AS [Tổng tiền],
	DateCheckIn AS [Ngày vào], DateCheckOut AS [Ngày ra],
	discount AS [Giảm giá]
	FROM Bill AS b, TableFood AS t
	WHERE DateCheckIn >= @checkIn 
		AND DateCheckOut <= @checkOut
		AND b.status = 1
		AND t.id = b.idTable
END
GO

CREATE PROC USP_UpdateAccount
@userName NVARCHAR(100), @displayName NVARCHAR(100), 
@password NVARCHAR(100), @newPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT

	SELECT @isRightPass = COUNT(*) FROM Account WHERE UserName = @userName AND PassWord = @password

	IF (@isRightPass = 1)
	BEGIN
		IF (@newPassword IS NULL OR @newPassword = N'')
		BEGIN
			UPDATE Account SET DisplayName = @displayName WHERE UserName = @userName
		END
		ELSE
			UPDATE Account SET DisplayName = @displayName, Password = @newPassword WHERE UserName = @userName
	END
END
GO

CREATE TRIGGER UTG_DeleteBillInfo
ON BillInfo
FOR DELETE
AS
BEGIN
    -- Tạo bảng tạm để lưu trữ các idBill bị ảnh hưởng
    DECLARE @BillIds TABLE (idBill INT);

    -- Chèn tất cả các idBill từ bảng Deleted vào bảng tạm
    INSERT INTO @BillIds (idBill)
    SELECT idBill
    FROM Deleted;

    -- Cập nhật trạng thái cho các bảng TableFood liên quan
    UPDATE TableFood
    SET status = N'Trống'
    WHERE id IN (
        SELECT b.idTable
        FROM Bill b
        LEFT JOIN BillInfo bi ON b.id = bi.idBill
        WHERE b.id IN (SELECT idBill FROM @BillIds)
        GROUP BY b.idTable
        HAVING COUNT(bi.idBill) = 0
    );
END
GO

CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) 
AS 
BEGIN 
	IF @strInput IS NULL 
		RETURN @strInput 
	IF @strInput = '' 
		RETURN @strInput 

	DECLARE @RT NVARCHAR(4000) 
	DECLARE @SIGN_CHARS NCHAR(136) 
	DECLARE @UNSIGN_CHARS NCHAR (136) 
	SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) 
	SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' 
	DECLARE @COUNTER int 
	DECLARE @COUNTER1 int 
	SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) 
	BEGIN 
		SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) 
		BEGIN 
			IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) 
				BEGIN 
					IF @COUNTER=1 
						SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) 
					ELSE 
						SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK 
				END 
			SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 
		END 
	SET @strInput = replace(@strInput,' ','-') 
	RETURN @strInput 
END
GO

CREATE TRIGGER TRG_DeleteTableFood
ON TableFood
FOR DELETE
AS
BEGIN
    -- Xóa BillInfo liên quan đến các Bill
    DELETE FROM BillInfo
    WHERE idBill IN (SELECT id FROM Bill WHERE idTable IN (SELECT id FROM Deleted));

    -- Xóa Bill liên quan đến các TableFood
    DELETE FROM Bill
    WHERE idTable IN (SELECT id FROM Deleted);

    -- Xóa TableFood
    DELETE FROM TableFood
    WHERE id IN (SELECT id FROM Deleted);
END
GO

CREATE PROC USP_GetListBillByDateAndPage
@checkIn date, @checkOut date, @page INT
AS
BEGIN
	DECLARE @pageRows INT = 15
	DECLARE @selectRows INT = @pageRows
	DECLARE @exceptRows INT = (@page - 1) * @pageRows

	;WITH BillShow AS (SELECT b.id AS [ID], t.name AS [Tên bàn], b.totalPrice AS [Tổng tiền],
	DateCheckIn AS [Ngày vào], DateCheckOut AS [Ngày ra],
	discount AS [Giảm giá]
	FROM Bill AS b, TableFood AS t
	WHERE DateCheckIn >= @checkIn 
		AND DateCheckOut <= @checkOut
		AND b.status = 1
		AND t.id = b.idTable)
	
	SELECT TOP (@selectRows) * FROM BillShow WHERE id NOT IN
	(SELECT TOP (@exceptRows) id FROM BillShow)
END
GO

CREATE PROC USP_GetNumBillByDate
@checkIn date, @checkOut date
AS
BEGIN
	SELECT COUNT(*)
	FROM Bill AS b, TableFood AS t
	WHERE DateCheckIn >= @checkIn 
		AND DateCheckOut <= @checkOut
		AND b.status = 1
		AND t.id = b.idTable
END
GO

CREATE PROC USP_GetListBillByDateForReport
@checkIn date, @checkOut date
AS
BEGIN
	SELECT b.id AS [ID], t.name AS [Table Name], b.totalPrice AS [Total Price],
	DateCheckIn AS [Day Check In], DateCheckOut AS [Date Check Out],
	discount AS [Discount]
	FROM Bill AS b, TableFood AS t
	WHERE DateCheckIn >= @checkIn 
		AND DateCheckOut <= @checkOut
		AND b.status = 1
		AND t.id = b.idTable
END
GO

CREATE PROC USP_GetMonthlyRevenue
    @checkIn date, 
    @checkOut date
AS
BEGIN
    SELECT 
        MONTH(b.DateCheckIn) AS [Tháng], 
        YEAR(b.DateCheckIn) AS [Năm], 
        SUM(b.totalPrice) AS [Doanh thu]
    FROM 
        Bill AS b
    WHERE 
        b.DateCheckIn >= @checkIn
        AND b.DateCheckOut <= @checkOut
        AND b.status = 1
    GROUP BY 
        MONTH(b.DateCheckIn), YEAR(b.DateCheckIn)
    ORDER BY 
        YEAR(b.DateCheckIn), MONTH(b.DateCheckIn)
END
GO
