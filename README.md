# PersonsAPIDoublePartners
Proyecto API para registro de personas
Proyecto Realizado con .NET Core 7
Scripts de base de datos 
---------------------------------------------------------
create database doubleVPartnersTest

use doubleVPartnersTest


create table Tb_User(
	id int primary key identity (1,1),
	Usename varchar(60),
	PasswordUser varbinary(max),
	Created_at datetime
)

create table Tb_Person(
	id int primary key identity (1,1),
	Names varchar(60),
	LasNames varchar(60),
	Identification varchar(60),
	Email varchar(60),
	TypeId varchar(60),
	Created_at datetime,
	ConcactTypeIdIdentity varchar(100),
	ConcactNameLastName varchar(100),
	IdUser int 
	foreign key (IdUser) references Tb_User(id)

)
---------------------------------------------------------
USE [doubleVPartnersTest]
GO
/****** Object:  StoredProcedure [dbo].[sp_Login]    Script Date: 19/07/2024 5:41:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alexander Solano
-- Create date: 2024-07-12
-- Description:	Procedimiento almacenado para iniciar sesion
-- =============================================
CREATE PROCEDURE [dbo].[sp_Login] 
	@Username varchar(60),
	@Password varchar(60)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @existUser int;

	if LEN(@Username) = 0
	begin
		select 'El campo usuario no puede ir vacio' as result
		return
	end

	if LEN(@Password) = 0
	begin
		select 'El campo contraseña no puede ir vacio' as result
		return
	end

	set @existUser = (
		select count(*) as cant from Tb_User u
		inner join Tb_Person p on u.id = p.IdUser
		where u.Usename = @Username and DECRYPTBYPASSPHRASE('DoubleParthners', u.PasswordUser) = @Password 
	)

	if @existUser > 0 
	begin
		select concat('Bienvenido sr/sra usuario: ', @Username) as result
		return
	end
	else
	begin
		select concat('El usuario: ', @Username, ' no existe por favor registrese') as result
		return
	end

END
-----------------------------------------------------------------------------------------------
USE [doubleVPartnersTest]
GO
/****** Object:  StoredProcedure [dbo].[sp_UserRegisterAndListUser]    Script Date: 19/07/2024 5:42:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alexander Solano
-- Create date: 2024-07-12
-- Description:	procedimiento para registrar un usuario
-- =============================================
CREATE PROCEDURE [dbo].[sp_UserRegisterAndListUser]
	-- Add the parameters for the stored procedure here
	@param int,
	@names varchar(60)= null,
	@lastnames varchar(60) = null,
	@identification varchar(60) = null,
	@email varchar(60) = null,
	@typeid varchar(60) = null,
	@username varchar(60) = null,
	@password varchar(60) = null

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if @param = 1 
	begin
		if len(@names) = 0
		begin
			select 'El campo nombres no puede ir vacio' as result
			return
		end
	
		if len(@lastnames) = 0
		begin
			select 'El campo apellidos no puede ir vacio' as result
			return
		end

		if len(@identification) = 0
		begin
			select 'El campo identificacion no puede ir vacio' as result;
			return
		end

		if @typeid = 'Seleccione'
		begin
			select 'Seleccione un tipo de documento correcto por favor' as result;
			return
		end 

		if LEN(@username) = 0
		begin
			select 'El campo usuario es requerido' as result
		end 
		declare @existeIdentificacion int;

		set @existeIdentificacion = (select count(*) as cant from Tb_Person p 
											where p.Identification = @identification)
		if @existeIdentificacion = 1 
		begin
			select 'La identificación que desea ingresar ya se encuentra registrada' as result
			return
		end

		declare @idusuario int;

		insert into Tb_User([Usename], [PasswordUser], Created_at)
		values (@username, ENCRYPTBYPASSPHRASE('DoubleParthners', @password), GETDATE())
		
		set @idusuario = (select  SCOPE_IDENTITY()) 

		insert into Tb_Person(Names, LasNames, Identification, Email, TypeId, Created_at, 
							  ConcactTypeIdIdentity, ConcactNameLastName, IdUser)
		values (@names, @lastnames, @identification, @email, @typeid, GETDATE(), concat(@typeid, '-', @identification), 
				CONCAT(@names, ' ', @lastnames), @idusuario)
		
		select 'Persona registrada con exito' as result
		return
	end
	else 
	begin
		select p.id,p.Names, p.LasNames, 
		p.Identification, p.Email,
		p.ConcactNameLastName, p.ConcactTypeIdIdentity from Tb_Person p 
		inner join Tb_User u on p.IdUser = u.id

	end 

END



--- PARA REGISTRAR UN USUARIO
exec [dbo].[sp_UserRegisterAndListUser] 1, 'Alexander', 'Solano', '2339223', 'alex995352@gmail.com', 'CC', 'Alex','123456'
--- PARA VALIDAR EL LISTADO DE USUARIOS
exec [dbo].[sp_UserRegisterAndListUser] 2
--- PARA LOGUEARSE
exec [dbo].[sp_Login] 'Alex','123456'
