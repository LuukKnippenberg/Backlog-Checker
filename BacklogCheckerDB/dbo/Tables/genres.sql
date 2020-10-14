CREATE TABLE [genres] (
	id integer NOT NULL,
	title varchar(255) NOT NULL,
	shortTitle varchar(255) NOT NULL,
	created_at datetime NOT NULL,
	updated_at datetime NOT NULL,
  CONSTRAINT [PK_GENRES] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)