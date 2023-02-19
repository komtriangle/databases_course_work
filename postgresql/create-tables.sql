CREATE  TABLE country(
                         id SERIAL PRIMARY KEY,
                         name TEXT NOT NULL
);

CREATE TABLE gender(
                       id SERIAL PRIMARY KEY,
                       value TEXT NOT NULL
);

CREATE TABLE film_type(
                          id SERIAL PRIMARY KEY,
                          name TEXT NOT NULL
);



CREATE TABLE film(
                     id SERIAL PRIMARY KEY,
                     name TEXT NOT NULL,
                     alternative_name TEXT,
                     description TEXT,
                     year_of_release INT,
                     rating float,
                     lenght INT,
					 film_type_id INT REFERENCES film_type(id)
);

CREATE  TABLE  film_country(
                               id SERIAL PRIMARY KEY,
                               film_id INT REFERENCES film(id) NOT NULL,
                               country_id INT REFERENCES  country(id) NOT NULL
);

CREATE TABLE media_file_type(
                                id SERIAL PRIMARY KEY,
                                name TEXT NOT NULL
);

CREATE TABLE media_file_extension(
                                     id SERIAL PRIMARY KEY,
                                     extension TEXT NOT NULL,
                                     media_file_type_id INT REFERENCES  media_file_type(id) NOT NULL
);

CREATE TABLE media_files(
                            id SERIAL PRIMARY KEY,
                            path TEXT NOT NULL,
                            media_file_extension_id INT REFERENCES  media_files(id) NOT NULL
);

CREATE TABLE film_media_file(
                                id SERIAL PRIMARY KEY,
                                film_id INT REFERENCES film (id) NOT NULL,
                                image_id INT REFERENCES media_files (id) NOT NULL
);

CREATE TABLE speciality(
                           id SERIAL PRIMARY KEY,
                           name TEXT NOT NULL
);

CREATE TABLE person(
                       id SERIAL PRIMARY KEY,
                       name TEXT NOT NULL,
                       growth INT,
                       birthday Date,
                       death Date,
                       birthPlace TEXT,
                       gender_id INT REFERENCES gender(id) NOT NULL
);

CREATE TABLE film_person(
				id SERIAL PRIMARY KEY,
				film_id INT REFERENCES film(id) NOT NULL,
				person_id INT REFERENCES person(id) NOT NULL,
				speciality_id INT REFERENCES speciality(id) NOT NULL
)

CREATE TABLE person_speciality(
                                  id SERIAL PRIMARY KEY,
                                  person_id INT REFERENCES person(id) NOT NULL,
                                  speciality_id INT REFERENCES speciality(id) NOT NULL
);

CREATE TABLE person_media_file(
                             id SERIAL PRIMARY KEY,
                             person_id INT REFERENCES person (id) NOT NULL,
                             media_file_id INT REFERENCES film (id) NOT NULL
);

CREATE TABLE genre(
                      id SERIAL PRIMARY KEY,
                      name TEXT NOT NULL
);

CREATE TABLE film_genre(
                           id SERIAL PRIMARY KEY,
                           film_id INT REFERENCES film(id) NOT NULL,
                           genre_id INT REFERENCES  genre(id) NOT NULL
);



CREATE TABLE role(
                     id SERIAL PRIMARY KEY,
                     name TEXT NOT NULL
);

CREATE  TABLE "user"(
                      id SERIAL PRIMARY KEY,
                      nickname TEXT NOT NULL,
                      password_hash TEXT NOT NULL
);

CREATE TABLE user_role(
                          id SERIAL PRIMARY KEY,
                          user_id INT REFERENCES  "user"(id) NOT NULL,
                          role_id INT REFERENCES  role(id) NOT NULL
);

CREATE TABLE film_review(
                            id SERIAL PRIMARY KEY,
                            user_id INT REFERENCES  "user"(id) NOT NULL,
                            film_id INT REFERENCES  film(id) NOT NULL,
                            start INT NOT NULL
);

ъ
