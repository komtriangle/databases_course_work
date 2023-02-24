create table media_files_film_tmp
(
    id      serial
        primary key,
    path    text,
    film_id integer,
    name    text
);

alter table media_files_film_tmp
    owner to films_user;

ALTER TABLE media_files_film_tmp
ADD UNIQUE (film_id, name);