CREATE TABLE [ChatModel] (
    [Id] int NOT NULL IDENTITY,
    [SenderId] bigint NULL,
    [RecieverId] bigint NULL,
    [Message] nvarchar(max) NULL,
    [DateTimeSent] datetime2 NOT NULL,
    [purchaseFormId] int NULL,
    CONSTRAINT [PK_ChatModel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ChatModel_AspNetUsers_RecieverId] FOREIGN KEY ([RecieverId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ChatModel_AspNetUsers_SenderId] FOREIGN KEY ([SenderId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ChatModel_PurchaseForm_purchaseFormId] FOREIGN KEY ([purchaseFormId]) REFERENCES [PurchaseForm] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_ChatModel_RecieverId] ON [ChatModel] ([RecieverId]);

GO

CREATE INDEX [IX_ChatModel_SenderId] ON [ChatModel] ([SenderId]);

GO

CREATE INDEX [IX_ChatModel_purchaseFormId] ON [ChatModel] ([purchaseFormId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201019211604_ChatModelMigration', N'3.1.7');

GO

