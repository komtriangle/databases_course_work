create table media_files_tmp
(
    id        serial
        primary key,
    file_name text,
    person_id integer
);

alter table media_files_tmp
    owner to films_user;
	
ALTER TABLE media_files_tmp
ADD UNIQUE (file_name, person_id);