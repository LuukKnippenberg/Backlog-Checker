CREATE TABLE [games_achievements] (
	id integer NOT NULL,
	game_id integer NOT NULL,
	achievement_i integer NOT NULL,
  CONSTRAINT [PK_GAMES_ACHIEVEMENTS] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
ALTER TABLE [games_achievements] ADD CONSTRAINT [games_achievements_fk0] FOREIGN KEY ([game_id]) REFERENCES [games]([id])
ON UPDATE CASCADE
GO

ALTER TABLE [games_achievements] CHECK CONSTRAINT [games_achievements_fk0]
GO
ALTER TABLE [games_achievements] ADD CONSTRAINT [games_achievements_fk1] FOREIGN KEY ([achievement_i]) REFERENCES [achievements]([id])
ON UPDATE CASCADE
GO

ALTER TABLE [games_achievements] CHECK CONSTRAINT [games_achievements_fk1]