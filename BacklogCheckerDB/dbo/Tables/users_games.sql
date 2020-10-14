CREATE TABLE [users_games] (
	id integer NOT NULL,
	game_id integer NOT NULL,
	user_id integer NOT NULL,
	interested smallint NOT NULL,
	completed smallint NOT NULL,
  CONSTRAINT [PK_USERS_GAMES] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
ALTER TABLE [users_games] ADD CONSTRAINT [users_games_fk0] FOREIGN KEY ([game_id]) REFERENCES [games]([id])
ON UPDATE CASCADE
GO

ALTER TABLE [users_games] CHECK CONSTRAINT [users_games_fk0]
GO
ALTER TABLE [users_games] ADD CONSTRAINT [users_games_fk1] FOREIGN KEY ([user_id]) REFERENCES [users]([id])
ON UPDATE CASCADE
GO

ALTER TABLE [users_games] CHECK CONSTRAINT [users_games_fk1]