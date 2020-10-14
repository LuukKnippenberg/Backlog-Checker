CREATE TABLE [games] (
	id integer NOT NULL,
	title varchar(255) NOT NULL,
	password varchar(255) NOT NULL,
	headerUrl varchar(255) NOT NULL,
	created_at datetime NOT NULL,
	updated_at datetime NOT NULL,
  CONSTRAINT [PK_GAMES] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)