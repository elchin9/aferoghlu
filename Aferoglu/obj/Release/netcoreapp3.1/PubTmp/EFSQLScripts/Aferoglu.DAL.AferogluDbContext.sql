IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE TABLE [About] (
        [Id] int NOT NULL IDENTITY,
        [Description] nvarchar(max) NOT NULL,
        [PhotoURL] nvarchar(max) NULL,
        CONSTRAINT [PK_About] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE TABLE [AferogluHistory] (
        [Id] int NOT NULL IDENTITY,
        [PhotoUrl] nvarchar(max) NULL,
        [Date] nvarchar(max) NOT NULL,
        [Header] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_AferogluHistory] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE TABLE [Category] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [PhotoUrl] nvarchar(max) NULL,
        CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE TABLE [MailBoxes] (
        [Id] int NOT NULL IDENTITY,
        [FullName] nvarchar(100) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [PhoneNumber] nvarchar(max) NOT NULL,
        [TextBody] nvarchar(max) NOT NULL,
        [Time] datetime2 NOT NULL,
        CONSTRAINT [PK_MailBoxes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE TABLE [OurTeam] (
        [Id] int NOT NULL IDENTITY,
        [FullName] nvarchar(max) NOT NULL,
        [Profession] nvarchar(max) NOT NULL,
        [PhotoURL] nvarchar(max) NULL,
        CONSTRAINT [PK_OurTeam] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE TABLE [Sliders] (
        [Id] int NOT NULL IDENTITY,
        [PhotoUrl] nvarchar(max) NULL,
        [Header] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Sliders] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE TABLE [StaticData] (
        [Id] int NOT NULL IDENTITY,
        [Facebook] nvarchar(max) NULL,
        [Instagram] nvarchar(max) NULL,
        [PhoneNumberOne] nvarchar(max) NOT NULL,
        [PhoneNumberTwo] nvarchar(max) NULL,
        [EmailAdress] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [Map] nvarchar(max) NULL,
        [WorkingHours] nvarchar(max) NULL,
        CONSTRAINT [PK_StaticData] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE TABLE [Testimonials] (
        [Id] int NOT NULL IDENTITY,
        [Description] nvarchar(max) NOT NULL,
        [FullName] nvarchar(max) NOT NULL,
        [PhotoURL] nvarchar(max) NULL,
        CONSTRAINT [PK_Testimonials] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE TABLE [Products] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Price] decimal(18,2) NOT NULL,
        [CategoryId] int NOT NULL,
        [IsStock] bit NOT NULL,
        [Description] nvarchar(max) NULL,
        [Maifacturer] nvarchar(max) NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE TABLE [ProductPhotos] (
        [Id] int NOT NULL IDENTITY,
        [PhotoURL] nvarchar(max) NULL,
        [ProductId] int NOT NULL,
        CONSTRAINT [PK_ProductPhotos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProductPhotos_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE INDEX [IX_ProductPhotos_ProductId] ON [ProductPhotos] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201104111824_InitializeDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201104111824_InitializeDb', N'3.1.9');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201107183926_CreateLang')
BEGIN
    CREATE TABLE [Langs] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [Code] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Langs] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201107183926_CreateLang')
BEGIN
    CREATE TABLE [AboutLang] (
        [Id] int NOT NULL IDENTITY,
        [Description] nvarchar(max) NOT NULL,
        [AboutId] int NOT NULL,
        [LangId] int NOT NULL,
        CONSTRAINT [PK_AboutLang] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AboutLang_About_AboutId] FOREIGN KEY ([AboutId]) REFERENCES [About] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AboutLang_Langs_LangId] FOREIGN KEY ([LangId]) REFERENCES [Langs] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201107183926_CreateLang')
BEGIN
    CREATE INDEX [IX_AboutLang_AboutId] ON [AboutLang] ([AboutId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201107183926_CreateLang')
BEGIN
    CREATE INDEX [IX_AboutLang_LangId] ON [AboutLang] ([LangId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201107183926_CreateLang')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201107183926_CreateLang', N'3.1.9');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Testimonials]') AND [c].[name] = N'Description');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Testimonials] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Testimonials] DROP COLUMN [Description];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Testimonials]') AND [c].[name] = N'FullName');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Testimonials] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Testimonials] DROP COLUMN [FullName];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[StaticData]') AND [c].[name] = N'Address');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [StaticData] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [StaticData] DROP COLUMN [Address];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[StaticData]') AND [c].[name] = N'WorkingHours');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [StaticData] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [StaticData] DROP COLUMN [WorkingHours];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Sliders]') AND [c].[name] = N'Description');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Sliders] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Sliders] DROP COLUMN [Description];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Sliders]') AND [c].[name] = N'Header');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Sliders] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Sliders] DROP COLUMN [Header];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'Description');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [Products] DROP COLUMN [Description];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'Maifacturer');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [Products] DROP COLUMN [Maifacturer];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'Name');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [Products] DROP COLUMN [Name];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OurTeam]') AND [c].[name] = N'FullName');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [OurTeam] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [OurTeam] DROP COLUMN [FullName];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OurTeam]') AND [c].[name] = N'Profession');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [OurTeam] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [OurTeam] DROP COLUMN [Profession];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Category]') AND [c].[name] = N'Name');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Category] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [Category] DROP COLUMN [Name];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AferogluHistory]') AND [c].[name] = N'Description');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [AferogluHistory] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [AferogluHistory] DROP COLUMN [Description];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AferogluHistory]') AND [c].[name] = N'Header');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [AferogluHistory] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [AferogluHistory] DROP COLUMN [Header];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[About]') AND [c].[name] = N'Description');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [About] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [About] DROP COLUMN [Description];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    ALTER TABLE [Products] ADD [Size] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE TABLE [AferogluHistoryLangs] (
        [Id] int NOT NULL IDENTITY,
        [Header] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [AferogluHistoryId] int NOT NULL,
        [LangId] int NOT NULL,
        CONSTRAINT [PK_AferogluHistoryLangs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AferogluHistoryLangs_AferogluHistory_AferogluHistoryId] FOREIGN KEY ([AferogluHistoryId]) REFERENCES [AferogluHistory] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AferogluHistoryLangs_Langs_LangId] FOREIGN KEY ([LangId]) REFERENCES [Langs] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE TABLE [CategoryLangs] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [CategoryId] int NOT NULL,
        [LangId] int NOT NULL,
        CONSTRAINT [PK_CategoryLangs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CategoryLangs_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_CategoryLangs_Langs_LangId] FOREIGN KEY ([LangId]) REFERENCES [Langs] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE TABLE [OurTeamLangs] (
        [Id] int NOT NULL IDENTITY,
        [FullName] nvarchar(max) NOT NULL,
        [Profession] nvarchar(max) NOT NULL,
        [OurTeamId] int NOT NULL,
        [LangId] int NOT NULL,
        CONSTRAINT [PK_OurTeamLangs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_OurTeamLangs_Langs_LangId] FOREIGN KEY ([LangId]) REFERENCES [Langs] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_OurTeamLangs_OurTeam_OurTeamId] FOREIGN KEY ([OurTeamId]) REFERENCES [OurTeam] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE TABLE [ProductLangs] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Maifacturer] nvarchar(max) NOT NULL,
        [ProductId] int NOT NULL,
        [LangId] int NOT NULL,
        CONSTRAINT [PK_ProductLangs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProductLangs_Langs_LangId] FOREIGN KEY ([LangId]) REFERENCES [Langs] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ProductLangs_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE TABLE [SliderLangs] (
        [Id] int NOT NULL IDENTITY,
        [Header] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [SliderId] int NOT NULL,
        [LangId] int NOT NULL,
        CONSTRAINT [PK_SliderLangs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SliderLangs_Langs_LangId] FOREIGN KEY ([LangId]) REFERENCES [Langs] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_SliderLangs_Sliders_SliderId] FOREIGN KEY ([SliderId]) REFERENCES [Sliders] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE TABLE [StaticDataLangs] (
        [Id] int NOT NULL IDENTITY,
        [Address] nvarchar(max) NOT NULL,
        [WorkingHours] nvarchar(max) NULL,
        [StaticDataId] int NOT NULL,
        [LangId] int NOT NULL,
        CONSTRAINT [PK_StaticDataLangs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_StaticDataLangs_Langs_LangId] FOREIGN KEY ([LangId]) REFERENCES [Langs] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_StaticDataLangs_StaticData_StaticDataId] FOREIGN KEY ([StaticDataId]) REFERENCES [StaticData] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE TABLE [TestimonialsLangs] (
        [Id] int NOT NULL IDENTITY,
        [Description] nvarchar(max) NOT NULL,
        [FullName] nvarchar(max) NOT NULL,
        [TestimonialsId] int NOT NULL,
        [LangId] int NOT NULL,
        CONSTRAINT [PK_TestimonialsLangs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_TestimonialsLangs_Langs_LangId] FOREIGN KEY ([LangId]) REFERENCES [Langs] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_TestimonialsLangs_Testimonials_TestimonialsId] FOREIGN KEY ([TestimonialsId]) REFERENCES [Testimonials] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE INDEX [IX_AferogluHistoryLangs_AferogluHistoryId] ON [AferogluHistoryLangs] ([AferogluHistoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE INDEX [IX_AferogluHistoryLangs_LangId] ON [AferogluHistoryLangs] ([LangId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE INDEX [IX_CategoryLangs_CategoryId] ON [CategoryLangs] ([CategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE INDEX [IX_CategoryLangs_LangId] ON [CategoryLangs] ([LangId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE INDEX [IX_OurTeamLangs_LangId] ON [OurTeamLangs] ([LangId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE INDEX [IX_OurTeamLangs_OurTeamId] ON [OurTeamLangs] ([OurTeamId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE INDEX [IX_ProductLangs_LangId] ON [ProductLangs] ([LangId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE INDEX [IX_ProductLangs_ProductId] ON [ProductLangs] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE INDEX [IX_SliderLangs_LangId] ON [SliderLangs] ([LangId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE INDEX [IX_SliderLangs_SliderId] ON [SliderLangs] ([SliderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE INDEX [IX_StaticDataLangs_LangId] ON [StaticDataLangs] ([LangId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE INDEX [IX_StaticDataLangs_StaticDataId] ON [StaticDataLangs] ([StaticDataId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE INDEX [IX_TestimonialsLangs_LangId] ON [TestimonialsLangs] ([LangId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    CREATE INDEX [IX_TestimonialsLangs_TestimonialsId] ON [TestimonialsLangs] ([TestimonialsId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201109100723_EditAllTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201109100723_EditAllTables', N'3.1.9');
END;

GO

