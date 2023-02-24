create table country
(
    id   serial
        primary key,
    name text not null
);

alter table country
    owner to films_user;

INSERT INTO public.country (id, name) VALUES (1, 'Абхазия');
INSERT INTO public.country (id, name) VALUES (2, 'Австралия');
INSERT INTO public.country (id, name) VALUES (3, 'Австрия');
INSERT INTO public.country (id, name) VALUES (4, 'Азербайджан');
INSERT INTO public.country (id, name) VALUES (5, 'Албания');
INSERT INTO public.country (id, name) VALUES (6, 'Алжир');
INSERT INTO public.country (id, name) VALUES (7, 'Ангола');
INSERT INTO public.country (id, name) VALUES (8, 'Андорра');
INSERT INTO public.country (id, name) VALUES (9, 'Антигуа и Барбуда');
INSERT INTO public.country (id, name) VALUES (10, 'Аргентина');
INSERT INTO public.country (id, name) VALUES (11, 'Армения');
INSERT INTO public.country (id, name) VALUES (12, 'Афганистан');
INSERT INTO public.country (id, name) VALUES (13, 'Багамские Острова');
INSERT INTO public.country (id, name) VALUES (14, 'Бангладеш');
INSERT INTO public.country (id, name) VALUES (15, 'Барбадос');
INSERT INTO public.country (id, name) VALUES (16, 'Бахрейн');
INSERT INTO public.country (id, name) VALUES (17, 'Белиз');
INSERT INTO public.country (id, name) VALUES (18, 'Белоруссия');
INSERT INTO public.country (id, name) VALUES (19, 'Бельгия');
INSERT INTO public.country (id, name) VALUES (20, 'Бенин');
INSERT INTO public.country (id, name) VALUES (21, 'Болгария');
INSERT INTO public.country (id, name) VALUES (22, 'Боливия');
INSERT INTO public.country (id, name) VALUES (23, 'Босния и Герцеговина');
INSERT INTO public.country (id, name) VALUES (24, 'Ботсвана');
INSERT INTO public.country (id, name) VALUES (25, 'Бразилия');
INSERT INTO public.country (id, name) VALUES (26, 'Бруней');
INSERT INTO public.country (id, name) VALUES (27, 'Буркина-Фасо');
INSERT INTO public.country (id, name) VALUES (28, 'Бурунди');
INSERT INTO public.country (id, name) VALUES (29, 'Бутан');
INSERT INTO public.country (id, name) VALUES (30, 'Вануату');
INSERT INTO public.country (id, name) VALUES (31, 'Ватикан');
INSERT INTO public.country (id, name) VALUES (32, 'Великобритания');
INSERT INTO public.country (id, name) VALUES (33, 'Венгрия');
INSERT INTO public.country (id, name) VALUES (34, 'Венесуэла');
INSERT INTO public.country (id, name) VALUES (35, 'Восточный');
INSERT INTO public.country (id, name) VALUES (36, 'Тимор');
INSERT INTO public.country (id, name) VALUES (37, 'Вьетнам');
INSERT INTO public.country (id, name) VALUES (38, 'Габон');
INSERT INTO public.country (id, name) VALUES (39, 'Гаити');
INSERT INTO public.country (id, name) VALUES (40, 'Гайана');
INSERT INTO public.country (id, name) VALUES (41, 'Гамбия');
INSERT INTO public.country (id, name) VALUES (42, 'Гана');
INSERT INTO public.country (id, name) VALUES (43, 'Гватемала');
INSERT INTO public.country (id, name) VALUES (44, 'Гвинея');
INSERT INTO public.country (id, name) VALUES (45, 'Гвинея-Бисау');
INSERT INTO public.country (id, name) VALUES (46, 'Германия');
INSERT INTO public.country (id, name) VALUES (47, 'Гондурас');
INSERT INTO public.country (id, name) VALUES (48, 'Государство Палестина');
INSERT INTO public.country (id, name) VALUES (49, 'Гренада');
INSERT INTO public.country (id, name) VALUES (50, 'Греция');
INSERT INTO public.country (id, name) VALUES (51, 'Грузия');
INSERT INTO public.country (id, name) VALUES (52, 'Дания');
INSERT INTO public.country (id, name) VALUES (53, 'Джибути');
INSERT INTO public.country (id, name) VALUES (54, 'Доминика');
INSERT INTO public.country (id, name) VALUES (55, 'Доминиканская');
INSERT INTO public.country (id, name) VALUES (56, 'Республика ДР Конго');
INSERT INTO public.country (id, name) VALUES (57, 'Египет');
INSERT INTO public.country (id, name) VALUES (58, 'Замбия');
INSERT INTO public.country (id, name) VALUES (59, 'Зимбабве');
INSERT INTO public.country (id, name) VALUES (60, 'Израиль');
INSERT INTO public.country (id, name) VALUES (61, 'Индия');
INSERT INTO public.country (id, name) VALUES (62, 'Индонезия');
INSERT INTO public.country (id, name) VALUES (63, 'Иордания');
INSERT INTO public.country (id, name) VALUES (64, 'Ирак');
INSERT INTO public.country (id, name) VALUES (65, 'Иран');
INSERT INTO public.country (id, name) VALUES (66, 'Ирландия');
INSERT INTO public.country (id, name) VALUES (67, 'Исландия');
INSERT INTO public.country (id, name) VALUES (68, 'Испания');
INSERT INTO public.country (id, name) VALUES (69, 'Италия');
INSERT INTO public.country (id, name) VALUES (70, 'Йемен');
INSERT INTO public.country (id, name) VALUES (71, 'Кабо-Верде');
INSERT INTO public.country (id, name) VALUES (72, 'Казахстан');
INSERT INTO public.country (id, name) VALUES (73, 'Камбоджа');
INSERT INTO public.country (id, name) VALUES (74, 'Камерун');
INSERT INTO public.country (id, name) VALUES (75, 'Канада');
INSERT INTO public.country (id, name) VALUES (76, 'Катар');
INSERT INTO public.country (id, name) VALUES (77, 'Кения');
INSERT INTO public.country (id, name) VALUES (78, 'Кипр');
INSERT INTO public.country (id, name) VALUES (79, 'Киргизия');
INSERT INTO public.country (id, name) VALUES (80, 'Кирибати');
INSERT INTO public.country (id, name) VALUES (81, 'Китай');
INSERT INTO public.country (id, name) VALUES (82, 'КНДР');
INSERT INTO public.country (id, name) VALUES (83, 'Колумбия');
INSERT INTO public.country (id, name) VALUES (84, 'Коморские Острова');
INSERT INTO public.country (id, name) VALUES (85, 'Коста-Рика');
INSERT INTO public.country (id, name) VALUES (86, 'Кот-д''Ивуар');
INSERT INTO public.country (id, name) VALUES (87, 'Куба');
INSERT INTO public.country (id, name) VALUES (88, 'Кувейт');
INSERT INTO public.country (id, name) VALUES (89, 'Лаос');
INSERT INTO public.country (id, name) VALUES (90, 'Латвия');
INSERT INTO public.country (id, name) VALUES (91, 'Лесото');
INSERT INTO public.country (id, name) VALUES (92, 'Либерия');
INSERT INTO public.country (id, name) VALUES (93, 'Ливан');
INSERT INTO public.country (id, name) VALUES (94, 'Ливия');
INSERT INTO public.country (id, name) VALUES (95, 'Литва');
INSERT INTO public.country (id, name) VALUES (96, 'Лихтенштейн');
INSERT INTO public.country (id, name) VALUES (97, 'Люксембург');
INSERT INTO public.country (id, name) VALUES (98, 'Маврикий');
INSERT INTO public.country (id, name) VALUES (99, 'Мавритания');
INSERT INTO public.country (id, name) VALUES (100, 'Мадагаскар');
INSERT INTO public.country (id, name) VALUES (101, 'Малави');
INSERT INTO public.country (id, name) VALUES (102, 'Малайзия');
INSERT INTO public.country (id, name) VALUES (103, 'Мали');
INSERT INTO public.country (id, name) VALUES (104, 'Мальдивские');
INSERT INTO public.country (id, name) VALUES (105, 'Острова');
INSERT INTO public.country (id, name) VALUES (106, 'Мальта');
INSERT INTO public.country (id, name) VALUES (107, 'Марокко');
INSERT INTO public.country (id, name) VALUES (108, 'Маршалловы Острова');
INSERT INTO public.country (id, name) VALUES (109, 'Мексика');
INSERT INTO public.country (id, name) VALUES (110, 'Мозамбик');
INSERT INTO public.country (id, name) VALUES (111, 'Молдавия');
INSERT INTO public.country (id, name) VALUES (112, 'Монако');
INSERT INTO public.country (id, name) VALUES (113, 'Монголия');
INSERT INTO public.country (id, name) VALUES (114, 'Мьянма');
INSERT INTO public.country (id, name) VALUES (115, 'Намибия');
INSERT INTO public.country (id, name) VALUES (116, 'Науру');
INSERT INTO public.country (id, name) VALUES (117, 'Непал');
INSERT INTO public.country (id, name) VALUES (118, 'Нигер');
INSERT INTO public.country (id, name) VALUES (119, 'Нигерия');
INSERT INTO public.country (id, name) VALUES (120, 'Нидерланды');
INSERT INTO public.country (id, name) VALUES (121, 'Никарагуа');
INSERT INTO public.country (id, name) VALUES (122, 'Новая Зеландия');
INSERT INTO public.country (id, name) VALUES (123, 'Норвегия');
INSERT INTO public.country (id, name) VALUES (124, 'ОАЭ');
INSERT INTO public.country (id, name) VALUES (125, 'Оман');
INSERT INTO public.country (id, name) VALUES (126, 'Пакистан');
INSERT INTO public.country (id, name) VALUES (127, 'Палау');
INSERT INTO public.country (id, name) VALUES (128, 'Панама');
INSERT INTO public.country (id, name) VALUES (129, 'Папуа - Новая Гвинея');
INSERT INTO public.country (id, name) VALUES (130, 'Парагвай');
INSERT INTO public.country (id, name) VALUES (131, 'Перу');
INSERT INTO public.country (id, name) VALUES (132, 'Польша');
INSERT INTO public.country (id, name) VALUES (133, 'Португалия');
INSERT INTO public.country (id, name) VALUES (134, 'Республика Конго');
INSERT INTO public.country (id, name) VALUES (135, 'Республика Корея');
INSERT INTO public.country (id, name) VALUES (136, 'Россия');
INSERT INTO public.country (id, name) VALUES (137, 'Руанда');
INSERT INTO public.country (id, name) VALUES (138, 'Румыния');
INSERT INTO public.country (id, name) VALUES (139, 'Сальвадор');
INSERT INTO public.country (id, name) VALUES (140, 'Самоа');
INSERT INTO public.country (id, name) VALUES (141, 'Сан-Марино');
INSERT INTO public.country (id, name) VALUES (142, 'Сан-Томе и Принсипи');
INSERT INTO public.country (id, name) VALUES (143, 'Саудовская Аравия');
INSERT INTO public.country (id, name) VALUES (144, 'Северная Македония');
INSERT INTO public.country (id, name) VALUES (145, 'Сейшельские Острова');
INSERT INTO public.country (id, name) VALUES (146, 'Сенегал');
INSERT INTO public.country (id, name) VALUES (147, 'Сент-Винсент и Гренадины');
INSERT INTO public.country (id, name) VALUES (148, 'Сент-Китс и Невис');
INSERT INTO public.country (id, name) VALUES (149, 'Сент-Люсия');
INSERT INTO public.country (id, name) VALUES (150, 'Сербия');
INSERT INTO public.country (id, name) VALUES (151, 'Сингапур');
INSERT INTO public.country (id, name) VALUES (152, 'Сирия');
INSERT INTO public.country (id, name) VALUES (153, 'Словакия');
INSERT INTO public.country (id, name) VALUES (154, 'Словения');
INSERT INTO public.country (id, name) VALUES (155, 'Соломоновы Острова');
INSERT INTO public.country (id, name) VALUES (156, 'Сомали');
INSERT INTO public.country (id, name) VALUES (157, 'Судан');
INSERT INTO public.country (id, name) VALUES (158, 'Суринам');
INSERT INTO public.country (id, name) VALUES (159, 'США');
INSERT INTO public.country (id, name) VALUES (160, 'Сьерра-Леоне');
INSERT INTO public.country (id, name) VALUES (161, 'Таджикистан');
INSERT INTO public.country (id, name) VALUES (162, 'Таиланд');
INSERT INTO public.country (id, name) VALUES (163, 'Танзания');
INSERT INTO public.country (id, name) VALUES (164, 'Того');
INSERT INTO public.country (id, name) VALUES (165, 'Тонга');
INSERT INTO public.country (id, name) VALUES (166, 'Тринидад и Тобаго');
INSERT INTO public.country (id, name) VALUES (167, 'Тувалу');
INSERT INTO public.country (id, name) VALUES (168, 'Тунис');
INSERT INTO public.country (id, name) VALUES (169, 'Туркмения');
INSERT INTO public.country (id, name) VALUES (170, 'Турция');
INSERT INTO public.country (id, name) VALUES (171, 'Уганда');
INSERT INTO public.country (id, name) VALUES (172, 'Узбекистан');
INSERT INTO public.country (id, name) VALUES (173, 'Украина');
INSERT INTO public.country (id, name) VALUES (174, 'Уругвай');
INSERT INTO public.country (id, name) VALUES (175, 'Федеративные Штаты');
INSERT INTO public.country (id, name) VALUES (176, 'Микронезии');
INSERT INTO public.country (id, name) VALUES (177, 'Фиджи');
INSERT INTO public.country (id, name) VALUES (178, 'Филиппины');
INSERT INTO public.country (id, name) VALUES (179, 'Финляндия');
INSERT INTO public.country (id, name) VALUES (180, 'Франция');
INSERT INTO public.country (id, name) VALUES (181, 'Хорватия');
INSERT INTO public.country (id, name) VALUES (182, 'ЦАР');
INSERT INTO public.country (id, name) VALUES (183, 'Чад');
INSERT INTO public.country (id, name) VALUES (184, 'Черногория');
INSERT INTO public.country (id, name) VALUES (185, 'Чехия');
INSERT INTO public.country (id, name) VALUES (186, 'Чили');
INSERT INTO public.country (id, name) VALUES (187, 'Швейцария');
INSERT INTO public.country (id, name) VALUES (188, 'Швеция');
INSERT INTO public.country (id, name) VALUES (189, 'Шри-Ланка');
INSERT INTO public.country (id, name) VALUES (190, 'Эквадор');
INSERT INTO public.country (id, name) VALUES (191, 'Экваториальная Гвинея');
INSERT INTO public.country (id, name) VALUES (192, 'Эритрея');
INSERT INTO public.country (id, name) VALUES (193, 'Эсватини');
INSERT INTO public.country (id, name) VALUES (194, 'Эстония');
INSERT INTO public.country (id, name) VALUES (195, 'Эфиопия');
INSERT INTO public.country (id, name) VALUES (196, 'ЮАР');
INSERT INTO public.country (id, name) VALUES (197, 'Южная Осетия');
INSERT INTO public.country (id, name) VALUES (198, 'Южный Судан');
INSERT INTO public.country (id, name) VALUES (199, 'Ямайка');
INSERT INTO public.country (id, name) VALUES (200, 'Япония');
INSERT INTO public.country (id, name) VALUES (201, 'СССР');
INSERT INTO public.country (id, name) VALUES (202, 'Корея Южная');


