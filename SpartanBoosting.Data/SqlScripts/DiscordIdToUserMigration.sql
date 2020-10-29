GO

ALTER TABLE [AspNetUsers] ADD [DiscordId] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201029223758_AddDiscordId', N'3.1.7');

GO

