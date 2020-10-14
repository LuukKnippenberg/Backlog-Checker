CREATE TABLE [games_genres] (
	id integer NOT NULL,
	game_id integer NOT NULL,
	genre_id integer NOT NULL,
  CONSTRAINT [PK_GAMES_GENRES] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
ALTER TABLE [games_genres] ADD CONSTRAINT [games_genres_fk0] FOREIGN KEY ([game_id]) REFERENCES [games]([id])
ON UPDATE CASCADE
GO

ALTER TABLE [games_genres] CHECK CONSTRAINT [games_genres_fk0]
GO
ALTER TABLE [games_genres] ADD CONSTRAINT [games_genres_fk1] FOREIGN KEY ([genre_id]) REFERENCES [genres]([id])
ON UPDATE CASCADE
GO

ALTER TABLE [games_genres] CHECK CONSTRAINT [games_genres_fk1]