create table film_type
(
    id   serial
        primary key,
    name text not null
);

alter table film_type
    owner to films_user;

INSERT INTO public.film_type (id, name) VALUES (1, 'movie');
INSERT INTO public.film_type (id, name) VALUES (2, 'cartoon');
INSERT INTO public.film_type (id, name) VALUES (3, 'anime');




create table film
(
    id               serial
        primary key,
    name             text    not null,
    alternative_name text,
    description      text,
    year_of_release  integer,
    rating           double precision,
    length           integer,
    film_type_id     integer not null
        references film_type
);

alter table film
    owner to films_user;


create table film_country
(
    id         serial
        primary key,
    film_id    integer not null
        references film,
    country_id integer not null
        references country
);

ALTER TABLE film_country
ADD UNIQUE (film_id, country_id);

alter table film_country
    owner to films_user;


create table genre
(
    id   serial
        primary key,
    name text not null
);

alter table genre
    owner to films_user;

INSERT INTO public.genre (id, name) VALUES (1, 'драма');
INSERT INTO public.genre (id, name) VALUES (2, 'криминал');
INSERT INTO public.genre (id, name) VALUES (3, 'фэнтези');
INSERT INTO public.genre (id, name) VALUES (4, 'биография');
INSERT INTO public.genre (id, name) VALUES (5, 'военный');
INSERT INTO public.genre (id, name) VALUES (6, 'история');
INSERT INTO public.genre (id, name) VALUES (7, 'мелодрама');
INSERT INTO public.genre (id, name) VALUES (8, 'комедия');
INSERT INTO public.genre (id, name) VALUES (9, 'приключения');
INSERT INTO public.genre (id, name) VALUES (10, 'музыка');
INSERT INTO public.genre (id, name) VALUES (11, 'мультфильм');
INSERT INTO public.genre (id, name) VALUES (12, 'семейный');
INSERT INTO public.genre (id, name) VALUES (13, 'фантастика');
INSERT INTO public.genre (id, name) VALUES (14, 'мюзикл');
INSERT INTO public.genre (id, name) VALUES (15, 'триллер');
INSERT INTO public.genre (id, name) VALUES (16, 'аниме');
INSERT INTO public.genre (id, name) VALUES (17, 'детектив');
INSERT INTO public.genre (id, name) VALUES (18, 'боевик');
INSERT INTO public.genre (id, name) VALUES (19, 'вестерн');
INSERT INTO public.genre (id, name) VALUES (20, 'спорт');
INSERT INTO public.genre (id, name) VALUES (21, 'ужасы');


