IF EXISTS (SELECT name FROM sys.databases WHERE name = 'S4E-Associados')
BEGIN    
	USE [S4E-Associados]
	SET IDENTITY_INSERT [dbo].[Associados] ON 
	INSERT [dbo].[Associados] ([Id], [Nome], [CPF], [Nascimento]) VALUES (15, N'Associado 1', N'12345678901', CAST(N'1990-01-08T00:00:00.000' AS DateTime))
	INSERT [dbo].[Associados] ([Id], [Nome], [CPF], [Nascimento]) VALUES (16, N'Associado 2', N'98765432101', CAST(N'1985-05-15T00:00:00.000' AS DateTime))
	INSERT [dbo].[Associados] ([Id], [Nome], [CPF], [Nascimento]) VALUES (22, N'Associado 3', N'33333333333', CAST(N'1990-12-14T00:00:00.000' AS DateTime))
	SET IDENTITY_INSERT [dbo].[Associados] OFF
	SET IDENTITY_INSERT [dbo].[Empresas] ON 
	INSERT [dbo].[Empresas] ([Id], [Nome], [CNPJ]) VALUES (1, N'Empresa 1', N'11111111111111')
	INSERT [dbo].[Empresas] ([Id], [Nome], [CNPJ]) VALUES (3, N'Empresa 3', N'33333333333333')
	INSERT [dbo].[Empresas] ([Id], [Nome], [CNPJ]) VALUES (4, N'Empresa 4', N'44444444444444')
	INSERT [dbo].[Empresas] ([Id], [Nome], [CNPJ]) VALUES (5, N'Empresa 5', N'55555555555555')
	INSERT [dbo].[Empresas] ([Id], [Nome], [CNPJ]) VALUES (8, N'Empresa 8', N'88888888888888')
	INSERT [dbo].[Empresas] ([Id], [Nome], [CNPJ]) VALUES (9, N'Empresa 9', N'99999999999999')
	INSERT [dbo].[Empresas] ([Id], [Nome], [CNPJ]) VALUES (10, N'Empresa 10', N'10101010101010')
	SET IDENTITY_INSERT [dbo].[Empresas] OFF
	INSERT [dbo].[AssociadoEmpresa] ([AssociadoId], [EmpresaId]) VALUES (15, 1)
	INSERT [dbo].[AssociadoEmpresa] ([AssociadoId], [EmpresaId]) VALUES (15, 4)
	INSERT [dbo].[AssociadoEmpresa] ([AssociadoId], [EmpresaId]) VALUES (15, 9)
	INSERT [dbo].[AssociadoEmpresa] ([AssociadoId], [EmpresaId]) VALUES (16, 1)
	INSERT [dbo].[AssociadoEmpresa] ([AssociadoId], [EmpresaId]) VALUES (16, 4)
	INSERT [dbo].[AssociadoEmpresa] ([AssociadoId], [EmpresaId]) VALUES (16, 5)
	INSERT [dbo].[AssociadoEmpresa] ([AssociadoId], [EmpresaId]) VALUES (16, 8)
	INSERT [dbo].[AssociadoEmpresa] ([AssociadoId], [EmpresaId]) VALUES (22, 1)
	INSERT [dbo].[AssociadoEmpresa] ([AssociadoId], [EmpresaId]) VALUES (22, 3)
	INSERT [dbo].[AssociadoEmpresa] ([AssociadoId], [EmpresaId]) VALUES (22, 5)
	INSERT [dbo].[AssociadoEmpresa] ([AssociadoId], [EmpresaId]) VALUES (22, 10)
END