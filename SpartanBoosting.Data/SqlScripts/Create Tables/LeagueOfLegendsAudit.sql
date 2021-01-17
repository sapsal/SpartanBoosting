CREATE TABLE [LeagueOfLegendsAuditModel] (
    [Id] int NOT NULL IDENTITY,
    [UserId] bigint NULL,
    [Action] nvarchar(max) NULL,
    [DateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_LeagueOfLegendsAuditModel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_LeagueOfLegendsAuditModel_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_LeagueOfLegendsAuditModel_UserId] ON [LeagueOfLegendsAuditModel] ([UserId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201029230828_LeagueOfLegendsAudit', N'3.1.7');

GO