create table film_genre
(
    id       serial
        primary key,
    film_id  integer not null
        references film,
    genre_id integer not null
        references genre
);

ALTER TABLE film_genre
ADD UNIQUE (film_id, genre_id);

alter table film_genre
    owner to films_user;




create table media_file_type
(
    id   serial
        primary key,
    name text not null
);

alter table media_file_type
    owner to films_user;

INSERT INTO public.media_file_type (id, name) VALUES (1, 'фото');
INSERT INTO public.media_file_type (id, name) VALUES (2, 'видео');



create table media_file_extension
(
    id                 serial
        primary key,
    extension          text    not null,
    media_file_type_id integer not null
        references media_file_type
);

alter table media_file_extension
    owner to films_user;

INSERT INTO public.media_file_extension (id, extension, media_file_type_id) VALUES (1, '.png', 1);
INSERT INTO public.media_file_extension (id, extension, media_file_type_id) VALUES (2, '.jpg', 1);
INSERT INTO public.media_file_extension (id, extension, media_file_type_id) VALUES (3, '.jpeg', 1);
INSERT INTO public.media_file_extension (id, extension, media_file_type_id) VALUES (4, '.tiff', 1);
INSERT INTO public.media_file_extension (id, extension, media_file_type_id) VALUES (5, '.mp3', 2);
INSERT INTO public.media_file_extension (id, extension, media_file_type_id) VALUES (6, '.mp4', 2);
INSERT INTO public.media_file_extension (id, extension, media_file_type_id) VALUES (7, '.mov', 2);



