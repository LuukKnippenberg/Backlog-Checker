CREATE TABLE [users] (
	id integer NOT NULL,
	name varchar(255) NOT NULL,
	surname varchar(255) NOT NULL,
	email varchar(255) NOT NULL,
	password varchar(255) NOT NULL,
	avatarUrl varchar(255) NOT NULL,
	headerUrl varchar(255) NOT NULL,
	created_at datetime NOT NULL,
	updated_at datetime NOT NULL,
	verified_at datetime NOT NULL,
  CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)