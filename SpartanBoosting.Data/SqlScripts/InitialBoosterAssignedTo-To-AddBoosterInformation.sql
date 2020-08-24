ALTER TABLE [PurchaseForm] ADD [BoosterAssignedToId] bigint NULL;

GO

CREATE INDEX [IX_PurchaseForm_BoosterAssignedToId] ON [PurchaseForm] ([BoosterAssignedToId]);

GO

ALTER TABLE [PurchaseForm] ADD CONSTRAINT [FK_PurchaseForm_AspNetUsers_BoosterAssignedToId] FOREIGN KEY ([BoosterAssignedToId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200819222611_InitialBoosterAssignedTo', N'3.1.7');

GO

ALTER TABLE [PurchaseForm] ADD [BoosterCompletionConfirmed] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [PurchaseForm] ADD [BoosterPricing] nvarchar(max) NULL;

GO

ALTER TABLE [PurchaseForm] ADD [CustomerCompletionConfirmed] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [AspNetUsers] ADD [Balance] decimal(18,2) NOT NULL DEFAULT 0.0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200824204616_AddBoosterInformation', N'3.1.7');

GO

