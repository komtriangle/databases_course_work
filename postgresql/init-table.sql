INSERT INTO media_file_type
(name)
VALUES 
('фото'),
('видео');

INSERT INTO media_file_extension
(extension, media_file_type_id)
VALUES
('.png', 1),
('.jpg', 1),
('.jpeg', 1),
('.tiff', 1),
('.mp3', 2),
('.mp4', 2),
('.mov', 2);
