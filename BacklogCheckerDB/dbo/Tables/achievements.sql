CREATE TABLE [achievements] (
	id integer NOT NULL,
	title varchar(255) NOT NULL,
	shortTitle varchar(255) NOT NULL,
	created_at datetime NOT NULL,
	updated_at datetime NULL,
  CONSTRAINT [PK_ACHIEVEMENTS] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)