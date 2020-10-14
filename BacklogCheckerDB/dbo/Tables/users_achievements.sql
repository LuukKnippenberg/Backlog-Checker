CREATE TABLE [users_achievements] (
	id integer NOT NULL,
	achievement_id integer NOT NULL,
	user_id integer NOT NULL,
	completed smallint NOT NULL,
  CONSTRAINT [PK_USERS_ACHIEVEMENTS] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
ALTER TABLE [users_achievements] ADD CONSTRAINT [users_achievements_fk0] FOREIGN KEY ([achievement_id]) REFERENCES [achievements]([id])
ON UPDATE CASCADE
GO

ALTER TABLE [users_achievements] CHECK CONSTRAINT [users_achievements_fk0]
GO
ALTER TABLE [users_achievements] ADD CONSTRAINT [users_achievements_fk1] FOREIGN KEY ([user_id]) REFERENCES [users]([id])
ON UPDATE CASCADE
GO

ALTER TABLE [users_achievements] CHECK CONSTRAINT [users_achievements_fk1]