create table media_files
(
    id                      serial
        primary key,
    path                    text    not null,
    media_file_extension_id integer not null
        references media_file_extension
            on delete cascade
);

alter table media_files
    owner to films_user;



create table film_media_file_type
(
    id   serial
        primary key,
    name text
);

alter table film_media_file_type
    owner to films_user;

INSERT INTO public.film_media_file_type (id, name) VALUES (1, 'poster');
INSERT INTO public.film_media_file_type (id, name) VALUES (2, 'film_photo');




create table film_media_file
(
    id       serial
        primary key,
    film_id  integer not null
        references film,
    file_id integer not null
        references media_files,
    type     integer not null
        references film_media_file_type
);

ALTER TABLE film_media_file
ADD UNIQUE (film_id, file_id);

alter table film_media_file
    owner to films_user;



create table gender
(
    id    serial
        primary key,
    value text not null
);

alter table gender
    owner to films_user;

INSERT INTO public.gender (id, value) VALUES (1, 'male');
INSERT INTO public.gender (id, value) VALUES (2, 'female');


create table person
(
    id         serial
        primary key,
    name       text    not null,
    growth     integer,
    birthday   date,
    death      date,
    birthplace text,
    gender_id  integer not null
        references gender
);

alter table person
    owner to films_user;


create table "user"
(
    id            serial
        primary key,
    nickname      text not null,
    password_hash text not null
);

