USE [master]
GO
/****** Object:  Database [BDVentas]    Script Date: 9/11/2024 22:24:14 ******/
CREATE DATABASE [BDVentas]
go
USE [BDVentas]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 9/11/2024 22:24:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[IdRol] [int] NOT NULL,
	[Rol_Dsc] [varchar](100) NULL,
	[Estado] [bit] NULL,
	[flgEliminado] [bit] NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Rol] ([IdRol], [Rol_Dsc], [Estado], [flgEliminado]) VALUES (1, N'Administrador', 1, 0)
GO
/****** Object:  StoredProcedure [dbo].[usp_venta_Lista]    Script Date: 9/11/2024 22:24:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_venta_Lista](
	@orden int,
	@buscar varchar(100),
	@IdRol int
)

as

if(@orden =1) -- Lista x ID
	begin
		Select
			IdRol,
			Rol_Dsc,
			Estado
		from Rol 
		where IdRol = @IdRol 
	end

if(@orden = 2)
	begin
		Select
			IdRol,
			Rol_Dsc,
			Estado
		from Rol 
		where flgEliminado = 0 and Rol_Dsc like('%'+@buscar+'%')

	end
GO
USE [master]
GO
ALTER DATABASE [BDVentas] SET  READ_WRITE 
GO
