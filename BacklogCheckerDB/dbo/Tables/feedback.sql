CREATE TABLE [feedback] (
	id integer NOT NULL,
	user_id integer NOT NULL,
	subject varchar(255) NOT NULL,
	text varchar(2500) NOT NULL,
	created_at datetime NOT NULL,
	updated_at datetime NOT NULL,
  CONSTRAINT [PK_FEEDBACK] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
ALTER TABLE [feedback] ADD CONSTRAINT [feedback_fk0] FOREIGN KEY ([user_id]) REFERENCES [users]([id])
ON UPDATE CASCADE
GO

ALTER TABLE [feedback] CHECK CONSTRAINT [feedback_fk0]