alter table "user"
    owner to films_user;



create table film_review
(
    id      serial
        primary key,
    user_id integer not null
        references "user",
    film_id integer not null
        references film,
    star   integer not null
);

ALTER TABLE film_review
ADD UNIQUE (user_id, film_id);

alter table film_review
    owner to films_user;



create table person_media_file
(
    id            serial
        primary key,
    person_id     integer not null
        references person,
    media_file_id integer not null
        references media_files
            on delete cascade
);

ALTER TABLE person_media_file
ADD UNIQUE (person_id, media_file_id);

alter table person_media_file
    owner to films_user;




create table speciality
(
    id   serial
        primary key,
    name text not null
);

alter table speciality
    owner to films_user;

INSERT INTO public.speciality (id, name) VALUES (1, 'actor');
INSERT INTO public.speciality (id, name) VALUES (2, 'director');
INSERT INTO public.speciality (id, name) VALUES (3, 'producer');



create table person_speciality
(
    id            serial
        primary key,
    person_id     integer not null
        references person,
    speciality_id integer not null
        references speciality
);

ALTER TABLE person_speciality
ADD UNIQUE (person_id, speciality_id);

alter table person_speciality
    owner to films_user;




create table role
(
    id   serial
        primary key,
    name text not null
);

alter table role
    owner to films_user;






create table user_role
(
    id      serial
        primary key,
    user_id integer not null
        references "user",
    role_id integer not null
        references role
);

alter table user_role
    owner to films_user;



create table film_person
(
    id            serial
        primary key,
    film_id       integer not null
        references film,
    person_id     integer not null
        references person,
    speciality_id integer not null
        references speciality
);

ALTER TABLE film_person
ADD UNIQUE (film_id, person_id, speciality_id);

alter table film_person
    owner to films_user;


