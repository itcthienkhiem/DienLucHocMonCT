USE [QLKhoDienLuc]
GO
/****** Object:  Table [dbo].[Chi_Tiet_Phieu_Xuat_Tam]    Script Date: 10/16/2015 15:16:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Chi_Tiet_Phieu_Xuat_Tam](
	[ID_chi_tiet_phieu_xuat_tam] [int] IDENTITY(1,1) NOT NULL,
	[Ma_phieu_xuat_tam] [varchar](50) NOT NULL,
	[Ma_vat_tu] [varchar](50) NOT NULL,
	[So_luong_de_nghi] [int] NULL,
	[So_luong_thuc_lanh] [int] NULL,
	[Da_duyen_xuat_vat_tu] [bit] NULL,
	[So_luong_hoan_nhap] [int] NULL,
	[So_luong_giu_lai] [int] NULL,
	[Da_duyet_hoan_nhap_giu_lai] [bit] NULL,
	[So_luong_su_dung] [int] NULL,
 CONSTRAINT [PK_Chi_Tiet_Phieu_Xuat_Tam] PRIMARY KEY CLUSTERED 
(
	[ID_chi_tiet_phieu_xuat_tam] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Chi_Tiet_Phieu_Nhap_Vat_Tu]    Script Date: 10/16/2015 15:16:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Chi_Tiet_Phieu_Nhap_Vat_Tu](
	[ID_chi_tiet_phieu_nhap_vat_tu] [int] IDENTITY(1,1) NOT NULL,
	[Ma_phieu_nhap] [varchar](50) NULL,
	[Ma_vat_tu] [varchar](50) NULL,
	[Chat_luong] [nvarchar](50) NULL,
	[So_luong_yeu_cau] [int] NULL,
	[So_luong_thuc_lanh] [int] NULL,
	[Don_gia] [int] NULL,
	[Thanh_tien] [int] NULL,
	[ID_Don_vi_tinh] [int] NULL,
	[Da_duyet] [bit] NULL,
 CONSTRAINT [PK_Chi_Tiet_Phieu_Nhap_Vat_Tu] PRIMARY KEY CLUSTERED 
(
	[ID_chi_tiet_phieu_nhap_vat_tu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Chi_Tiet_Phieu_Nhap_Vat_Tu] ON
INSERT [dbo].[Chi_Tiet_Phieu_Nhap_Vat_Tu] ([ID_chi_tiet_phieu_nhap_vat_tu], [Ma_phieu_nhap], [Ma_vat_tu], [Chat_luong], [So_luong_yeu_cau], [So_luong_thuc_lanh], [Don_gia], [Thanh_tien], [ID_Don_vi_tinh], [Da_duyet]) VALUES (5, N'12345611', N'12126666', N'', 0, 15, 0, 0, 2, 1)
INSERT [dbo].[Chi_Tiet_Phieu_Nhap_Vat_Tu] ([ID_chi_tiet_phieu_nhap_vat_tu], [Ma_phieu_nhap], [Ma_vat_tu], [Chat_luong], [So_luong_yeu_cau], [So_luong_thuc_lanh], [Don_gia], [Thanh_tien], [ID_Don_vi_tinh], [Da_duyet]) VALUES (6, N'12345611', N'1244', N'', 0, 12, 0, 0, 2, 1)
INSERT [dbo].[Chi_Tiet_Phieu_Nhap_Vat_Tu] ([ID_chi_tiet_phieu_nhap_vat_tu], [Ma_phieu_nhap], [Ma_vat_tu], [Chat_luong], [So_luong_yeu_cau], [So_luong_thuc_lanh], [Don_gia], [Thanh_tien], [ID_Don_vi_tinh], [Da_duyet]) VALUES (7, N'123111', N'12126666', N'', 12, 12, 12, 144, 2, 1)
INSERT [dbo].[Chi_Tiet_Phieu_Nhap_Vat_Tu] ([ID_chi_tiet_phieu_nhap_vat_tu], [Ma_phieu_nhap], [Ma_vat_tu], [Chat_luong], [So_luong_yeu_cau], [So_luong_thuc_lanh], [Don_gia], [Thanh_tien], [ID_Don_vi_tinh], [Da_duyet]) VALUES (29, N'1232d', N'12126666', N'', 1, 20, 0, 0, 2, 1)
INSERT [dbo].[Chi_Tiet_Phieu_Nhap_Vat_Tu] ([ID_chi_tiet_phieu_nhap_vat_tu], [Ma_phieu_nhap], [Ma_vat_tu], [Chat_luong], [So_luong_yeu_cau], [So_luong_thuc_lanh], [Don_gia], [Thanh_tien], [ID_Don_vi_tinh], [Da_duyet]) VALUES (35, N'123', N'31053100', N'', 0, 123, 198000, 24354000, 2, NULL)
INSERT [dbo].[Chi_Tiet_Phieu_Nhap_Vat_Tu] ([ID_chi_tiet_phieu_nhap_vat_tu], [Ma_phieu_nhap], [Ma_vat_tu], [Chat_luong], [So_luong_yeu_cau], [So_luong_thuc_lanh], [Don_gia], [Thanh_tien], [ID_Don_vi_tinh], [Da_duyet]) VALUES (38, N'12332154', N'12126666', N'', 0, 90, 0, 0, 2, NULL)
INSERT [dbo].[Chi_Tiet_Phieu_Nhap_Vat_Tu] ([ID_chi_tiet_phieu_nhap_vat_tu], [Ma_phieu_nhap], [Ma_vat_tu], [Chat_luong], [So_luong_yeu_cau], [So_luong_thuc_lanh], [Don_gia], [Thanh_tien], [ID_Don_vi_tinh], [Da_duyet]) VALUES (39, N'12332154', N'31053100', N'', 0, 9600, 198000, 1900800000, 2, NULL)
INSERT [dbo].[Chi_Tiet_Phieu_Nhap_Vat_Tu] ([ID_chi_tiet_phieu_nhap_vat_tu], [Ma_phieu_nhap], [Ma_vat_tu], [Chat_luong], [So_luong_yeu_cau], [So_luong_thuc_lanh], [Don_gia], [Thanh_tien], [ID_Don_vi_tinh], [Da_duyet]) VALUES (40, N'12332154', N'32053156', N'', 0, 20, 165000, 3300000, 2, NULL)
INSERT [dbo].[Chi_Tiet_Phieu_Nhap_Vat_Tu] ([ID_chi_tiet_phieu_nhap_vat_tu], [Ma_phieu_nhap], [Ma_vat_tu], [Chat_luong], [So_luong_yeu_cau], [So_luong_thuc_lanh], [Don_gia], [Thanh_tien], [ID_Don_vi_tinh], [Da_duyet]) VALUES (41, N'98989', N'31053100', N'', 0, 90, 198000, 17820000, 2, 1)
INSERT [dbo].[Chi_Tiet_Phieu_Nhap_Vat_Tu] ([ID_chi_tiet_phieu_nhap_vat_tu], [Ma_phieu_nhap], [Ma_vat_tu], [Chat_luong], [So_luong_yeu_cau], [So_luong_thuc_lanh], [Don_gia], [Thanh_tien], [ID_Don_vi_tinh], [Da_duyet]) VALUES (42, N'98989', N'32053601', N'', 0, 30, 88000, 2640000, 2, 1)
INSERT [dbo].[Chi_Tiet_Phieu_Nhap_Vat_Tu] ([ID_chi_tiet_phieu_nhap_vat_tu], [Ma_phieu_nhap], [Ma_vat_tu], [Chat_luong], [So_luong_yeu_cau], [So_luong_thuc_lanh], [Don_gia], [Thanh_tien], [ID_Don_vi_tinh], [Da_duyet]) VALUES (43, N'120101001', N'31053100', N'OK', 0, 30, 198000, 5940000, 2, 1)
INSERT [dbo].[Chi_Tiet_Phieu_Nhap_Vat_Tu] ([ID_chi_tiet_phieu_nhap_vat_tu], [Ma_phieu_nhap], [Ma_vat_tu], [Chat_luong], [So_luong_yeu_cau], [So_luong_thuc_lanh], [Don_gia], [Thanh_tien], [ID_Don_vi_tinh], [Da_duyet]) VALUES (44, N'120101001', N'32053601', N'', 0, 6, 88000, 528000, 2, 1)
INSERT [dbo].[Chi_Tiet_Phieu_Nhap_Vat_Tu] ([ID_chi_tiet_phieu_nhap_vat_tu], [Ma_phieu_nhap], [Ma_vat_tu], [Chat_luong], [So_luong_yeu_cau], [So_luong_thuc_lanh], [Don_gia], [Thanh_tien], [ID_Don_vi_tinh], [Da_duyet]) VALUES (46, N'12222', N'31053100', N'', 0, 60, 198000, 11880000, 2, 1)
INSERT [dbo].[Chi_Tiet_Phieu_Nhap_Vat_Tu] ([ID_chi_tiet_phieu_nhap_vat_tu], [Ma_phieu_nhap], [Ma_vat_tu], [Chat_luong], [So_luong_yeu_cau], [So_luong_thuc_lanh], [Don_gia], [Thanh_tien], [ID_Don_vi_tinh], [Da_duyet]) VALUES (47, N'12222', N'32053152', N'', 0, 20, 165000, 3300000, 2, 0)
SET IDENTITY_INSERT [dbo].[Chi_Tiet_Phieu_Nhap_Vat_Tu] OFF
/****** Object:  Table [dbo].[DM_Nhan_Vien]    Script Date: 10/16/2015 15:16:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DM_Nhan_Vien](
	[ID_nhan_vien] [int] IDENTITY(1,1) NOT NULL,
	[Ten_nhan_vien] [nvarchar](50) NULL,
	[Ma_nhan_vien] [varchar](50) NULL,
	[Trang_thai] [bit] NULL,
 CONSTRAINT [PK_Nhan_Vien] PRIMARY KEY CLUSTERED 
(
	[ID_nhan_vien] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[DM_Nhan_Vien] ON
INSERT [dbo].[DM_Nhan_Vien] ([ID_nhan_vien], [Ten_nhan_vien], [Ma_nhan_vien], [Trang_thai]) VALUES (1, N'demo', N'12212', 0)
INSERT [dbo].[DM_Nhan_Vien] ([ID_nhan_vien], [Ten_nhan_vien], [Ma_nhan_vien], [Trang_thai]) VALUES (2, N'nguyễn thằng lol', N'1001113', 0)
SET IDENTITY_INSERT [dbo].[DM_Nhan_Vien] OFF
/****** Object:  Table [dbo].[DM_Kho]    Script Date: 10/16/2015 15:16:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_Kho](
	[ID_kho] [int] IDENTITY(1,1) NOT NULL,
	[Ten_kho] [nvarchar](50) NULL,
	[Trang_thai] [bit] NULL,
 CONSTRAINT [PK_DM_Kho] PRIMARY KEY CLUSTERED 
(
	[ID_kho] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DM_Kho] ON
INSERT [dbo].[DM_Kho] ([ID_kho], [Ten_kho], [Trang_thai]) VALUES (9, N'Kho sữa chữa thường xuyên', NULL)
INSERT [dbo].[DM_Kho] ([ID_kho], [Ten_kho], [Trang_thai]) VALUES (10, N'Kho Sữa chữa khẩn cấp', NULL)
INSERT [dbo].[DM_Kho] ([ID_kho], [Ten_kho], [Trang_thai]) VALUES (11, N'Kho khác', NULL)
INSERT [dbo].[DM_Kho] ([ID_kho], [Ten_kho], [Trang_thai]) VALUES (12, N'Kho vật tư', NULL)
INSERT [dbo].[DM_Kho] ([ID_kho], [Ten_kho], [Trang_thai]) VALUES (13, N'kho demo', NULL)
SET IDENTITY_INSERT [dbo].[DM_Kho] OFF
/****** Object:  Table [dbo].[DM_Don_vi_tinh]    Script Date: 10/16/2015 15:16:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_Don_vi_tinh](
	[ID_Don_vi_tinh] [int] IDENTITY(1,1) NOT NULL,
	[Ten_don_vi_tinh] [nvarchar](50) NULL,
	[Trang_thai] [bit] NULL,
 CONSTRAINT [PK_DM_Don_vi_tinh] PRIMARY KEY CLUSTERED 
(
	[ID_Don_vi_tinh] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DM_Don_vi_tinh] ON
INSERT [dbo].[DM_Don_vi_tinh] ([ID_Don_vi_tinh], [Ten_don_vi_tinh], [Trang_thai]) VALUES (1, N'kg', NULL)
INSERT [dbo].[DM_Don_vi_tinh] ([ID_Don_vi_tinh], [Ten_don_vi_tinh], [Trang_thai]) VALUES (2, N'mm', NULL)
INSERT [dbo].[DM_Don_vi_tinh] ([ID_Don_vi_tinh], [Ten_don_vi_tinh], [Trang_thai]) VALUES (3, N'ddd', NULL)
INSERT [dbo].[DM_Don_vi_tinh] ([ID_Don_vi_tinh], [Ten_don_vi_tinh], [Trang_thai]) VALUES (4, N'm3', NULL)
SET IDENTITY_INSERT [dbo].[DM_Don_vi_tinh] OFF
/****** Object:  Table [dbo].[Loai_Phieu_Nhap]    Script Date: 10/16/2015 15:16:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Loai_Phieu_Nhap](
	[ID_Loai_Phieu_Nhap] [int] IDENTITY(1,1) NOT NULL,
	[Ma_loai_phieu_nhap] [varchar](50) NULL,
	[Ten_loai_phieu_nhap] [nvarchar](50) NULL,
 CONSTRAINT [PK_Loai_Phieu_Nhap] PRIMARY KEY CLUSTERED 
(
	[ID_Loai_Phieu_Nhap] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Loai_Phieu_Nhap] ON
INSERT [dbo].[Loai_Phieu_Nhap] ([ID_Loai_Phieu_Nhap], [Ma_loai_phieu_nhap], [Ten_loai_phieu_nhap]) VALUES (1, N'NA', NULL)
INSERT [dbo].[Loai_Phieu_Nhap] ([ID_Loai_Phieu_Nhap], [Ma_loai_phieu_nhap], [Ten_loai_phieu_nhap]) VALUES (2, N'VN', NULL)
INSERT [dbo].[Loai_Phieu_Nhap] ([ID_Loai_Phieu_Nhap], [Ma_loai_phieu_nhap], [Ten_loai_phieu_nhap]) VALUES (3, N'XD', NULL)
SET IDENTITY_INSERT [dbo].[Loai_Phieu_Nhap] OFF
/****** Object:  Table [dbo].[Ky]    Script Date: 10/16/2015 15:16:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ky](
	[ID_ky] [int] IDENTITY(1,1) NOT NULL,
	[Ten_ky] [nvarchar](50) NULL,
	[Thoi_gian_bat_dau] [datetime] NULL,
	[Thoi_gian_ket_thuc] [datetime] NULL,
 CONSTRAINT [PK_Ky] PRIMARY KEY CLUSTERED 
(
	[ID_ky] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vat_Tu_Goi_Dau_Ky]    Script Date: 10/16/2015 15:16:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vat_Tu_Goi_Dau_Ky](
	[ID_VT_Goi_Dau] [int] IDENTITY(1,1) NOT NULL,
	[Ma_vat_tu] [varchar](50) NULL,
	[So_Luong] [int] NULL,
	[ID_ky] [int] NULL,
 CONSTRAINT [PK_Vat_Tu_Goi_Dau_Ky] PRIMARY KEY CLUSTERED 
(
	[ID_VT_Goi_Dau] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ton_kho]    Script Date: 10/16/2015 15:16:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ton_kho](
	[ID_ton_kho] [int] IDENTITY(1,1) NOT NULL,
	[ID_kho] [int] NULL,
	[Ma_vat_tu] [varchar](50) NULL,
	[So_luong] [int] NULL,
 CONSTRAINT [PK_Ton_Dau_Ky] PRIMARY KEY CLUSTERED 
(
	[ID_ton_kho] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Ton_kho] ON
INSERT [dbo].[Ton_kho] ([ID_ton_kho], [ID_kho], [Ma_vat_tu], [So_luong]) VALUES (2, 9, N'12126666', 242)
INSERT [dbo].[Ton_kho] ([ID_ton_kho], [ID_kho], [Ma_vat_tu], [So_luong]) VALUES (3, 9, N'31086425', 0)
INSERT [dbo].[Ton_kho] ([ID_ton_kho], [ID_kho], [Ma_vat_tu], [So_luong]) VALUES (4, 9, N'1244', 12)
INSERT [dbo].[Ton_kho] ([ID_ton_kho], [ID_kho], [Ma_vat_tu], [So_luong]) VALUES (5, 10, N'12126666', 20)
INSERT [dbo].[Ton_kho] ([ID_ton_kho], [ID_kho], [Ma_vat_tu], [So_luong]) VALUES (6, 13, N'31053100', 120)
INSERT [dbo].[Ton_kho] ([ID_ton_kho], [ID_kho], [Ma_vat_tu], [So_luong]) VALUES (7, 11, N'32053601', 6)
INSERT [dbo].[Ton_kho] ([ID_ton_kho], [ID_kho], [Ma_vat_tu], [So_luong]) VALUES (8, 13, N'32053601', 30)
INSERT [dbo].[Ton_kho] ([ID_ton_kho], [ID_kho], [Ma_vat_tu], [So_luong]) VALUES (9, 9, N'31053100', 60)
SET IDENTITY_INSERT [dbo].[Ton_kho] OFF
/****** Object:  Table [dbo].[Phieu_Xuat_Tam_Vat_Tu]    Script Date: 10/16/2015 15:16:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Phieu_Xuat_Tam_Vat_Tu](
	[Ma_phieu_xuat_tam] [varchar](50) NOT NULL,
	[ID_nhan_vien] [int] NULL,
	[Ngay_xuat] [datetime] NULL,
	[ID_kho] [int] NULL,
	[Ly_do] [nvarchar](50) NULL,
	[Cong_trinh] [nvarchar](50) NULL,
	[Dia_chi] [nvarchar](50) NULL,
	[ID_phieu_xuat_tam] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Phieu_Xuat_Tam_Vat_Tu_1] PRIMARY KEY CLUSTERED 
(
	[ID_phieu_xuat_tam] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Phieu_Nhap_Kho]    Script Date: 10/16/2015 15:16:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Phieu_Nhap_Kho](
	[Ma_phieu_nhap] [varchar](50) NOT NULL,
	[Kho_nhan] [nvarchar](50) NULL,
	[Ngay_lap] [datetime] NULL,
	[Ly_do] [nvarchar](50) NULL,
	[So_hoa_don] [nchar](10) NULL,
	[Cong_trinh] [nvarchar](50) NULL,
	[Dia_Chi] [nvarchar](50) NULL,
	[ID_Loai_Phieu_Nhap] [int] NULL,
	[Kho_xuat_ra] [nvarchar](50) NULL,
	[Da_phan_kho] [bit] NULL,
	[ID_phieu_nhap] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Phieu_Nhap_Kho] PRIMARY KEY CLUSTERED 
(
	[ID_phieu_nhap] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Phieu_Nhap_Kho] ON
INSERT [dbo].[Phieu_Nhap_Kho] ([Ma_phieu_nhap], [Kho_nhan], [Ngay_lap], [Ly_do], [So_hoa_don], [Cong_trinh], [Dia_Chi], [ID_Loai_Phieu_Nhap], [Kho_xuat_ra], [Da_phan_kho], [ID_phieu_nhap]) VALUES (N'12222', NULL, CAST(0x0000A53000C59F04 AS DateTime), N'', N'          ', N'', N'', 1, NULL, 1, 4)
INSERT [dbo].[Phieu_Nhap_Kho] ([Ma_phieu_nhap], [Kho_nhan], [Ngay_lap], [Ly_do], [So_hoa_don], [Cong_trinh], [Dia_Chi], [ID_Loai_Phieu_Nhap], [Kho_xuat_ra], [Da_phan_kho], [ID_phieu_nhap]) VALUES (N'23112', N'', CAST(0x0000A53000F26E8E AS DateTime), N'', NULL, N'', N'', 1, N'', 0, 10)
INSERT [dbo].[Phieu_Nhap_Kho] ([Ma_phieu_nhap], [Kho_nhan], [Ngay_lap], [Ly_do], [So_hoa_don], [Cong_trinh], [Dia_Chi], [ID_Loai_Phieu_Nhap], [Kho_xuat_ra], [Da_phan_kho], [ID_phieu_nhap]) VALUES (N'12345611', N'', CAST(0x0000A53000FCD7C9 AS DateTime), N'', NULL, N'', N'', 1, N'', 0, 15)
INSERT [dbo].[Phieu_Nhap_Kho] ([Ma_phieu_nhap], [Kho_nhan], [Ngay_lap], [Ly_do], [So_hoa_don], [Cong_trinh], [Dia_Chi], [ID_Loai_Phieu_Nhap], [Kho_xuat_ra], [Da_phan_kho], [ID_phieu_nhap]) VALUES (N'123111', N'', CAST(0x0000A53000FCD758 AS DateTime), N'', NULL, N'', N'', 1, N'', 0, 16)
INSERT [dbo].[Phieu_Nhap_Kho] ([Ma_phieu_nhap], [Kho_nhan], [Ngay_lap], [Ly_do], [So_hoa_don], [Cong_trinh], [Dia_Chi], [ID_Loai_Phieu_Nhap], [Kho_xuat_ra], [Da_phan_kho], [ID_phieu_nhap]) VALUES (N'123321', NULL, CAST(0x0000A53000FE7D38 AS DateTime), N'', N'          ', N'', N'', 1, NULL, 0, 17)
INSERT [dbo].[Phieu_Nhap_Kho] ([Ma_phieu_nhap], [Kho_nhan], [Ngay_lap], [Ly_do], [So_hoa_don], [Cong_trinh], [Dia_Chi], [ID_Loai_Phieu_Nhap], [Kho_xuat_ra], [Da_phan_kho], [ID_phieu_nhap]) VALUES (N'123456', N'', CAST(0x0000A53001069468 AS DateTime), N'', NULL, N'', N'', 1, N'', 0, 19)
INSERT [dbo].[Phieu_Nhap_Kho] ([Ma_phieu_nhap], [Kho_nhan], [Ngay_lap], [Ly_do], [So_hoa_don], [Cong_trinh], [Dia_Chi], [ID_Loai_Phieu_Nhap], [Kho_xuat_ra], [Da_phan_kho], [ID_phieu_nhap]) VALUES (N'1232d', N'', CAST(0x0000A53001761FEA AS DateTime), N'', NULL, N'', N'', 1, N'', 0, 20)
INSERT [dbo].[Phieu_Nhap_Kho] ([Ma_phieu_nhap], [Kho_nhan], [Ngay_lap], [Ly_do], [So_hoa_don], [Cong_trinh], [Dia_Chi], [ID_Loai_Phieu_Nhap], [Kho_xuat_ra], [Da_phan_kho], [ID_phieu_nhap]) VALUES (N'123', N'', CAST(0x0000A53200E3DAAB AS DateTime), N'', NULL, N'', N'', 3, N'', 0, 21)
INSERT [dbo].[Phieu_Nhap_Kho] ([Ma_phieu_nhap], [Kho_nhan], [Ngay_lap], [Ly_do], [So_hoa_don], [Cong_trinh], [Dia_Chi], [ID_Loai_Phieu_Nhap], [Kho_xuat_ra], [Da_phan_kho], [ID_phieu_nhap]) VALUES (N'12332154', N'Kho nhận', CAST(0x0000A53201430BB8 AS DateTime), N'lý do', NULL, N'công trình', N'địa chỉ', 1, N'xuất tại kho', 0, 23)
INSERT [dbo].[Phieu_Nhap_Kho] ([Ma_phieu_nhap], [Kho_nhan], [Ngay_lap], [Ly_do], [So_hoa_don], [Cong_trinh], [Dia_Chi], [ID_Loai_Phieu_Nhap], [Kho_xuat_ra], [Da_phan_kho], [ID_phieu_nhap]) VALUES (N'98989', N'tại kho', CAST(0x0000A5320143D5E2 AS DateTime), N'lý do ', NULL, N'ct', N'dc', 1, N'kho 1 ', 0, 24)
INSERT [dbo].[Phieu_Nhap_Kho] ([Ma_phieu_nhap], [Kho_nhan], [Ngay_lap], [Ly_do], [So_hoa_don], [Cong_trinh], [Dia_Chi], [ID_Loai_Phieu_Nhap], [Kho_xuat_ra], [Da_phan_kho], [ID_phieu_nhap]) VALUES (N'120101001', N'demo', CAST(0x0000A53201488A56 AS DateTime), N'', NULL, N'', N'', 1, N'xuất tại kho 1', 0, 25)
INSERT [dbo].[Phieu_Nhap_Kho] ([Ma_phieu_nhap], [Kho_nhan], [Ngay_lap], [Ly_do], [So_hoa_don], [Cong_trinh], [Dia_Chi], [ID_Loai_Phieu_Nhap], [Kho_xuat_ra], [Da_phan_kho], [ID_phieu_nhap]) VALUES (N'101201', N'', CAST(0x0000A53201523380 AS DateTime), N'', NULL, N'', N'', 1, N'', 0, 26)
SET IDENTITY_INSERT [dbo].[Phieu_Nhap_Kho] OFF
/****** Object:  Table [dbo].[No_vat_tu]    Script Date: 10/16/2015 15:16:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[No_vat_tu](
	[ID_No_vat_tu] [int] NOT NULL,
	[ID_nhan_vien] [int] NULL,
	[Ma_phieu_xuat_tam] [varchar](50) NULL,
	[Ma_vat_tu] [varchar](50) NULL,
	[So_luong_giu_lai] [int] NULL,
	[Da_tra] [bit] NULL,
 CONSTRAINT [PK_No_vat_tu] PRIMARY KEY CLUSTERED 
(
	[ID_No_vat_tu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Kho_muon_vat_tu]    Script Date: 10/16/2015 15:16:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Kho_muon_vat_tu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Kho] [int] NULL,
	[ID_Kho_muon] [int] NULL,
	[Ma_vat_tu] [varchar](50) NULL,
	[So_luong] [int] NULL,
	[Ma_phieu_xuat_tam] [varchar](50) NULL,
 CONSTRAINT [PK_Kho_muon_vat_tu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DM_Vat_Tu]    Script Date: 10/16/2015 15:16:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DM_Vat_Tu](
	[Ten_vat_tu] [nvarchar](50) NULL,
	[Ma_vat_tu] [varchar](50) NOT NULL,
	[ID_Don_vi_tinh] [int] NULL,
	[Mo_ta] [nvarchar](50) NULL,
	[Trang_thai] [bit] NULL,
	[Don_gia] [bigint] NULL,
	[Da_xuat] [bit] NULL,
	[ID_Vat_tu] [int] IDENTITY(1,1) NOT NULL,
	[Ten_khong_dau] [nvarchar](50) NULL,
 CONSTRAINT [PK_DM_Vat_Tu] PRIMARY KEY CLUSTERED 
(
	[ID_Vat_tu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[DM_Vat_Tu] ON
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'1212', N'12126666', 2, N'', NULL, 0, NULL, 1, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'vat tu 0011', N'1244', 2, NULL, NULL, NULL, NULL, 3, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Ten_vat_tu', N'Ma_vat_tu', NULL, N'Mo_ta', NULL, NULL, NULL, 4, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Hóa chất phá sét rp7', N'18200001', 1, N'Hóa chất phá sét rp7', 1, 80000, NULL, 6, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Sứ thanh cái 24kv + kẹp', N'31053100', 2, N'Sứ thanh cái 24kv + kẹp', 1, 198000, NULL, 57, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Sứ đứng 24kv+ty', N'31086425', 2, N'Sứ đứng 24kv+ty', 1, 236000, NULL, 59, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Giáp níu cho cáp al ac trần 50/8mm2', N'32053152', 2, N'Giáp níu cho cáp al ac trần 50/8mm2', 1, 165000, NULL, 144, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Giáp níu cho cáp al ac trần 95/16mm2', N'32053156', 2, N'Giáp níu cho cáp al ac trần 95/16mm2', 1, 165000, NULL, 145, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'giáp níu cáp thép 70mm2', N'32053601', 2, N'giáp níu cáp thép 70mm2', 1, 88000, NULL, 146, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Bô tiếp địa nhà ở dưới ĐD 15KV', N'32074100', 2, N'Bô tiếp địa nhà ở dưới ĐD 15KV', 1, 130000, NULL, 158, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Cọc + kẹp tiếp địa đk 16*2400', N'32074224', 2, N'Cọc + kẹp tiếp địa đk 16*2400', 1, 131500, NULL, 159, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Đai thép không rỉ 20*0,7*1000mm & khóa đai', N'32094758', 2, N'Đai thép không rỉ 20*0,7*1000mm & khóa đai', 1, 15500, NULL, 183, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Hộp đầu cáp (nhựa) 24KV 3*50mm2 OD', N'32573051', 2, N'Hộp đầu cáp (nhựa) 24KV 3*50mm2 OD', 1, 3500000, NULL, 195, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Hộp đầu cáp (nhựa) 24KV 3*50mm2 ID', N'32573052', 2, N'Hộp đầu cáp (nhựa) 24KV 3*50mm2 ID', 1, 3300000, NULL, 196, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Hộp đầu cáp (nhựa) 24KV 3*95mm2 OD', N'32573095', 2, N'Hộp đầu cáp (nhựa) 24KV 3*95mm2 OD', 1, 4000000, NULL, 197, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'FCO 24KV 100A (thân Polymer)', N'33087338', 2, N'FCO 24KV 100A (thân Polymer)', 1, 945900, NULL, 219, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'LBFCO 22kV 200A (thân polymer)', N'33087452', 2, N'LBFCO 22kV 200A (thân polymer)', 1, 1377500, NULL, 220, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Thùng cầu dao composite 1250*600*500', N'33897233', 2, N'Thùng cầu dao composite 1250*600*500', 1, 3430000, NULL, 236, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Thùng composite 1250*600*500 (bảo vệ CB)', N'33897234', 2, N'Thùng composite 1250*600*500 (bảo vệ CB)', 1, 6800000, NULL, 237, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Cầu dao cách ly 3p 24kv 630a + bệ chì', N'34206263', 2, N'Cầu dao cách ly 3p 24kv 630a + bệ chì', 1, 16147100, NULL, 242, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Dao cách ly 3p 24kv 630a id', N'34206271', 2, N'Dao cách ly 3p 24kv 630a id', 1, 7090000, NULL, 243, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Dao cách ly 3p 24kv 630a od', N'34206270', 2, N'Dao cách ly 3p 24kv 630a od', 1, 10230000, NULL, 244, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'LBS 3P 24kv 630A O.D (SF6)', N'34224404', 2, N'LBS 3P 24kv 630A O.D (SF6)', 1, 46000000, NULL, 245, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Recloser 24kV 3P 630A + phụ kiện', N'34279962', 2, N'Recloser 24kV 3P 630A + phụ kiện', 1, 220267000, NULL, 246, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'La 18 KV 10KA', N'34482180', 2, N'La 18 KV 10KA', 1, 796000, NULL, 248, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Hộp domino đầu trụ 6 cực', N'36005006', 2, N'Hộp domino đầu trụ 6 cực', 1, 670000, NULL, 261, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Hộp domino đầu trụ 9 cực', N'36005009', 2, N'Hộp domino đầu trụ 9 cực', 1, 770000, NULL, 262, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Vỏ tủ phân phối hạ thế composite 1150*600*400', N'36005050', 2, N'Vỏ tủ phân phối hạ thế composite 1150*600*400', 1, 3200000, NULL, 263, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Th bảo vệ đk composite 500*300*200mm', N'36295352', 2, N'Th bảo vệ đk composite 500*300*200mm', 1, 950000, NULL, 264, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Hộp bảo vệ điện kế 1 pha (cơ) OD', N'36390029', 2, N'Hộp bảo vệ điện kế 1 pha (cơ) OD', 1, 95000, NULL, 267, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Hộp bảo vệ điện kế 1 pha (OD) có gắn CB', N'36390048', 2, N'Hộp bảo vệ điện kế 1 pha (OD) có gắn CB', 1, 155000, NULL, 269, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Hộp bảo vệ công tơ 3 pha (OD) có gắn CB', N'36390058', 2, N'Hộp bảo vệ công tơ 3 pha (OD) có gắn CB', 1, 440000, NULL, 270, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Nắp đậy + đế (bảo vệ CB 4 cực 50-100A)', N'36390064', 2, N'Nắp đậy + đế (bảo vệ CB 4 cực 50-100A)', 1, 15120, NULL, 271, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Nắp đậy + đế (bảo vệ CB 2 cực 40A)', N'36390065', 2, N'Nắp đậy + đế (bảo vệ CB 2 cực 40A)', 1, 9000, NULL, 272, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Bộ tụ bù 3p h.thế 20kvar', N'36404021', 2, N'Bộ tụ bù 3p h.thế 20kvar', 1, 2950000, NULL, 278, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'Bộ tụ bù 3p h.thế 30kvar', N'36404031', 2, N'Bộ tụ bù 3p h.thế 30kvar', 1, 3300000, NULL, 280, NULL)
INSERT [dbo].[DM_Vat_Tu] ([Ten_vat_tu], [Ma_vat_tu], [ID_Don_vi_tinh], [Mo_ta], [Trang_thai], [Don_gia], [Da_xuat], [ID_Vat_tu], [Ten_khong_dau]) VALUES (N'vật tư demo', N'100111', 1, N'mô tả', NULL, NULL, NULL, 389, NULL)
SET IDENTITY_INSERT [dbo].[DM_Vat_Tu] OFF
/****** Object:  Table [dbo].[Chi_Tiet_Ton_Kho]    Script Date: 10/16/2015 15:16:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Chi_Tiet_Ton_Kho](
	[ID_Chi_tiet_ton_kho] [int] IDENTITY(1,1) NOT NULL,
	[ID_Ton_kho] [int] NULL,
	[Ma_phieu] [varchar](50) NULL,
	[So_luong] [int] NULL,
	[Ngay_thay_doi] [datetime] NULL,
	[Tang_Giam] [bit] NULL,
 CONSTRAINT [PK_Chi_Tiet_Ton_Kho] PRIMARY KEY CLUSTERED 
(
	[ID_Chi_tiet_ton_kho] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Track thay dổi (tăng giảm của các kho)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Chi_Tiet_Ton_Kho'
GO
SET IDENTITY_INSERT [dbo].[Chi_Tiet_Ton_Kho] ON
INSERT [dbo].[Chi_Tiet_Ton_Kho] ([ID_Chi_tiet_ton_kho], [ID_Ton_kho], [Ma_phieu], [So_luong], [Ngay_thay_doi], [Tang_Giam]) VALUES (1, 2, N'123111', 12, CAST(0x0000A531011F9F7A AS DateTime), 1)
INSERT [dbo].[Chi_Tiet_Ton_Kho] ([ID_Chi_tiet_ton_kho], [ID_Ton_kho], [Ma_phieu], [So_luong], [Ngay_thay_doi], [Tang_Giam]) VALUES (2, 3, N'2123', 0, CAST(0x0000A5310165294E AS DateTime), 1)
INSERT [dbo].[Chi_Tiet_Ton_Kho] ([ID_Chi_tiet_ton_kho], [ID_Ton_kho], [Ma_phieu], [So_luong], [Ngay_thay_doi], [Tang_Giam]) VALUES (3, 4, N'12345611', 12, CAST(0x0000A5310166A65F AS DateTime), 1)
INSERT [dbo].[Chi_Tiet_Ton_Kho] ([ID_Chi_tiet_ton_kho], [ID_Ton_kho], [Ma_phieu], [So_luong], [Ngay_thay_doi], [Tang_Giam]) VALUES (4, 2, N'2123', 242, CAST(0x0000A5310178A60C AS DateTime), 1)
INSERT [dbo].[Chi_Tiet_Ton_Kho] ([ID_Chi_tiet_ton_kho], [ID_Ton_kho], [Ma_phieu], [So_luong], [Ngay_thay_doi], [Tang_Giam]) VALUES (5, 5, N'1232d', 20, CAST(0x0000A5310179EAC7 AS DateTime), 1)
INSERT [dbo].[Chi_Tiet_Ton_Kho] ([ID_Chi_tiet_ton_kho], [ID_Ton_kho], [Ma_phieu], [So_luong], [Ngay_thay_doi], [Tang_Giam]) VALUES (6, 6, N'120101001', 30, CAST(0x0000A53201495677 AS DateTime), 1)
INSERT [dbo].[Chi_Tiet_Ton_Kho] ([ID_Chi_tiet_ton_kho], [ID_Ton_kho], [Ma_phieu], [So_luong], [Ngay_thay_doi], [Tang_Giam]) VALUES (7, 7, N'120101001', 6, CAST(0x0000A53201499BED AS DateTime), 1)
INSERT [dbo].[Chi_Tiet_Ton_Kho] ([ID_Chi_tiet_ton_kho], [ID_Ton_kho], [Ma_phieu], [So_luong], [Ngay_thay_doi], [Tang_Giam]) VALUES (8, 6, N'98989', 120, CAST(0x0000A532014A7B3A AS DateTime), 1)
INSERT [dbo].[Chi_Tiet_Ton_Kho] ([ID_Chi_tiet_ton_kho], [ID_Ton_kho], [Ma_phieu], [So_luong], [Ngay_thay_doi], [Tang_Giam]) VALUES (9, 8, N'98989', 30, CAST(0x0000A532014B6B80 AS DateTime), 1)
INSERT [dbo].[Chi_Tiet_Ton_Kho] ([ID_Chi_tiet_ton_kho], [ID_Ton_kho], [Ma_phieu], [So_luong], [Ngay_thay_doi], [Tang_Giam]) VALUES (10, 9, N'12222', 60, CAST(0x0000A532015559D3 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Chi_Tiet_Ton_Kho] OFF
/****** Object:  ForeignKey [FK_Vat_Tu_Goi_Dau_Ky_Ky]    Script Date: 10/16/2015 15:16:14 ******/
ALTER TABLE [dbo].[Vat_Tu_Goi_Dau_Ky]  WITH CHECK ADD  CONSTRAINT [FK_Vat_Tu_Goi_Dau_Ky_Ky] FOREIGN KEY([ID_ky])
REFERENCES [dbo].[Ky] ([ID_ky])
GO
ALTER TABLE [dbo].[Vat_Tu_Goi_Dau_Ky] CHECK CONSTRAINT [FK_Vat_Tu_Goi_Dau_Ky_Ky]
GO
/****** Object:  ForeignKey [FK_Ton_Dau_Ky_DM_Kho]    Script Date: 10/16/2015 15:16:14 ******/
ALTER TABLE [dbo].[Ton_kho]  WITH CHECK ADD  CONSTRAINT [FK_Ton_Dau_Ky_DM_Kho] FOREIGN KEY([ID_kho])
REFERENCES [dbo].[DM_Kho] ([ID_kho])
GO
ALTER TABLE [dbo].[Ton_kho] CHECK CONSTRAINT [FK_Ton_Dau_Ky_DM_Kho]
GO
/****** Object:  ForeignKey [FK_Phieu_Xuat_Tam_Vat_Tu_DM_Kho]    Script Date: 10/16/2015 15:16:14 ******/
ALTER TABLE [dbo].[Phieu_Xuat_Tam_Vat_Tu]  WITH CHECK ADD  CONSTRAINT [FK_Phieu_Xuat_Tam_Vat_Tu_DM_Kho] FOREIGN KEY([ID_kho])
REFERENCES [dbo].[DM_Kho] ([ID_kho])
GO
ALTER TABLE [dbo].[Phieu_Xuat_Tam_Vat_Tu] CHECK CONSTRAINT [FK_Phieu_Xuat_Tam_Vat_Tu_DM_Kho]
GO
/****** Object:  ForeignKey [FK_Phieu_Xuat_Tam_Vat_Tu_DM_Nhan_Vien]    Script Date: 10/16/2015 15:16:14 ******/
ALTER TABLE [dbo].[Phieu_Xuat_Tam_Vat_Tu]  WITH CHECK ADD  CONSTRAINT [FK_Phieu_Xuat_Tam_Vat_Tu_DM_Nhan_Vien] FOREIGN KEY([ID_nhan_vien])
REFERENCES [dbo].[DM_Nhan_Vien] ([ID_nhan_vien])
GO
ALTER TABLE [dbo].[Phieu_Xuat_Tam_Vat_Tu] CHECK CONSTRAINT [FK_Phieu_Xuat_Tam_Vat_Tu_DM_Nhan_Vien]
GO
/****** Object:  ForeignKey [FK_Phieu_Nhap_Kho_Loai_Phieu_Nhap]    Script Date: 10/16/2015 15:16:14 ******/
ALTER TABLE [dbo].[Phieu_Nhap_Kho]  WITH CHECK ADD  CONSTRAINT [FK_Phieu_Nhap_Kho_Loai_Phieu_Nhap] FOREIGN KEY([ID_Loai_Phieu_Nhap])
REFERENCES [dbo].[Loai_Phieu_Nhap] ([ID_Loai_Phieu_Nhap])
GO
ALTER TABLE [dbo].[Phieu_Nhap_Kho] CHECK CONSTRAINT [FK_Phieu_Nhap_Kho_Loai_Phieu_Nhap]
GO
/****** Object:  ForeignKey [FK_No_vat_tu_DM_Nhan_Vien]    Script Date: 10/16/2015 15:16:14 ******/
ALTER TABLE [dbo].[No_vat_tu]  WITH CHECK ADD  CONSTRAINT [FK_No_vat_tu_DM_Nhan_Vien] FOREIGN KEY([ID_nhan_vien])
REFERENCES [dbo].[DM_Nhan_Vien] ([ID_nhan_vien])
GO
ALTER TABLE [dbo].[No_vat_tu] CHECK CONSTRAINT [FK_No_vat_tu_DM_Nhan_Vien]
GO
/****** Object:  ForeignKey [FK_Kho_muon_vat_tu_DM_Kho]    Script Date: 10/16/2015 15:16:14 ******/
ALTER TABLE [dbo].[Kho_muon_vat_tu]  WITH CHECK ADD  CONSTRAINT [FK_Kho_muon_vat_tu_DM_Kho] FOREIGN KEY([ID_Kho])
REFERENCES [dbo].[DM_Kho] ([ID_kho])
GO
ALTER TABLE [dbo].[Kho_muon_vat_tu] CHECK CONSTRAINT [FK_Kho_muon_vat_tu_DM_Kho]
GO
/****** Object:  ForeignKey [FK_Kho_muon_vat_tu_DM_Kho1]    Script Date: 10/16/2015 15:16:14 ******/
ALTER TABLE [dbo].[Kho_muon_vat_tu]  WITH CHECK ADD  CONSTRAINT [FK_Kho_muon_vat_tu_DM_Kho1] FOREIGN KEY([ID_Kho_muon])
REFERENCES [dbo].[DM_Kho] ([ID_kho])
GO
ALTER TABLE [dbo].[Kho_muon_vat_tu] CHECK CONSTRAINT [FK_Kho_muon_vat_tu_DM_Kho1]
GO
/****** Object:  ForeignKey [FK_DM_Vat_Tu_DM_Don_vi_tinh]    Script Date: 10/16/2015 15:16:14 ******/
ALTER TABLE [dbo].[DM_Vat_Tu]  WITH CHECK ADD  CONSTRAINT [FK_DM_Vat_Tu_DM_Don_vi_tinh] FOREIGN KEY([ID_Don_vi_tinh])
REFERENCES [dbo].[DM_Don_vi_tinh] ([ID_Don_vi_tinh])
GO
ALTER TABLE [dbo].[DM_Vat_Tu] CHECK CONSTRAINT [FK_DM_Vat_Tu_DM_Don_vi_tinh]
GO
/****** Object:  ForeignKey [FK_Chi_Tiet_Ton_Kho_Ton_kho]    Script Date: 10/16/2015 15:16:14 ******/
ALTER TABLE [dbo].[Chi_Tiet_Ton_Kho]  WITH CHECK ADD  CONSTRAINT [FK_Chi_Tiet_Ton_Kho_Ton_kho] FOREIGN KEY([ID_Ton_kho])
REFERENCES [dbo].[Ton_kho] ([ID_ton_kho])
GO
ALTER TABLE [dbo].[Chi_Tiet_Ton_Kho] CHECK CONSTRAINT [FK_Chi_Tiet_Ton_Kho_Ton_kho]
GO
