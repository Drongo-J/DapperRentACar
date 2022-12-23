GO
CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
ImagePath NVARCHAR(MAX) NOT NULL,
Brand NVARCHAR(MAX) NOT NULL,
[Model] NVARCHAR(MAX) NOT NULL,
IsNew BIT NOT NULL,
Mileage INT NOT NULL,
[Type] NVARCHAR(MAX) NOT NULL,
[Year] INT NOT NULL, 
Color NVARCHAR(MAX) NOT NULL,
Price INT NOT NULL,
FuelType NVARCHAR(MAX) NOT NULL
)
GO

INSERT INTO Cars([ImagePath],[Brand],[Model],[IsNew],[Mileage],[Type],[Year],[Color],[Price],[FuelType])
VALUES
('https://turbo.azstatic.com/uploads/f460x343/2022%2F10%2F24%2F23%2F19%2F29%2F3f79eac3-9293-4d40-a7a4-204c8b7fb61b%2F87620_ZBI0LBB6A0che9sDaRiVwA.jpg', 'Jeep',     'Wrangler', 0, 132000, 'Offrouder / SUV', 2012, 'Black', 30900, 'Gasoline'),
('https://turbo.azstatic.com/uploads/full/2022%2F11%2F04%2F17%2F05%2F58%2F1bf7bd33-15a2-44bb-bba5-5cf693d7f73c%2F98234_RAQNpKaMW4px_nKsQvR2bw.jpg', 'Ford', 'F-150', 0, 20600, 'Pickup truck', 2020, 'Black', 123000, 'Gasoline'),
('https://turbo.azstatic.com/uploads/f460x343/2022%2F10%2F31%2F13%2F31%2F16%2Fe8d27b44-a2f0-4191-8605-253d2adab9f4%2F16186_rqZL0gQHyzCezgMby-6zfQ.jpg', 'Mercedes', 'E220', 0, 240000, 'Sedan', 2008, 'Black', 23200, 'Diesel'),
('https://turbo.azstatic.com/uploads/full/2022%2F12%2F06%2F16%2F59%2F40%2F52a6101b-c9f1-44d4-b61d-4189bfb8109c%2F53855_jqUyTQnltapHCSTUx00nSg.jpg', 'Hyundai', 'Santa Fe', 0, 80000, 'Offroader / SUV', 2014, 'Black', 25800, 'Diesel'),
('https://turbo.azstatic.com/uploads/full/2022%2F10%2F24%2F18%2F25%2F21%2Fffefc211-44c6-4bc9-bda4-38190aafb661%2F88509_iKpYOQns0-YRi14srakZzQ.jpg', 'Mercedes', 'E220', 0, 40000, 'Sedan', 2020, 'Black', 63900	, 'Diesel'),
('https://turbo.azstatic.com/uploads/full/2022%2F10%2F24%2F19%2F49%2F32%2Ff531605a-41b9-4ae9-bf52-c5aaad3f0471%2F88515_02LGv_BgvS9eH5m0IhnETA.jpg', 'Mercedes', 'E220', 0, 136000, 'Sedan', 2016, 'Black', 46500, 'Diesel'),
('https://turbo.azstatic.com/uploads/f460x343/2022%2F11%2F01%2F12%2F33%2F39%2Fdfd0089c-16d4-4b21-b667-eba3fed9b5b7%2F80095_ydsl3srU7-abyKp5BFr3Xg.jpg', 'Mercedes', 'E220', 0, 110000, 'Sedan', 2018, 'Sky', 50000, 'Diesel'),
('https://turbo.azstatic.com/uploads/f460x343/2022%2F11%2F26%2F15%2F30%2F32%2Ff091a2b6-93d2-43cb-9edf-947b93a2f8d8%2F67484_i_1wbP6oFVQf5azdW47Wsg.jpg', 'Land Rover', 'Range Rover', 0, 136800, 'Offroader / SUV', 2015, 'Black', 69500, 'Diesel'),
('https://turbo.azstatic.com/uploads/full/2022%2F10%2F31%2F15%2F16%2F49%2F599c1771-a70b-472e-92cd-e9acaa840f8e%2F127_WQYpXZYjTYHCQ4C9oXiRUQ.jpg', 'Mercedes', 'GL 500', 0, 148000, 'Offroader / SUV', 2013, 'White', 39500, 'Gasoline'),
('https://turbo.azstatic.com/uploads/full/2022%2F11%2F02%2F17%2F39%2F10%2Ffb3ef93a-be5b-4651-bcea-e6aeda85b043%2F40729_QIFkqyX9sF-BMjJsTYmpHA.jpg', 'Land Rover', 'RR Sport', 0, 91000, 'Offroader / SUV', 2019, 'Black', 78000, 'Gasoline'),
('https://turbo.azstatic.com/uploads/full/2022%2F11%2F25%2F16%2F11%2F47%2F5c898222-ec00-464d-98db-ead963cadc11%2F22643_0oOoow5BO8oEEBFA0ww1pg.jpg', 'Mercedes', 'E220', 0, 145000, 'Sedan', 2017, 'White', 49800, 'Diesel'),
('https://turbo.azstatic.com/uploads/full/2022%2F10%2F24%2F17%2F41%2F40%2Fdf8fd785-f00b-4785-b22c-4fd89f316a28%2F88511_7myX_xgydmLd-ORzEotcTA.jpg', 'Land Rover', 'Range Rover', 0, 134000, 'Offroader / SUV', 2018, 'Black', 99700, 'Diesel'),
('https://turbo.azstatic.com/uploads/f460x343/2022%2F12%2F17%2F00%2F03%2F27%2Fb9d7f472-99f5-4a07-84ec-ded914b7b842%2F42087_zxMQHS5_JAcC2gEw6B_E7g.jpg', 'Mercedes', 'E220', 0, 156700, 'Sedan', 2012, 'Black', 21900, 'Diesel'),
('https://turbo.azstatic.com/uploads/f460x343/2022%2F12%2F17%2F00%2F19%2F11%2F946b86c5-6e35-4a6e-b13b-8d5654fd87eb%2F49383_XridbcUpGePZs5MOLcm38Q.jpg', 'Mercedes', 'S 350', 0, 58000, 'Sedan', 2020, 'Black', 115000, 'Diesel'),
('https://turbo.azstatic.com/uploads/f460x343/2022%2F10%2F25%2F14%2F56%2F24%2Fb61bbc4c-06f3-480c-ba5d-15e90b943e9d%2F73790_RqxHuUKTDpqkTKQMl76MLg.jpg', 'Nissan', 'X-Trail', 0, 140000, 'Offroader / SUV', 2002, 'Red', 10000, 'Gasoline'),
('https://turbo.azstatic.com/uploads/f460x343/2022%2F10%2F24%2F18%2F08%2F53%2Fa6d0b9cf-41f5-4009-b6da-c5bc16cacc30%2F87645_I7vwpe_xNEeEhdw6qBFjUg.jpg', 'Mercedes', 'S 350', 0, 70000, 'Sedan', 2019, 'Black', 99900, 'Diesel'),
('https://turbo.azstatic.com/uploads/f460x343/2022%2F10%2F25%2F14%2F47%2F07%2Fe26281dd-99cc-4b1c-932f-2e0766da6a82%2F73792_Z5Qnni0zipx6Gwztz7Gq9g.jpg', 'BMW', 'X5', 0, 146500, 'Offroader / SUV', 2015, 'Black', 36900, 'Gasoline'),
('https://turbo.azstatic.com/uploads/full/2022%2F10%2F24%2F22%2F37%2F50%2F1d928ff6-39bc-41df-bc05-fe0dd8b15397%2F88502_R0F4pgba8b0VlLcVlEdHyw.jpg', 'Mitsubishi', 'Pajero', 0, 187000, 'Offroader / SUV', 2017, 'Black', 26500, 'Gasoline'),
('https://turbo.azstatic.com/uploads/f460x343/2022%2F11%2F21%2F20%2F01%2F23%2F295117c2-36df-4301-9f5e-88a61d4c7d62%2F2378_jHIxg2RE9QvuIuhnVikKqg.jpg', 'BMW', 'X5', 0, 101000, 'Offroader / SUV', 2014, 'White', 39900, 'Gasoline')
