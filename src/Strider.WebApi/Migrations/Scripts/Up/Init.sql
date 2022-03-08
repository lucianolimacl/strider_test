IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [UserProfile] (
    [Id] int NOT NULL IDENTITY,
    [UserName] nvarchar(14) NOT NULL,
    [DateJoined] datetime2 NOT NULL,
    CONSTRAINT [PK_UserProfile] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Post] (
    [Id] int NOT NULL IDENTITY,
    [PostType] int NOT NULL,
    [Description] nvarchar(777) NOT NULL,
    [DateCreated] datetime2 NOT NULL,
    [UserId] int NOT NULL,
    [QuotePostId] int NULL,
    [RepostPostId] int NULL,
    CONSTRAINT [PK_Post] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Post_Post_QuotePostId] FOREIGN KEY ([QuotePostId]) REFERENCES [Post] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Post_Post_RepostPostId] FOREIGN KEY ([RepostPostId]) REFERENCES [Post] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Post_UserProfile_UserId] FOREIGN KEY ([UserId]) REFERENCES [UserProfile] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [UserFollow] (
    [Id] int NOT NULL IDENTITY,
    [UserFollowedId] int NOT NULL,
    [FollowingUserId] int NOT NULL,
    CONSTRAINT [PK_UserFollow] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserFollow_UserProfile_FollowingUserId] FOREIGN KEY ([FollowingUserId]) REFERENCES [UserProfile] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UserFollow_UserProfile_UserFollowedId] FOREIGN KEY ([UserFollowedId]) REFERENCES [UserProfile] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Post_QuotePostId] ON [Post] ([QuotePostId]);
GO

CREATE INDEX [IX_Post_RepostPostId] ON [Post] ([RepostPostId]);
GO

CREATE INDEX [IX_Post_UserId] ON [Post] ([UserId]);
GO

CREATE INDEX [IX_UserFollow_FollowingUserId] ON [UserFollow] ([FollowingUserId]);
GO

CREATE UNIQUE INDEX [IX_UserFollow_UserFollowedId_FollowingUserId] ON [UserFollow] ([UserFollowedId], [FollowingUserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220308211532_init', N'6.0.2');
GO

COMMIT;
GO
